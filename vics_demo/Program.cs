using vics_edit;

namespace vics_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(' ');
                if (input == "vics")
                {
                    pre_exec.StartVICS();
                }
                else if (input == "")
                pre_exec.StartVICS(tokens[1]);
            }
            
        }
    }
}