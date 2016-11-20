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
    }
}
