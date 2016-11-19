/*
 cconci
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmelISPFrontEnd
{
    class IntelHexFileParser
    {
        private String fileLocation;
        private List<IntelHexFileRecord> fileDetails;

        private bool fileHasError;

        private int fileDataSectionSize;

        public IntelHexFileParser(String fileLocation)
        {
            this.fileLocation = fileLocation;
            this.fileHasError = false;

            this.fileDataSectionSize = 0;

            this.fileDetails = new List<IntelHexFileRecord>();

            //parse the file
            this.parseIntelHexFile(this.fileLocation);
        }

        public void parseIntelHexFile(String fileLocation)
        {
            String lineFromFile;

            //check file Exists
            if (System.IO.File.Exists(fileLocation) == false)
            {
                this.fileHasError = true;
                return;
            }

            //Open File Location
            System.IO.StreamReader fStream = new System.IO.StreamReader(fileLocation);

            while(true)
            {
                lineFromFile = fStream.ReadLine();

                if (lineFromFile == null)
                {
                    //Done with File
                    break;
                }
                else
                {
                    //parse the record
                    IntelHexFileRecord record = new IntelHexFileRecord(lineFromFile);
                    fileDetails.Add(record);

                    //saves time to get this now, we use it for the byte array size
                    this.fileDataSectionSize += record.getDataSectionSize();

                    if (record.doesRecordHaveErrors() == true)
                    {
                        this.fileHasError = true;
                    }
                }
            }


        }

        public string showFileFormatted()
        {
            string fileFormatted = "";

            for (int i = 0; i < this.fileDetails.Count();i++)
            {
                fileFormatted += this.fileDetails[i].showRecordFormatted();
            }

            return fileFormatted;
        }

        public byte[] getDataSectionAsByteArray()
        {
            int dataSectionPntr = 0;
            byte[] fileDataSection = new byte[this.fileDataSectionSize];

            //we need to copy each records data section into a single array to send down the serial port

            for (int i = 0; i < this.fileDetails.Count; i++)
            {
                List<int> recordDataSection = this.fileDetails[i].getDataSection();

                for (int j = 0; j < recordDataSection.Count; j++)
                {
                    fileDataSection[dataSectionPntr++] = (Byte)recordDataSection[j];
                }

                if (dataSectionPntr > this.fileDataSectionSize)
                {
                    //should never happen
                    return null;
                }
            }


            return fileDataSection;
        }

        public int getDataSectionSize()
        {
            return this.fileDataSectionSize;
        }
    }
}
