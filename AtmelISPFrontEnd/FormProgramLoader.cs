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

                this.richTextBoxTerm.AppendText("Hex File Selected: "+ this.openFileDialogIntelHex.FileName+"\n");
            }
        }

        private void buttonSendToProgrammer_Click(object sender, EventArgs e)
        {
            this.backgroundWorkerISP.RunWorkerAsync();

        }

        private void serialPortISP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void backgroundWorkerISP_DoWork(object sender, DoWorkEventArgs e)
        {
            IntelHexFileParser fParser = new IntelHexFileParser(this.textBoxFileLocation.Text);

            //this.richTextBoxTerm.AppendText("\n");
            //this.richTextBoxTerm.AppendText(fParser.showFileFormatted());
            //this.richTextBoxTerm.AppendText("\n");
        }

        private void backgroundWorkerISP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorkerISP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void serialPortISP_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }

        private void serialPortISP_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {

        }
    }
}
