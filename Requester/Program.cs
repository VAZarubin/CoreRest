using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Requester
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource token = new CancellationTokenSource();
            
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(10));
                    
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    
                    dynamic req = await "http://localhost:5000/api/Some/Some".GetJsonAsync();

                    string rr = JsonConvert.SerializeObject((object)req);
                    
                    Console.WriteLine(rr);

                }


            }, token.Token);
            
            Console.WriteLine("Press any key to Exit");

            Console.Read();
            
            token.Cancel();
        }
    }
}
