using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            var tests = new List<ITest>
            {
               // new DbaseFirstWithDiffrentSchemaTest(),
               // new CodeFirstFromDatabaseSchemaTest()
                //new AsynchTasks()
                new AsynchServiceTest()
            };


            foreach (var test in tests)
            {
                test.Run();
            }


        }
    }
}
