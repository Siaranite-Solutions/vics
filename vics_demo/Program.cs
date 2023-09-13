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
                string[] tokens = Console.ReadLine().Split(' ');
                
                if (tokens[0] == "vics")
                {
                    
                    if (tokens.Count() > 1)
                    {
                        vics.StartVICS(tokens[1]);
                    }
                    else
                    {
                        vics.StartVICS();
                    }
                }
                else if (tokens[0] == "exit")
                {
                    Environment.Exit(0);
                }
                
            }
            
        }
    }
}