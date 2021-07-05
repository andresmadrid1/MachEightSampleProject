using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace MachEightSampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int nba_heights;

            //In our first step we're going to create a function to download information from this website
            //https://mach-eight.uc.r.appspot.com/ in order to get the NBA players information

            System.Net.WebClient NBAPortalConnection = new System.Net.WebClient();
            string NBAPlayerInformation = NBAPortalConnection.DownloadString("https://mach-eight.uc.r.appspot.com/");
            JObject obj = JObject.Parse(NBAPlayerInformation);
             
            

            //In this step we're already have the information from all NBA players, now we're going to extract the information of the NBA player according to their heights
            Console.WriteLine("Please enter the value of the height that would you like to search for NBA players");
            nba_heights = Convert.ToInt32(Console.ReadLine());
            var OutputNBAInformation = obj["values"]
                .Where(t => t.Value<string>("h_in") == nba_heights.ToString())
                .ToList();

            //If there are any results with the NBA players height, there will be a message with all the information of the players is not there will be a message
            //that indicates that there's no matches found
            if (OutputNBAInformation.Count == 0)
            {
                Console.WriteLine("Not matches found");
            }
            else
            {
                foreach (var item in OutputNBAInformation)
                {
                    Console.WriteLine(item.ToString());
                    
                }
            }
            Console.ReadLine();
        }
    }
}


