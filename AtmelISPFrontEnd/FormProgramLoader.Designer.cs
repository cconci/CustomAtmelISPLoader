namespace AtmelISPFrontEnd
{
    partial class FormProgramLoader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersionDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxFileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSendToProgrammer = new System.Windows.Forms.Button();
            this.richTextBoxTerm = new System.Windows.Forms.RichTextBox();
            this.labelClearTerm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialogIntelHex = new System.Windows.Forms.OpenFileDialog();
            this.serialPortISP = new System.IO.Ports.SerialPort(this.components);
            this.backgroundWorkerISP = new System.ComponentModel.BackgroundWorker();
            this.numericUpDownSerialComPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerialComPortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFile.Location = new System.Drawing.Point(457, 115);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(100, 23);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Load Intel Hex";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(20, 27);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(346, 39);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Atmel ISP Front End";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersionDetails});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Version:";
            // 
            // toolStripStatusLabelVersionDetails
            // 
            this.toolStripStatusLabelVersionDetails.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabelVersionDetails.Name = "toolStripStatusLabelVersionDetails";
            this.toolStripStatusLabelVersionDetails.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabelVersionDetails.Text = "BETA";
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileLocation.Location = new System.Drawing.Point(27, 117);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(410, 21);
            this.textBoxFileLocation.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Intel Hex FIle Location:";
            // 
            // buttonSendToProgrammer
            // 
            this.buttonSendToProgrammer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSendToProgrammer.Location = new System.Drawing.Point(215, 176);
            this.buttonSendToProgrammer.Name = "buttonSendToProgrammer";
            this.buttonSendToProgrammer.Size = new System.Drawing.Size(154, 23);
            this.buttonSendToProgrammer.TabIndex = 5;
            this.buttonSendToProgrammer.Text = "Send To Programmer";
            this.buttonSendToProgrammer.UseVisualStyleBackColor = true;
            this.buttonSendToProgrammer.Click += new System.EventHandler(this.buttonSendToProgrammer_Click);
            // 
            // richTextBoxTerm
            // 
            this.richTextBoxTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxTerm.BackColor = System.Drawing.Color.Silver;
            this.richTextBoxTerm.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxTerm.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxTerm.Location = new System.Drawing.Point(29, 223);
            this.richTextBoxTerm.Name = "richTextBoxTerm";
            this.richTextBoxTerm.ReadOnly = true;
            this.richTextBoxTerm.Size = new System.Drawing.Size(527, 193);
            this.richTextBoxTerm.TabIndex = 6;
            this.richTextBoxTerm.Text = "";
            // 
            // labelClearTerm
            // 
            this.labelClearTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClearTerm.AutoSize = true;
            this.labelClearTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClearTerm.ForeColor = System.Drawing.Color.Blue;
            this.labelClearTerm.Location = new System.Drawing.Point(525, 419);
            this.labelClearTerm.Name = "labelClearTerm";
            this.labelClearTerm.Size = new System.Drawing.Size(31, 13);
            this.labelClearTerm.TabIndex = 7;
            this.labelClearTerm.Text = "Clear";
            this.labelClearTerm.Click += new System.EventHandler(this.labelClearTerm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Details";
            // 
            // openFileDialogIntelHex
            // 
            this.openFileDialogIntelHex.Filter = "Hex Files|*.hex|All Files|*.*,";
            this.openFileDialogIntelHex.RestoreDirectory = true;
            this.openFileDialogIntelHex.Title = "Load Intel Hex File";
            // 
            // serialPortISP
            // 
            this.serialPortISP.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPortISP_ErrorReceived);
            this.serialPortISP.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPortISP_PinChanged);
            this.serialPortISP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortISP_DataReceived);
            // 
            // backgroundWorkerISP
            // 
            this.backgroundWorkerISP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerISP_DoWork);
            this.backgroundWorkerISP.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerISP_ProgressChanged);
            this.backgroundWorkerISP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerISP_RunWorkerCompleted);
            // 
            // numericUpDownSerialComPortNumber
            // 
            this.numericUpDownSerialComPortNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDownSerialComPortNumber.Location = new System.Drawing.Point(288, 150);
            this.numericUpDownSerialComPortNumber.Name = "numericUpDownSerialComPortNumber";
            this.numericUpDownSerialComPortNumber.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownSerialComPortNumber.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Serial COM:";
            // 
            // FormProgramLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownSerialComPortNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelClearTerm);
            this.Controls.Add(this.richTextBoxTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileLocation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.buttonSendToProgrammer);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "FormProgramLoader";
            this.Text = "Atmel ISP Front End";
            this.Load += new System.EventHandler(this.FormProgramLoader_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerialComPortNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersionDetails;
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSendToProgrammer;
        private System.Windows.Forms.RichTextBox richTextBoxTerm;
        private System.Windows.Forms.Label labelClearTerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialogIntelHex;
        private System.IO.Ports.SerialPort serialPortISP;
        private System.ComponentModel.BackgroundWorker backgroundWorkerISP;
        private System.Windows.Forms.NumericUpDown numericUpDownSerialComPortNumber;
        private System.Windows.Forms.Label label3;
    }
}

