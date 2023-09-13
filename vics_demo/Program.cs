using vics_edit;

namespace vics_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                string[] tokens = input.Split(' ');
                if (input == "vics")
                {
                    pre_exec.StartVICS();
                }
                else if (input.StartsWith("vics") && tokens.Length < 1)
                {
                    pre_exec.StartVICS(tokens[1]);
                }
                
            }
            
        }
    }
}