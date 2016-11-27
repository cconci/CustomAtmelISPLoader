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
    public partial class FormDeviceInfoEdit : Form
    {
        public FormDeviceInfoEdit()
        {
            InitializeComponent();
        }

        private void FormDeviceInfoEdit_Load(object sender, EventArgs e)
        {
            //load the device file into the window

            try
            {
                DeviceInfoFileParser devInfoFileParser = new DeviceInfoFileParser();
                devInfoFileParser.parseDeviceFile("");//file in root directory of app

                if (devInfoFileParser.doesFileHaveErrors() == false)
                {
                    //add entrys to the drop down
                    List<DeviceInfo> devList = devInfoFileParser.getDeviceList();

                    this.dataGridViewDeviceList.Rows.Clear();
                    this.dataGridViewDeviceList.Columns.Clear();

                    this.dataGridViewDeviceList.Columns.Add("DeviceName","Device Name");
                    this.dataGridViewDeviceList.Columns.Add("DeviceSize","Device Size");

                    for (int i = 0; i < devList.Count; i++)
                    {
                        
                        this.dataGridViewDeviceList.Rows.Add();

                        this.dataGridViewDeviceList.Rows[i].Cells[0].Value = devList[i].getDeviceName();
                        this.dataGridViewDeviceList.Rows[i].Cells[1].Value = devList[i].getDeviceSize()+"";

                    }
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            if (this.textBoxNewDeviceName.Text.Contains("|"))
            {
                MessageBox.Show("Error, name can NOT have a '|'");

                return;
            }

            this.dataGridViewDeviceList.Rows.Add();
            int row = (this.dataGridViewDeviceList.Rows.Count - 1);

            this.dataGridViewDeviceList.Rows[row].Cells[0].Value = this.textBoxNewDeviceName.Text;
            this.dataGridViewDeviceList.Rows[row].Cells[1].Value = this.numericUpDownNewDeviceSize.Value+"";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //No Edits
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DeviceInfoFileParser.makeFileFromDataGridView(this.dataGridViewDeviceList);

            this.Close();
        }
    }
}
