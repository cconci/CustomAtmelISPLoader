using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmelISPFrontEnd
{
    class DeviceInfoFileParser
    {
        public static String FILE_NAME = "ModelInfo.txt";
        public static String DETAIL_SEPARATOR = "|";

        private List<DeviceInfo> fileDetails;

        bool fileHasError;

        int numberOfDevicesFound;

        public DeviceInfoFileParser()
        {
            this.fileHasError = false;
            this.numberOfDevicesFound = 0;

            this.fileDetails = new List<DeviceInfo>();
        }

        public void parseDeviceFile(String fileLocation)
        {
            String lineFromFile;

            String path = fileLocation + FILE_NAME;

            //check file Exists
            if (System.IO.File.Exists(path) == false)
            {
                this.fileHasError = true;
                return;
            }

            //Open File Location
            System.IO.StreamReader fStream = new System.IO.StreamReader(path);

            while (true)
            {
                lineFromFile = fStream.ReadLine();

                if (lineFromFile == null)
                {
                    //Done with File
                    break;
                }
                else
                {
                    //
                    DeviceInfo nDevice = new DeviceInfo(lineFromFile);
                    this.fileDetails.Add(nDevice);

                    numberOfDevicesFound++;
                }
            }

            fStream.Close();


        }

        public bool doesFileHaveErrors()
        {
            return this.fileHasError;
        }

        public List<DeviceInfo> getDeviceList()
        {
            return this.fileDetails;
        }

        public int getSizeOfDevice(int index)
        {
            int deviceSize = 0;

            if (index > this.fileDetails.Count || index < 0)
            {

            }
            else
            {
                deviceSize = this.fileDetails[index].getDeviceSize();
            }

            return deviceSize;
        }

        public String getNameOfDevice(int index)
        {
            String deviceName = "------";

            if (index > this.fileDetails.Count || index < 0)
            {

            }
            else
            {
                deviceName = this.fileDetails[index].getDeviceName();
            }

            return deviceName;
        }

        public static int makeDefaultFile(String fileOutputlocation)
        {
            int retCode = 0; ;

            String path = "";

            if(fileOutputlocation.Length > 0)
            {
                path += (fileOutputlocation + "\\");
            } 
            

            System.IO.StreamWriter fStream = new System.IO.StreamWriter(path+DeviceInfoFileParser.FILE_NAME, false);

            //Write
            fStream.WriteLine("ISP SET" + DETAIL_SEPARATOR + "0");
            fStream.WriteLine("AT89S51" + DETAIL_SEPARATOR + "4096");
            fStream.WriteLine("AT89S52" + DETAIL_SEPARATOR + "8192");
            fStream.WriteLine("AT89S53" + DETAIL_SEPARATOR + "12288");

            fStream.Close();

            return retCode;
        }


        public static bool makeFileFromDataGridView(System.Windows.Forms.DataGridView dgv)
        {
            System.IO.StreamWriter fStream = new System.IO.StreamWriter( DeviceInfoFileParser.FILE_NAME, false);

            //Write
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                fStream.WriteLine(dgv.Rows[i].Cells[0].Value + DETAIL_SEPARATOR + dgv.Rows[i].Cells[1].Value);
            }

            fStream.Close();

            return false;
        }

        public static bool fileExists()
        {
            if (System.IO.File.Exists(DeviceInfoFileParser.FILE_NAME) == false)
            {
                return false;
            }

            return true;
        }
    }
}
