using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomUI.GameplaySettings;
using CustomUI.Settings;

namespace LightOut.UI
{
    class BasicUI
    {
        public static void CreateUI()
        {
            //This will create the UI for the plugin when called, keep in mind that the mod will require CustomUI when executing this as it calls functions etc from the library
            CreateGameplayOptionsUI();
            CreateSettingsUI();



        }



        public static void CreateSettingsUI()
        {
            //This will create a menu tab in the settings menu for your plugin
            var pluginSettingsSubmenu = SettingsUI.CreateSubMenu("Light Serial Output");

            var enabled = pluginSettingsSubmenu.AddBool("Enabled");
            //Fetch your initial value for the option from within the braces, or simply have it default to a value
            enabled.GetValue += delegate { return Config.enabled;  };
            enabled.SetValue += delegate (bool value) { Config.enabled = value; };

            var chroma = pluginSettingsSubmenu.AddBool("Chroma/lite support");
            chroma.GetValue += delegate { return Config.chroma; };
            chroma.SetValue += delegate (bool value) { Config.chroma = value; };


            var ComPort = pluginSettingsSubmenu.AddInt("Com port", 1, 256, 1);
            ComPort.GetValue += delegate { return Config.comPort; };
            ComPort.SetValue += delegate (int value) { Config.comPort = value; };

            var BaudRate = pluginSettingsSubmenu.AddString("Baud rate", "The Baud rate for the serial signal (Must be a intenger).");
            BaudRate.GetValue += delegate { return Config.baudRate.ToString(); };
            BaudRate.SetValue += delegate (string value) {
                int x = 0;

                if (Int32.TryParse(value, out x))
                {
                    Config.baudRate = x;
                }
                else
                {
                    Config.baudRate = 250000;
                }
            };

            

        }

        public static void CreateGameplayOptionsUI()
        {

            //Example submenu option
            var pluginSubmenu = GameplaySettingsUI.CreateSubmenuOption(GameplaySettingsPanels.ModifiersLeft, "LightSerialOutput", "MainMenu", "LightSerialOutputSettings", "");

            //Example Toggle Option within a submenu
            var enabled = GameplaySettingsUI.CreateToggleOption(GameplaySettingsPanels.ModifiersLeft, "Enabled", "LightSerialOutputSettings", "Toggles the plugin.");
            enabled.GetValue = Config.enabled;/* Fetch the initial value for the option here*/
            enabled.OnToggle += (value) => { Config.enabled = value; }; /*  You can execute whatever you want to occur when the value is toggled here, usually that would include updating wherever the value is pulled from   */
            //exampleOption.AddConflict("Conflicting Option Name"); //You can add conflicts with other gameplay options settings here, preventing both from being active at the same time, including that of other mods

        }





    }
}
