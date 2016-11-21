using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmelISPFrontEnd
{
    class AppFormatting
    {
        public static string byteArrayToAsciiHexString(byte[] byteArray)
        {
            string output = "";

            for (int i = 0; i < byteArray.Length; i++)
            {
                output += byteArray[i].ToString("X2") + " ";
            }

            return output;
        }

        public static string byteArrayToAsciiHexString(byte[] byteArray,int lineBreakEveryXBytes)
        {
            string output = "";

            for (int i = 0; i < byteArray.Length; i++)
            {
                if ((i % lineBreakEveryXBytes) == 0 && i != 0)
                {
                    output += "\n";
                }

                output += byteArray[i].ToString("X2") + " ";
            }

            return output;
        }

    }
}
