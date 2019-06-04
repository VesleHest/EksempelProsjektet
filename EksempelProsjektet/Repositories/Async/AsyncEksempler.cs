using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EksempelProsjektet.Repositories.Async
{
    public class AsyncEksempler : IAsyncEksempler
    {
        public async Task<int> GetHaikuLength()
        {
            string file = Directory.GetCurrentDirectory() + "\\EksempelTekst.txt";
            
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }

            return count;
        }
    }
}
