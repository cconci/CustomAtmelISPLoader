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
    class AppDefines
    {
        public static String VERSION_NUMBER = "01.00.00";

        //BGW for ISP (ref FromProgramLoader)
        public enum BGW_ISP_STATES : int
        {
            SHOW_TEXT = 0,
            END,
        };
    }
}
