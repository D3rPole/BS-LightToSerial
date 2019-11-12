using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS_Utils.Utilities;

namespace LightOut
{
    class Config
    {
        private static BS_Utils.Utilities.Config config = new BS_Utils.Utilities.Config("LightSerialOutput");
        public static bool enabled
        {
            get
            {
                return config.GetBool("LightSerialOutput", "Enabled", true, true);
            }
            set
            {
                config.SetBool("LightSerialOutput", "Enabled", value);
            }
        }
        public static bool chroma
        {
            get
            {
                return config.GetBool("LightSerialOutput", "Chroma", true, true);
            }
            set
            {
                config.SetBool("LightSerialOutput", "Chroma", value);
            }
        }
        public static int comPort
        {
            get
            {
                return config.GetInt("LightSerialOutput", "ComPort", 4, true);
            }
            set
            {
                config.SetInt("LightSerialOutput", "ComPort", value);
            }
        }
        public static int baudRate
        {
            get
            {
                return config.GetInt("LightSerialOutput", "BaudRate", 9600, true);
            }
            set
            {
                config.SetInt("LightSerialOutput", "BaudRate", value);
            }
        }
    }
}
