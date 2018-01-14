using Client_ConsoleApp.ClientCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client com = new Client();
            Random random = new Random();

            while (true)
            {
                try
                {
                    int ranID = random.Next(100, 999);
                    

                    string shipID = ranID.ToString();
                    
                    com.Send(shipID + "@recorder," + GetRandWeight() + "," + GetRandWeight() + "| DVDPlayer," + GetRandWeight() + "," + GetRandWeight() + "| PCs," + GetRandWeight() + "," + GetRandWeight());
                    Console.WriteLine(shipID + "@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000");
                    Thread.Sleep(5000);
                }
                catch (Exception)
                {

                    com.Close();
                }

            }

            
        }

        private static string GetRandWeight()
        {
            Random random = new Random();
            int randInt = random.Next(10000, 30000);
            string randWeight = randInt.ToString();
            return randWeight;
        }
    }
}
