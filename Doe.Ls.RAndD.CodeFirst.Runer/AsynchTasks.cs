

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{


    public class AsynchTasks : TestBase
    {
        private const string URL = "https://docs.microsoft.com/en-us/dotnet/csharp/csharp";

        /// <summary>
        /// Retrieve data
        /// </summary>

        protected override  void RunCore()
        {
            DoSynchronousWork();
            var someTask = DoSomethingAsync();
            someTask.GetAwaiter().OnCompleted(() =>
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("This task is completed");
            });
             DoSynchronousWorkAfterAwait();
            //someTask.Wait(); //this is a blocking call, use it only on Main method
            Console.WriteLine(someTask.Result);
          
            Console.ReadLine();

        }

        public void DoSynchronousWork()
        {
            // You can do whatever work is needed here
            Console.WriteLine("1. Doing some work synchronously");
        }

        static async Task<string> DoSomethingAsync() //A Task return type will eventually yield a void
        {
            Console.WriteLine("2. Async task has started...");
            return await GetStringAsync(); // we are awaiting the Async Method GetStringAsync
        }

        static async Task<string> GetStringAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
                var result = await httpClient.GetStringAsync(URL); //execution pauses here while awaiting GetStringAsync to complete

                //From this line and below, the execution will resume once the above awaitable is done
                //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
                Console.WriteLine("4. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5. The length of http Get for {URL}");
                Console.WriteLine($"6. {result.Length} character");
                return result.Trim();
            }
        }

        static void DoSynchronousWorkAfterAwait()
        {
            //This is the work we can do while waiting for the awaited Async Task to complete
            Console.WriteLine("7. While waiting for the async task to finish, we can do some unrelated work...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}

