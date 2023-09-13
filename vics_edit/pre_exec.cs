using System.IO;

namespace vics_edit
{

    public class Paths
    {
        public static string CurrentDirectory = @"C:\Users\azama\Desktop\vics\output\";
    }

    public class KernelExtensions
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    public partial class vics
    {
        private static string _text = String.Empty;
        private static string _filename = String.Empty;
        private static bool _running = true;
        private static bool _fileSaved = true;
        private static bool _fileIsOpen;

        public static void VICSStartScreen()
        {
            Console.Clear();
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~                              Vics - Vi for C Sharp");
            Console.WriteLine("~");
            Console.WriteLine("~                                  version 1.4");
            Console.WriteLine("~                                by Arawn Davies");
            Console.WriteLine("~");
            Console.WriteLine("~                     VICS is open source and freely distributable");
            Console.WriteLine("~");
            Console.WriteLine("~                     type :help                 for information");
            Console.WriteLine("~                     type :o or open            to open a text file");
            Console.WriteLine("~                     type :q or quit            to exit");
            Console.WriteLine("~                     type :wq                   save to file and exit");
            Console.WriteLine("~                     press i                    to write");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.Write("~");
        }

        /// <summary>
        /// Start VICS editor with specified filename
        /// The file will be created if it doesn't exist.
        /// </summary>
        /// <param name="filename"></param>
        public static void StartVICS(string filename)
        {
            try
            {
                if (!File.Exists(Paths.CurrentDirectory + @"\" + filename))
                {
                    File.Create(Paths.CurrentDirectory + @"\" + filename).Dispose();
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Append the filename with the current directory path
            _filename = Paths.CurrentDirectory + filename;

            _fileIsOpen = true; 

            try
            {
                _text = VICS(File.ReadAllText(_filename));
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
            }
            if (_text != null && _fileSaved == true)
            {
                
                File.WriteAllText(_filename, _text);
                Console.WriteLine("Content has been saved to " + filename);
            }
        }
        /// <summary>
        /// No command line args
        /// </summary>
        public static void StartVICS()
        {
            try
            {
                _text = VICS(null);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
            }

            if (_text != null && _fileSaved)
            {
                Console.WriteLine("Enter the filename: ");
                string filename = Console.ReadLine();
                _filename = Paths.CurrentDirectory + filename;
                
                File.WriteAllText(_filename, _text);
                Console.WriteLine("Content has been saved to " + _filename);
            }
        }

        public static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Enter file's filename to open:");
            Console.WriteLine("If the specified file does not exist, it will be created.");
            string filename = Console.ReadLine();
             
            _filename = Paths.CurrentDirectory + filename;

            if (File.Exists(_filename))
            {
                Console.WriteLine("Found file!");
            }
            else if (!File.Exists(_filename))
            {
                Console.WriteLine("Creating file!");
                File.Create(_filename);
            }
            try
            {
                _text = VICS(File.ReadAllText(_filename));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
            }
            if (_text != null && _fileSaved == true)
            {
                File.WriteAllText(Paths.CurrentDirectory + @"\" + _filename, _text);
                Console.WriteLine("Content has been saved to " + _filename);
            }
        }
    }
}