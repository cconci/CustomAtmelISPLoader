using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmelISPFrontEnd
{
    public partial class FormProgramLoader : Form
    {
        DeviceInfoFileParser devInfoFileParser;

        public FormProgramLoader()
        {
            InitializeComponent();
        }

        private void loadDeviceFile()
        {
            //Load the Device List from file
            if (DeviceInfoFileParser.fileExists() == true)
            {
                this.richTextBoxTerm.AppendText("#Device info file found\n");
            }
            else
            {
                this.richTextBoxTerm.AppendText("#Device info file NOT found, creating default file\n");
                DeviceInfoFileParser.makeDefaultFile("");//file in root directory of app
                this.richTextBoxTerm.AppendText("#Device info file created\n");
            }

            //open file and add contends to the list
            devInfoFileParser = new DeviceInfoFileParser();
            devInfoFileParser.parseDeviceFile("");//file in root directory of app

            if (devInfoFileParser.doesFileHaveErrors() == false)
            {
                //add entrys to the drop down
                List<DeviceInfo> devList = devInfoFileParser.getDeviceList();

                this.comboBoxDeviceList.Items.Clear();
                for (int i = 0; i < devList.Count; i++)
                {
                    String itemStr = devList[i].getDeviceName() + " [" + devList[i].getDeviceSize() + "]";

                    this.comboBoxDeviceList.Items.Add(itemStr);
                }
            }
            else
            {
                this.richTextBoxTerm.AppendText("#Device file has errors, deleted it from the application root directory and restart the application\n");
            }
        }

        private void FormProgramLoader_Load(object sender, EventArgs e)
        {
            this.richTextBoxTerm.AppendText("#Application started\n");

            this.loadDeviceFile();

            this.toolStripStatusLabelVersionDetails.Text = AppDefines.VERSION_NUMBER;

            this.labelRefreshCOMports_Click(sender, e);
        }

        private void labelClearTerm_Click(object sender, EventArgs e)
        {
            this.richTextBoxTerm.Text = "";
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            //Show Open file dialogue
            if (this.openFileDialogIntelHex.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFileLocation.Text = this.openFileDialogIntelHex.FileName;

                this.richTextBoxTerm.AppendText("#Hex File Selected: "+ this.openFileDialogIntelHex.FileName+"\n");
            }
        }

        private void buttonSendToProgrammer_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.textBoxFileLocation.Text) == false)
            {
                //Error out due to file not set

                this.richTextBoxTerm.AppendText("#Error: You MUST load a HEX file!!\n");

                return;
            }

            if (this.comboBoxComPorts.SelectedItem == null)
            {
                //check com port index

                this.richTextBoxTerm.AppendText("#Error: You MUST select a COM port!!\n");

                return;
            }

            if (this.backgroundWorkerISP.IsBusy)
            {
                this.richTextBoxTerm.AppendText("#Error: Process already running, killing current task now\n");

                this.backgroundWorkerISP.CancelAsync();

                return;
            }

            this.backgroundWorkerISP.RunWorkerAsync();

        }

        private void serialPortISP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
        }

        private void backgroundWorkerISP_DoWork(object sender, DoWorkEventArgs e)
        {
            //parse the ffile
            string fileName = System.IO.Path.GetFileName(this.textBoxFileLocation.Text);
            bool deviceSetByISP = false;

            IntelHexFileParser fParser = new IntelHexFileParser(this.textBoxFileLocation.Text);

            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Hex File Data\n"+fParser.showFileFormatted()+"\n");

            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Hex File Lines:" + fParser.getRawFileNumLines() + "\n");
            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Hex File Size(RAW):" + fParser.getRawFileSize() + "\n");
            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Hex File Data Section Size:" + fParser.getDataSectionSize() + "\n");

            //Open the selected COM port
            try
            {

                CustomAtmelISPControl ispControl = new CustomAtmelISPControl();

                this.serialPortISP.BaudRate = 9600;
                //get the user selected Com port

                object dCheck = null;
                this.comboBoxComPorts.Invoke(new MethodInvoker(delegate { dCheck = this.comboBoxComPorts.SelectedItem; }));

                if(dCheck != null)
                {
                    this.comboBoxComPorts.Invoke(new MethodInvoker(delegate { this.serialPortISP.PortName = this.comboBoxComPorts.SelectedItem.ToString(); }));
                }

                this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Opening Port " + this.serialPortISP.PortName + "\n");

                this.serialPortISP.Open();

                this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Port " + this.serialPortISP.PortName + " Open\n");

                //Wait for Programmer to ID it self
                this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Waiting for ISP request\n");

                //clear junk
                this.serialPortISP.DiscardInBuffer();

                

                while (!this.backgroundWorkerISP.CancellationPending)
                {
                    //read in Data
                    if (serialPortISP.BytesToRead > 0)
                    {
                        int nByte = serialPortISP.ReadByte();

                        if (this.checkBoxShowComms.Checked == true)
                        {
                            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#RX Byte:" + nByte.ToString("X2") + "\n");
                        }

                        ispControl.addByteFromISP(nByte);

                        int ispMessageStatus = ispControl.validMessageFound();
                        

                        if (ispMessageStatus > 0)
                        {
                            String lastMesageFromISP = ispControl.getLastMessage();

                            //show the last message from the ISP, minus the null
                            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#'"+ lastMesageFromISP.Remove(lastMesageFromISP.Length-1,1) + "' Recived from ISP\n");

                            System.Threading.Thread.Sleep(100); //100ms break before any replys

                            switch (ispMessageStatus)
                            {
                                case (int)CustomAtmelISPControl.ISP_MESG.AT89S51:
                                case (int)CustomAtmelISPControl.ISP_MESG.AT89S52:
                                case (int)CustomAtmelISPControl.ISP_MESG.AT89S53:

                                    if(ispControl.isFileSizeCompatibleWithDevice(ispMessageStatus, fParser.getDataSectionSize()) == false)
                                    {
                                        this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Error: device is to small for data (need:"+ fParser.getDataSectionSize() + ")\n");

                                        this.serialPortISP.Write("ERROR\0");

                                        break;
                                    }

                                    //device has been swt by the ISP
                                    deviceSetByISP = true;

                                    //device details sent
                                    this.serialPortISP.Write("READY\0");

                                    this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Ready sent to ISP\n");

                                    break;
                                case (int)CustomAtmelISPControl.ISP_MESG.FILENAME:
                                    
                                    this.serialPortISP.Write(fileName+"\0");

                                    this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#File Name Sent to ISP\n");

                                    break;
                                case (int)CustomAtmelISPControl.ISP_MESG.RESET:
                                    this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Reset\n");
                                    this.backgroundWorkerISP.CancelAsync();
                                    break;
                                case (int)CustomAtmelISPControl.ISP_MESG.SENDFILE:

                                    System.Threading.Thread.Sleep(1000);//Wait 1 second

                                    //send file data

                                    int deviceSize = 0;

                                    if (deviceSetByISP == true)
                                    {
                                        deviceSize = ispControl.getISPDeviceSize();

                                        this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Using Device sent from ISP ["+ deviceSize + "]\n");

                                    }
                                    else
                                    {
                                        int deviceIndex = 0;
                                        this.comboBoxDeviceList.Invoke(new MethodInvoker(delegate { deviceIndex = this.comboBoxDeviceList.SelectedIndex; }));

                                        deviceSize = this.devInfoFileParser.getSizeOfDevice(deviceIndex);

                                        this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Using Device selected by User [" + deviceSize + "]\n");
                                    }

                                    Byte[] fileDataSection = fParser.getDataSectionAsByteArray(deviceSize);

                                    if (fileDataSection == null)
                                    {
                                        this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Error: hex file size error ["+ ispControl.getISPDeviceSize() + "] \n");
                                        this.serialPortISP.Write("ERROR\0");
                                        break;
                                    }

                                    this.serialPortISP.Write(fileDataSection, 0, fileDataSection.Length);

                                    this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Sending File data to ISP (Bytes:"+ fileDataSection.Length+ ")\n");

                                    if (this.checkBoxShowComms.Checked == true)
                                    {
                                        this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Data Section:\n" + AppFormatting.byteArrayToAsciiHexString(fileDataSection,16)+"\n");
                                    }

                                    break;
                                case (int)CustomAtmelISPControl.ISP_MESG.NO_MESG:
                                default:
                                    this.serialPortISP.Write("ERROR\0");
                                    break;

                            }
                        }
                    }
                    else
                    {
                        //let CPU do something else
                        System.Threading.Thread.Sleep(10);
                    }
                    
                }
            }
            catch
            {
                this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Failed  to Open Port " + this.serialPortISP.PortName + " \n");
            }

        }

        private void backgroundWorkerISP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case (int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT):
                    this.richTextBoxTerm.AppendText((string)e.UserState);
                    break;
            }
        }

        private void backgroundWorkerISP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.serialPortISP.Close();
            try
            {
                this.richTextBoxTerm.AppendText("#COM Port ["+ this.serialPortISP.PortName+ "] Closed\n");
                this.richTextBoxTerm.AppendText("#Task Complete - Press 'Send to Programmer' Button to start server\n");
            }
            catch
            {
                //on exit this can be destroyed befor updaing the term
            }
        }

        private void serialPortISP_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            
        }

        private void serialPortISP_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            
        }

        private void labelRefreshCOMports_Click(object sender, EventArgs e)
        {
            //update the COM port combo box
            string[] portsFound = System.IO.Ports.SerialPort.GetPortNames();

            this.comboBoxComPorts.Items.Clear();

            for (int i = 0; i < portsFound.Length; i++)
            {
                this.comboBoxComPorts.Items.Add(portsFound[i]);
            }
        }

        private void FormProgramLoader_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.backgroundWorkerISP.CancelAsync();
        }

        private void labelCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.richTextBoxTerm.Text);

            this.richTextBoxTerm.AppendText("#Terminal output copied to clipboard\n");
        }

        private void buttonAddNewDevice_Click(object sender, EventArgs e)
        {
            //Show The Add Device form
            FormDeviceInfoEdit nForm = new FormDeviceInfoEdit();

            nForm.ShowDialog();

            this.loadDeviceFile();
        }
    }
}
