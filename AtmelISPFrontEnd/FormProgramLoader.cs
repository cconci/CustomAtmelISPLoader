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
            IntelHexFileParser fParser = new IntelHexFileParser(this.textBoxFileLocation.Text);

            this.backgroundWorkerISP.ReportProgress((int)(AppDefines.BGW_ISP_STATES.SHOW_TEXT), "#Hex File Data\n"+fParser.showFileFormatted()+"\n");

            //Open the selected COM port
            try
            {

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
                while (!this.backgroundWorkerISP.CancellationPending)
                {
                    //act

                    System.Threading.Thread.Sleep(10);
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
