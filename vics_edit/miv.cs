/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Medli.Apps
{
    class MIV
    {
        private static string filename = String.Empty;
        private static String? text = String.Empty;
        private static bool fileIsOpen = false;
        private static bool running = true;
        public override string Name
        {
            get
            {
                return "miv";
            }
        }
        public override string Summary
        {
            get
            {
                return @"Launches the MIV text editor
No file : miv
Optional: miv [arg]";
            }
        }
        public override void Execute(string param)
        {
            Screen.SaveBuffer();
            Console.Clear();
            if (param != "" && param.Length < 5)
            {
                StartMIV(param);
            }
            else
            {
                StartMIV();
            }
            Screen.RestoreBuffer();
        }

       
    }
}*/


