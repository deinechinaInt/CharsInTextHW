using System;
using System.IO;
using System.Linq;

namespace CharsInTextHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = string.Empty;
            try
            {                
                using (var sr = new StreamReader(@"D:\TestForCharsInText.txt")) 
                {
                     result = sr.ReadToEnd();                     
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            /* First option using dictionary

              var charsDictionary = new Dictionary<char, int>();
              foreach (char c in result.ToCharArray())
              {
                  if (!charsDictionary.ContainsKey(c))
                  {
                      charsDictionary[c] = 1;
                  }
                  else
                  {
                      charsDictionary[c]++;
                  }
              } */


            // Second option - twice quicker
            var charGroups = (from s in result
                                  group s by s into g
                                  select new
                                  {
                                      c = g.Key,
                                      count = g.Count(),
                                  });
            
               
                using (var sr = new StreamWriter(@"D:\TestForCharsInTextResult.txt"))
                {
                    foreach (var row in charGroups)
                    {
                        sr.WriteLine("'{0}'= {1}", row.c, row.count);
                    }
                }

                Console.WriteLine("Successfully done!");

                Console.ReadLine();
            
        }
    }
}
