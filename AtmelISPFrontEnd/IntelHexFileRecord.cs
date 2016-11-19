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
    class IntelHexFileRecord
    {

        private String rawRecord;

        /*
         * Intel Hex file record break down
         * https://en.wikipedia.org/wiki/Intel_HEX
         */
        private String startCode;
        private int byteCount;
        private int address;
        private int recordType;
        private List<int> data;
        private int checkSum;

        private bool recordHasError;
        private String recordErrorNote;

        public IntelHexFileRecord(String rawRecord)
        {
            this.rawRecord = rawRecord;
            this.data = new List<int>();

            this.parseRecord();
        }

        private void parseRecord()
        {
            ///////////////////////////////////////////////////////////////////
            //Start Code
            ///////////////////////////////////////////////////////////////////
            try
            {
                this.startCode = rawRecord.Substring(0, 1);

                if (this.startCode != ":")
                {
                    //Error with file
                    this.recordHasError = true;
                    this.recordErrorNote = "Start Code is incorrect, got '" + this.startCode + "' Should have been ':'";
                    return;
                }
            }
            catch
            {
                //Error with file
                this.recordHasError = true;
                this.recordErrorNote = "Start Code section error";
                return;
            }

            ///////////////////////////////////////////////////////////////////
            //Byte Count
            ///////////////////////////////////////////////////////////////////
            try
            {
                this.byteCount = System.Convert.ToInt32(rawRecord.Substring(1, 2),16);  //The string is a hex string in the intel hex file
            }
            catch
            {
                this.recordHasError = true;
                this.recordErrorNote = "Byte Count section error";
                return;
            }

            ///////////////////////////////////////////////////////////////////
            //Address
            ///////////////////////////////////////////////////////////////////
            try
            {
                this.address = System.Convert.ToInt32(rawRecord.Substring(3, 4), 16);  //The string is a hex string in the intel hex file
            }
            catch
            {
                this.recordHasError = true;
                this.recordErrorNote = "Address section error";
                return;
            }
            ///////////////////////////////////////////////////////////////////
            //Record Type
            ///////////////////////////////////////////////////////////////////
            try
            {
                this.recordType = System.Convert.ToInt32(rawRecord.Substring(7, 2), 16);  //The string is a hex string in the intel hex file
            }
            catch
            {
                this.recordHasError = true;
                this.recordErrorNote = "Type section error";
                return;
            }

            ///////////////////////////////////////////////////////////////////
            //Data
            ///////////////////////////////////////////////////////////////////
            try
            {
                String dataSectionRaw = rawRecord.Substring(9, (this.byteCount * 2));

                data.Clear();

                int dataSectionRawOffset = 0;
                for (int i = 0; i < this.byteCount; i++)
                {
                    data.Add(System.Convert.ToInt32(dataSectionRaw.Substring(dataSectionRawOffset, 2), 16));

                    dataSectionRawOffset += 2;//skip to char at a time
                }
            }
            catch
            {
                this.recordHasError = true;
                this.recordErrorNote = "Data section error";
                return;
            }

            ///////////////////////////////////////////////////////////////////
            //checksum
            ///////////////////////////////////////////////////////////////////
            try
            {
                this.checkSum = System.Convert.ToInt32(rawRecord.Substring(9 + (this.byteCount * 2), 2), 16);  //The string is a hex string in the intel hex file
            }
            catch
            {
                this.recordHasError = true;
                this.recordErrorNote = "checkSum section error";
                return;
            }

            //Validate the checksum?

        }

        public bool doesRecordHaveErrors()
        {
            return this.recordHasError;
        }

        public String getRecordErrorNote()
        {
            return this.recordErrorNote;
        }

        public String showRecordFormatted()
        {
            String recordFormatted = "";

            recordFormatted = "";
            recordFormatted += this.startCode + "|";
            recordFormatted += this.byteCount.ToString("X2") + "|";
            recordFormatted += this.address.ToString("X4") + "|";
            recordFormatted += this.recordType.ToString("X2") + "|";

            for (int i = 0; i < this.data.Count; i++)
            {
                recordFormatted += this.data[i].ToString("X2") + " ";
            }
            recordFormatted += "|";
            recordFormatted += this.checkSum.ToString("X2") + "|";
            recordFormatted += "\n";

            return recordFormatted;
        }

        public int getDataSectionSize()
        {
            return this.data.Count;
        }

        public List<int> getDataSection()
        {
            return this.data;
        }
    }
}
