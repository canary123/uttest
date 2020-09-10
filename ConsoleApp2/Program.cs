using System;
using System.Net.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace readJSON
{
    public class Program
    {
        //static string fileName;

        //function to read the json file, parse and display the output.
            public static void ExtractFile(string fileName)
        {
            //check if file exists
            if (File.Exists(fileName))
            {
                Console.WriteLine("JSON File is located at" + fileName);
            }
            else
            {
                Console.WriteLine("The menu.json file does not exist. Please verify!");
            }

            var json = File.ReadAllText(fileName);
            try
            {
               //container for the menues
                var jTokenContainer = JContainer.Parse(json);

                Console.WriteLine("Sample Output:");

                if (jTokenContainer != null)
                    foreach (JToken tokenValue in jTokenContainer)
                    {
                        int itemsIdTotal = 0;

                        // Query to fetch 'ids' of all items that have labels
                        IEnumerable<JToken> idWithLabels = tokenValue.SelectTokens("$..items[?(@.label != null)].id");
                        foreach (JToken item in idWithLabels)
                        {
                            itemsIdTotal += Convert.ToInt32(item.ToString());
                        }
                        Console.WriteLine(itemsIdTotal);
                    }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        static void Main(string[] args)
        {
            // to get the location the assembly is executing from
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //to get the directory path of the JSON file:
            var directory = System.IO.Path.GetDirectoryName(path);

            //build the complete JSON file path
            string fileName = directory + "\\menu.json";

            //create an instance to read and parse the json file
            //Program objProgram = new readJSON.Program();
            ExtractFile(fileName);
            }
    }
}
