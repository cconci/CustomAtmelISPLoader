/*
 cconci
 - Details for a Device found in the device file
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmelISPFrontEnd
{
    class DeviceInfo
    {
        String deviceName;
        int deviceSize;

        bool recordHasError;

        public DeviceInfo(String lineFromFile)
        {
            this.deviceName = "";
            this.deviceSize = 0;
            this.recordHasError = false;

            this.partseDeviceInfoLineFromFile(lineFromFile);
        }

        public String getDeviceName()
        {
            return this.deviceName;
        }

        public int getDeviceSize()
        {
            return this.deviceSize;
        }

        private void partseDeviceInfoLineFromFile(String lineFromFile)
        {
            /*Lines from File looks like this
             * 
             * ModelText | size \n
             * 
             */

            this.deviceName = lineFromFile.Split('|')[0];

            try
            {
                this.deviceSize = System.Convert.ToInt32(lineFromFile.Split('|')[1]);
            }
            catch
            {
                this.recordHasError = true;
            }

            //break up the string

        }
    }
}
