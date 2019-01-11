

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Doe.Ls.RAndD.CodeFirst.Bll;
using Doe.Ls.RAndD.CodeFirst.Bll.CodeFirstEntities;
using Doe.Ls.RAndD.CodeFirst.Bll.Services;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{


    public class AsynchServiceTest : TestBase
    {


        protected override void RunCore()
        {
            var timer = DateTime.Now;
            //UsingParallel();
            UsingTasks();
            var span = DateTime.Now - timer;
            Console.WriteLine(span);
        }

        private  void UsingParallel()
        {
            var service = new CustomerService();
            var tasks = new List<Task>();
            Parallel.Invoke(() => { tasks.Add(service.GetCustomersByName("a")); },
                () => { tasks.Add(service.GetCustomersByName("b")); },
                () => { tasks.Add(service.GetCustomersByName("c")); }
                ,
                () => { tasks.Add(service.GetCustomersByName("d")); }
            );
            var notNullTasks = tasks.Where(t => t != null).ToArray();

            Task.WaitAll(notNullTasks);

            foreach (var task in tasks)
            {
                var taskResult = task as Task<ResultModel<Customer>>;

                if (taskResult == null) continue;
                foreach (var customer in taskResult.Result.ModelList.Take(5))
                {
                    Console.WriteLine(
                        $" search {taskResult.Result.Search} Customer {customer.Person.FirstName} {customer.Person.LastName}");
                }
            }
        }

        private void UsingTasks()
        {
            var service = new CustomerService();


            var tasks = new List<Task>
            {
                service.GetCustomersByName("a"),
                service.GetCustomersByName("b"),
                service.GetCustomersByName("c"),
                service.GetCustomersByName("d")
            };

            var searchTask =  service.SearchCustomer(cs=>cs.Include(c=>c.Person).Where(c=>c.Person.LastName.StartsWith("a")));
            searchTask.Wait();
            var count=searchTask.Result.ModelList.Count;


            Console.WriteLine("Do Something .............");
            var notNullTasks = tasks.Where(t => t != null).ToArray();

            //Task.WaitAll(notNullTasks);

            foreach (var task in tasks)
            {
                var taskResult = task as Task<ResultModel<Customer>>;

                if (taskResult == null) continue;
                foreach (var customer in taskResult.Result.ModelList.Take(5))
                {
                    Console.WriteLine(
                        $" search {taskResult.Result.Search} Customer {customer.Person.FirstName} {customer.Person.LastName}");
                }
            }
        }

       
    }
}

