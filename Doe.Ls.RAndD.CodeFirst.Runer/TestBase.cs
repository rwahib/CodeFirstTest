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
            var descriptiopn = Wordfiy(str);
            Console.WriteLine($"{descriptiopn} is running .......");

            RunCore();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        protected abstract void RunCore();

        protected void PrintMessage(string msg)
        {
            Console.WriteLine($"\n\n......{msg}..............\n\n");
        }

        protected  string Wordfiy(string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return source;
            return Regex.Replace(source, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));

        }
    }
}

