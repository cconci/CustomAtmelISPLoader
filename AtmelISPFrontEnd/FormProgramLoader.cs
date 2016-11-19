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
        public FormProgramLoader()
        {
            InitializeComponent();
        }

        private void FormProgramLoader_Load(object sender, EventArgs e)
        {
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

            this.backgroundWorkerISP.RunWorkerAsync();

        }

        private void serialPortISP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
        }

        private void backgroundWorkerISP_DoWork(object sender, DoWorkEventArgs e)
        {
            //parse the ffile
            string fileName = System.IO.Path.GetFileName(this.textBoxFileLocation.Text);
            IntelHexFileParser fParser = new IntelHexFileParser(this.textBoxFileLocation.Text);

            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Hex File Data\n"+fParser.showFileFormatted()+"\n");

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
                this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Waiting For Device ID from ISP\n");

                //clear junk
                this.serialPortISP.DiscardInBuffer();

                while (!this.backgroundWorkerISP.CancellationPending)
                {
                    //read in Data
                    if (serialPortISP.BytesToRead > 0)
                    {
                        int nByte = serialPortISP.ReadByte();

                        this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Got Byte:"+ nByte.ToString("X2")+ "\n");

                        ispControl.addByteFromISP(nByte);

                        int ispMessageStatus = ispControl.validMessageFound();
                        

                        if (ispMessageStatus > 0)
                        {
                            String lastMesageFromISP = ispControl.getLastMessage();

                            //show the last message from the ISP, minus the null
                            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#'"+ lastMesageFromISP.Remove(lastMesageFromISP.Length-1,1) + "' Recived from ISP\n");

                            switch (ispMessageStatus)
                            {
                                case (int)CustomAtmelISPControl.ISP_MESG.AT89S51:
                                case (int)CustomAtmelISPControl.ISP_MESG.AT89S52:
                                case (int)CustomAtmelISPControl.ISP_MESG.AT89S53:

                                    //device details sent
                                    this.serialPortISP.Write("READY\0");
                                    //send file name   
                                    this.serialPortISP.Write(fileName);

                                    this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Ready & Filename sent to ISP\n");

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
                                    Byte[] fileDataSection = fParser.getDataSectionAsByteArray();
                                    this.serialPortISP.Write(fileDataSection, 0, fileDataSection.Length);

                                    this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Sending File data to ISP (Bytes:"+ fileDataSection.Length+ ")\n");

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
            this.richTextBoxTerm.AppendText("#Task Complete\n");
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
    }
}
