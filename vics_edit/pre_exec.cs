using System.IO;

namespace vics_edit
{

    public class Paths
    {
        public static string CurrentDirectory = @"C:\Users\azama\Desktop\vics\output";
    }

    public class KernelExtensions
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    public class pre_exec
    {
        private static string _text;
        private static string _filename;
        private static bool _running;
        private static bool _fileIsOpen;

        public static string Text
        {
            get { return _text; }
        }

        public static string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public static bool Running
        { 
            get { return _running; } 
        }

        public static void StartVICS(string param)
        {

        }









        public static void printMIVStartScreen()
        {
            Console.Clear();
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~");
            Console.WriteLine("~                               MIV - MInimalistic Vi");
            Console.WriteLine("~");
            Console.WriteLine("~                                  version 1.3");
            Console.WriteLine("~                             by Denis Bartashevich");
            Console.WriteLine("~");
            Console.WriteLine("~                    MIV is open source and freely distributable");
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

        public static String stringCopy(String value)
        {
            String newString = String.Empty;

            for (int i = 0; i < value.Length - 1; i++)
            {
                newString += value[i];
            }

            return newString;
        }

        public static void printMIVScreen(char[] chars, int pos, String infoBar, Boolean editMode)
        {
            int countNewLine = 0;
            int countChars = 0;
            delay(10000000);
            Console.Clear();

            for (int i = 0; i < pos; i++)
            {
                if (chars[i] == '\n')
                {
                    Console.WriteLine("");
                    countNewLine++;
                    countChars = 0;
                }
                else
                {
                    Console.Write(chars[i]);
                    countChars++;
                    if (countChars % 80 == 79)
                    {
                        countNewLine++;
                    }
                }
            }

            Console.Write("/");

            for (int i = 0; i < 23 - countNewLine; i++)
            {
                Console.WriteLine("");
                Console.Write("~");
            }

            //PRINT INSTRUCTION
            Console.WriteLine();
            for (int i = 0; i < 72; i++)
            {
                if (i < infoBar.Length)
                {
                    Console.Write(infoBar[i]);
                }
                else
                {
                    Console.Write(" ");
                }
            }

            if (editMode)
            {
                Console.Write(countNewLine + 1 + "," + countChars);
            }

        }

        public static String miv(String start)
        {
            Boolean editMode = false;
            int pos = 0;
            char[] chars = new char[2000];
            String infoBar = String.Empty;

            if (start == null)
            {
                printMIVStartScreen();
            }
            else
            {
                pos = start.Length;

                for (int i = 0; i < start.Length; i++)
                {
                    chars[i] = start[i];
                }
                printMIVScreen(chars, pos, infoBar, editMode);
            }

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (isForbiddenKey(keyInfo.Key)) continue;

                #region MenuMode
                else if (!editMode && keyInfo.KeyChar == ':')
                {
                    infoBar = ":";
                    printMIVScreen(chars, pos, infoBar, editMode);
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            if (infoBar == ":wq" || infoBar == ":save" || infoBar == ":s")
                            {
                                String returnString = String.Empty;
                                for (int i = 0; i < pos; i++)
                                {
                                    returnString += chars[i];
                                }
                                return returnString;
                            }
                            else if (infoBar == ":q" || infoBar == ":quit" || infoBar == ":exit" || infoBar == ":e")
                            {
                                if (_fileIsOpen == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return _text;
                                }

                            }
                            else if (infoBar == ":help" || infoBar == ":h")
                            {
                                printMIVStartScreen();
                                break;
                            }
                            else if (infoBar == ":o" || infoBar == ":open")
                            {
                                OpenFile();
                                break;
                            }
                            else
                            {
                                infoBar = "ERROR: No such command";
                                printMIVScreen(chars, pos, infoBar, editMode);
                                break;
                            }
                        }
                        else if (keyInfo.Key == ConsoleKey.Backspace)
                        {
                            infoBar = stringCopy(infoBar);
                            printMIVScreen(chars, pos, infoBar, editMode);
                        }

                        #region HandleMenuChars
                        else if (keyInfo.KeyChar == 'q')
                        {
                            infoBar += "q";
                        }
                        else if (keyInfo.KeyChar == ':')
                        {
                            infoBar += ":";
                        }
                        else if (keyInfo.KeyChar == 'w')
                        {
                            infoBar += "w";
                        }
                        else if (keyInfo.KeyChar == 'h')
                        {
                            infoBar += "h";
                        }
                        else if (keyInfo.KeyChar == 'e')
                        {
                            infoBar += "e";
                        }
                        else if (keyInfo.KeyChar == 'l')
                        {
                            infoBar += "l";
                        }
                        else if (keyInfo.KeyChar == 'p')
                        {
                            infoBar += "p";
                        }
                        else if (keyInfo.KeyChar == 'o')
                        {
                            infoBar += "o";
                        }
                        else if (keyInfo.KeyChar == 'n')
                        {
                            infoBar += 'n';
                        }
                        else if (keyInfo.KeyChar == 'x')
                        {
                            infoBar += 'x';
                        }
                        else if (keyInfo.KeyChar == 'u')
                        {
                            infoBar += 'u';
                        }
                        else if (keyInfo.KeyChar == 'i')
                        {
                            infoBar += 'i';
                        }
                        else if (keyInfo.KeyChar == 't')
                        {
                            infoBar += 't';
                        }
                        else if (keyInfo.KeyChar == 's')
                        {
                            infoBar += 's';
                        }
                        else if (keyInfo.KeyChar == 'a')
                        {
                            infoBar += 'a';
                        }
                        else if (keyInfo.KeyChar == 'v')
                        {
                            infoBar += 'v';
                        }
                        #endregion
                        else
                        {
                            continue;
                        }
                        printMIVScreen(chars, pos, infoBar, editMode);



                    } while (keyInfo.Key != ConsoleKey.Escape);
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    editMode = false;
                    infoBar = String.Empty;
                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                #endregion

                #region EditMode
                else if (keyInfo.Key == ConsoleKey.I && !editMode)
                {
                    editMode = true;
                    infoBar = "-- INSERT --";
                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                // Newline
                else if (keyInfo.Key == ConsoleKey.Enter && editMode && pos >= 0)
                {
                    chars[pos++] = '\n';
                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }
                // Backspace
                else if (keyInfo.Key == ConsoleKey.Backspace && editMode && pos >= 0)
                {
                    if (pos > 0) pos--;

                    chars[pos] = '\0';

                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                // If in edit mode, add typed character to screen
                if (editMode && pos >= 0)
                {
                    chars[pos++] = keyInfo.KeyChar;
                    printMIVScreen(chars, pos, infoBar, editMode);
                }
                #endregion

            } while (true);
        }

        public static bool isForbiddenKey(ConsoleKey key)
        {
            ConsoleKey[] forbiddenKeys = { ConsoleKey.Print, ConsoleKey.PrintScreen, ConsoleKey.Pause, ConsoleKey.Home, ConsoleKey.PageUp, ConsoleKey.PageDown, ConsoleKey.End, ConsoleKey.NumPad0, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9, ConsoleKey.Insert, ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4, ConsoleKey.F5, ConsoleKey.F6, ConsoleKey.F7, ConsoleKey.F8, ConsoleKey.F9, ConsoleKey.F10, ConsoleKey.F11, ConsoleKey.F12, ConsoleKey.Add, ConsoleKey.Divide, ConsoleKey.Multiply, ConsoleKey.Subtract, ConsoleKey.LeftWindows, ConsoleKey.RightWindows };
            for (int i = 0; i < forbiddenKeys.Length; i++)
            {
                if (key == forbiddenKeys[i]) return true;
            }
            return false;
        }

        public static void delay(int time)
        {
            for (int i = 0; i < time; i++) ;
        }
        public static void StartMIV(string filename)
        {
            try
            {
                if (File.Exists(Paths.CurrentDirectory + @"\" + filename))
                {
                    Console.WriteLine("Found file!");
                }
                else if (!File.Exists(Paths.CurrentDirectory + @"\" + filename))
                {
                    Console.WriteLine("Creating file!");
                    File.Create(Paths.CurrentDirectory + @"\" + filename);
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            _fileIsOpen = true;
            _text = miv(File.ReadAllText(Paths.CurrentDirectory + @"\" + filename));
            Console.Clear();

            if (_text != null)
            {
                File.WriteAllText(Paths.CurrentDirectory + @"\" + filename, _text);
                Console.WriteLine("Content has been saved to " + filename);
            }
        }
        public static void StartMIV()
        {
            String text = String.Empty;

            printMIVStartScreen();

            try
            {
                while (_running == true)
                {
                    text = miv(null);
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                KernelExtensions.PressAnyKey();
            }

            if (text != null)
            {
                File.WriteAllText(Paths.CurrentDirectory + @"\" + _filename, text);
                Console.WriteLine("Content has been saved to " + _filename);
            }
        }

        public static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Enter file's filename to open:");
            Console.WriteLine("If the specified file does not exist, it will be created.");
            _filename = Console.ReadLine();

            if (File.Exists(Paths.CurrentDirectory + @"\" + _filename))
            {
                Console.WriteLine("Found file!");
            }
            else if (!File.Exists(Paths.CurrentDirectory + @"\" + _filename))
            {
                Console.WriteLine("Creating file!");
                File.Create(Paths.CurrentDirectory + @"\" + _filename);

            }
            _text = miv(File.ReadAllText(Paths.CurrentDirectory + @"\" + _filename));
        }
    }
}