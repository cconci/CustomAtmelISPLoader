using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmelISPFrontEnd
{
    class CustomAtmelISPControl
    {
        List<int> incomingPacket;
        DateTime lastByteTimeStamp;
        string lastMessage;

        public enum ISP_DEVICE : int
        {
            AT89S51,
            AT89S52,
            AT89S53,
        };

        int deviceType; //AT89S51,AT89S52,AT89S53

        public enum ISP_DEVICE_MAX_SIZE : int
        {
            AT89S51 = 4096,
            AT89S52 = 8192,
            AT89S53 = 12288,
        };

        public enum ISP_MESG : int
        {
            NO_MESG = 0,
            RESET,
            SENDFILE,
            AT89S51,
            AT89S52,
            AT89S53,
            FILENAME,
        };

        bool validMessageRecived;

        public CustomAtmelISPControl()
        {
            this.incomingPacket = new List<int>();

            this.lastByteTimeStamp = DateTime.Now;
        }

        public void addByteFromISP(int nByte)
        {
            DateTime ByteTimeStamp = DateTime.Now;

            TimeSpan timeBetweenBytes = ByteTimeStamp - this.lastByteTimeStamp;
            int msBetweenBytes = (int)timeBetweenBytes.TotalMilliseconds;

            //reset buffer if there was a large gap between bytes, we are at 9600 so anything over 1ms would be a gap between messages, but i will just have a window
            if (msBetweenBytes > 1000)
            {
                this.incomingPacket.Clear();
            }

            this.incomingPacket.Add(nByte);

            if (nByte == 0x00) //the null indicates an end of mesg
            {
                this.validMessageRecived = true;
            }

            this.lastByteTimeStamp = DateTime.Now;
        }

        public int validMessageFound()
        {
            /*
             Programmer messages    RESETNUL    SENDFILENUL   AT89S51NUL  AT89S52NUL  AT89S53NUL FILENAMENUL
             */

            int mesgID = (int)ISP_MESG.NO_MESG;

            if (this.validMessageRecived == true)
            {
                //Dump the list in to a string then we can check for our messages
                lastMessage = "";
                for (int i = 0; i < this.incomingPacket.Count; i++)
                {
                    lastMessage += ((char)this.incomingPacket[i]).ToString();
                }

                if (lastMessage.Contains("RESET"))
                {
                    mesgID = (int)ISP_MESG.RESET;
                }
                else if (lastMessage.Contains("SENDFILE"))
                {
                    mesgID = (int)ISP_MESG.SENDFILE;
                }
                else if (lastMessage.Contains("AT89S51"))
                {
                    mesgID = (int)ISP_MESG.AT89S51;

                    this.deviceType = (int)ISP_DEVICE.AT89S51;
                }
                else if (lastMessage.Contains("AT89S52"))
                {
                    mesgID = (int)ISP_MESG.AT89S52;

                    this.deviceType = (int)ISP_DEVICE.AT89S52;
                }
                else if (lastMessage.Contains("AT89S53"))
                {
                    mesgID = (int)ISP_MESG.AT89S53;

                    this.deviceType = (int)ISP_DEVICE.AT89S53;
                }
                else if (lastMessage.Contains("FILENAME"))
                {
                    mesgID = (int)ISP_MESG.FILENAME;
                }
                else
                {
                    mesgID = (int)ISP_MESG.NO_MESG;
                }

                //we are done
                this.incomingPacket.Clear();
                this.validMessageRecived = false;

                
            }

            return mesgID;
        }

        public string getLastMessage()
        {
            return this.lastMessage;
        }

        public bool isFileSizeCompatibleWithDevice(int ispMessageIdex, int dataSectionSize)
        {
            /*
            4096 bytes 89S51  
            8192 Bytes 89S52
            12288 bytes 89S53
            */

            bool retVal = true;

            switch (ispMessageIdex)
            {
                case (int)ISP_MESG.AT89S51:

                    if (dataSectionSize > (int)ISP_DEVICE_MAX_SIZE.AT89S51)
                    {
                        //error
                        retVal = false;
                    }

                    break;
                case (int)ISP_MESG.AT89S52:

                    if (dataSectionSize > (int)ISP_DEVICE_MAX_SIZE.AT89S52)
                    {
                        //error
                        retVal = false;
                    }

                    break;
                case (int)ISP_MESG.AT89S53:

                    if (dataSectionSize > (int)ISP_DEVICE_MAX_SIZE.AT89S53)
                    {
                        //error
                        retVal = false;
                    }

                    break;

            }


            return retVal;
        }

        public int getISPDevice()
        {
            return this.deviceType;
        }
    }
}
