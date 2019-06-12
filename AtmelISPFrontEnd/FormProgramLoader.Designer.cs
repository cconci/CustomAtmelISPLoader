﻿namespace AtmelISPFrontEnd
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxComPorts = new System.Windows.Forms.ComboBox();
            this.labelRefreshCOMports = new System.Windows.Forms.Label();
            this.checkBoxShowComms = new System.Windows.Forms.CheckBox();
            this.labelCopyToClipboard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDeviceList = new System.Windows.Forms.ComboBox();
            this.buttonAddNewDevice = new System.Windows.Forms.Button();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFile.Location = new System.Drawing.Point(608, 116);
            this.buttonLoadFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(133, 28);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Load Intel Hex";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(27, 33);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(420, 48);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Atmel ISP Front End";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersionDetails});
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(779, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabel1.Text = "Version:";
            // 
            // toolStripStatusLabelVersionDetails
            // 
            this.toolStripStatusLabelVersionDetails.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabelVersionDetails.Name = "toolStripStatusLabelVersionDetails";
            this.toolStripStatusLabelVersionDetails.Size = new System.Drawing.Size(43, 20);
            this.toolStripStatusLabelVersionDetails.Text = "BETA";
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileLocation.Location = new System.Drawing.Point(36, 118);
            this.textBoxFileLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(545, 24);
            this.textBoxFileLocation.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Intel Hex FIle Location:";
            // 
            // buttonSendToProgrammer
            // 
            this.buttonSendToProgrammer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSendToProgrammer.Location = new System.Drawing.Point(287, 226);
            this.buttonSendToProgrammer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSendToProgrammer.Name = "buttonSendToProgrammer";
            this.buttonSendToProgrammer.Size = new System.Drawing.Size(205, 28);
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
            this.richTextBoxTerm.HideSelection = false;
            this.richTextBoxTerm.Location = new System.Drawing.Point(36, 274);
            this.richTextBoxTerm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxTerm.Name = "richTextBoxTerm";
            this.richTextBoxTerm.ReadOnly = true;
            this.richTextBoxTerm.Size = new System.Drawing.Size(704, 237);
            this.richTextBoxTerm.TabIndex = 6;
            this.richTextBoxTerm.Text = "";
            // 
            // labelClearTerm
            // 
            this.labelClearTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClearTerm.AutoSize = true;
            this.labelClearTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClearTerm.ForeColor = System.Drawing.Color.Blue;
            this.labelClearTerm.Location = new System.Drawing.Point(700, 516);
            this.labelClearTerm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClearTerm.Name = "labelClearTerm";
            this.labelClearTerm.Size = new System.Drawing.Size(41, 17);
            this.labelClearTerm.TabIndex = 7;
            this.labelClearTerm.Text = "Clear";
            this.labelClearTerm.Click += new System.EventHandler(this.labelClearTerm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
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
            this.serialPortISP.PortName = "COM20";
            this.serialPortISP.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPortISP_ErrorReceived);
            this.serialPortISP.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPortISP_PinChanged);
            this.serialPortISP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortISP_DataReceived);
            // 
            // backgroundWorkerISP
            // 
            this.backgroundWorkerISP.WorkerReportsProgress = true;
            this.backgroundWorkerISP.WorkerSupportsCancellation = true;
            this.backgroundWorkerISP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerISP_DoWork);
            this.backgroundWorkerISP.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerISP_ProgressChanged);
            this.backgroundWorkerISP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerISP_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Serial COM:";
            // 
            // comboBoxComPorts
            // 
            this.comboBoxComPorts.FormattingEnabled = true;
            this.comboBoxComPorts.Location = new System.Drawing.Point(36, 167);
            this.comboBoxComPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxComPorts.Name = "comboBoxComPorts";
            this.comboBoxComPorts.Size = new System.Drawing.Size(125, 24);
            this.comboBoxComPorts.TabIndex = 11;
            // 
            // labelRefreshCOMports
            // 
            this.labelRefreshCOMports.AutoSize = true;
            this.labelRefreshCOMports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRefreshCOMports.ForeColor = System.Drawing.Color.Blue;
            this.labelRefreshCOMports.Location = new System.Drawing.Point(171, 171);
            this.labelRefreshCOMports.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRefreshCOMports.Name = "labelRefreshCOMports";
            this.labelRefreshCOMports.Size = new System.Drawing.Size(58, 17);
            this.labelRefreshCOMports.TabIndex = 12;
            this.labelRefreshCOMports.Text = "Refresh";
            this.labelRefreshCOMports.Click += new System.EventHandler(this.labelRefreshCOMports_Click);
            // 
            // checkBoxShowComms
            // 
            this.checkBoxShowComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowComms.AutoSize = true;
            this.checkBoxShowComms.Location = new System.Drawing.Point(39, 516);
            this.checkBoxShowComms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxShowComms.Name = "checkBoxShowComms";
            this.checkBoxShowComms.Size = new System.Drawing.Size(114, 21);
            this.checkBoxShowComms.TabIndex = 13;
            this.checkBoxShowComms.Text = "Show Comms";
            this.checkBoxShowComms.UseVisualStyleBackColor = true;
            // 
            // labelCopyToClipboard
            // 
            this.labelCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCopyToClipboard.AutoSize = true;
            this.labelCopyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyToClipboard.ForeColor = System.Drawing.Color.Blue;
            this.labelCopyToClipboard.Location = new System.Drawing.Point(621, 255);
            this.labelCopyToClipboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCopyToClipboard.Name = "labelCopyToClipboard";
            this.labelCopyToClipboard.Size = new System.Drawing.Size(120, 17);
            this.labelCopyToClipboard.TabIndex = 14;
            this.labelCopyToClipboard.Text = "Copy to Clipboard";
            this.labelCopyToClipboard.Click += new System.EventHandler(this.labelCopyToClipboard_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Device Type";
            // 
            // comboBoxDeviceList
            // 
            this.comboBoxDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeviceList.FormattingEnabled = true;
            this.comboBoxDeviceList.Location = new System.Drawing.Point(261, 167);
            this.comboBoxDeviceList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxDeviceList.Name = "comboBoxDeviceList";
            this.comboBoxDeviceList.Size = new System.Drawing.Size(320, 24);
            this.comboBoxDeviceList.TabIndex = 16;
            // 
            // buttonAddNewDevice
            // 
            this.buttonAddNewDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNewDevice.Location = new System.Drawing.Point(608, 167);
            this.buttonAddNewDevice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddNewDevice.Name = "buttonAddNewDevice";
            this.buttonAddNewDevice.Size = new System.Drawing.Size(133, 28);
            this.buttonAddNewDevice.TabIndex = 17;
            this.buttonAddNewDevice.Text = "Add New Device";
            this.buttonAddNewDevice.UseVisualStyleBackColor = true;
            this.buttonAddNewDevice.Click += new System.EventHandler(this.buttonAddNewDevice_Click);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(35, 212);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(125, 24);
            this.comboBoxBaudRate.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Baud Rate:";
            // 
            // FormProgramLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 567);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Controls.Add(this.buttonAddNewDevice);
            this.Controls.Add(this.comboBoxDeviceList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCopyToClipboard);
            this.Controls.Add(this.checkBoxShowComms);
            this.Controls.Add(this.labelRefreshCOMports);
            this.Controls.Add(this.comboBoxComPorts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelClearTerm);
            this.Controls.Add(this.richTextBoxTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileLocation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.buttonSendToProgrammer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(794, 605);
            this.Name = "FormProgramLoader";
            this.Text = "Atmel ISP Front End";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProgramLoader_FormClosing);
            this.Load += new System.EventHandler(this.FormProgramLoader_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxComPorts;
        private System.Windows.Forms.Label labelRefreshCOMports;
        private System.Windows.Forms.CheckBox checkBoxShowComms;
        private System.Windows.Forms.Label labelCopyToClipboard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDeviceList;
        private System.Windows.Forms.Button buttonAddNewDevice;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label5;
    }
}

