using System;
using System.Text.RegularExpressions;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{
    public abstract class TestBase : ITest
    {
        public void Run()
        {
            DisplayDescription();

        }

        public void DisplayDescription()
        {
            var str = this.GetType().Name;
            var descriptiopn = Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
            Console.WriteLine($"{descriptiopn} is running .......");

            RunCore();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        protected abstract void RunCore();
    }
}

