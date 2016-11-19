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

        public IntelHexFileParser(String fileLocation)
        {
            this.fileLocation = fileLocation;
            this.fileHasError = false;

            this.fileDetails = new List<IntelHexFileRecord>();

            //parse the file
            this.parseIntelHexFile(this.fileLocation);
        }

        public void parseIntelHexFile(String fileLocation)
        {
            String lineFromFile;

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
    }
}
