using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Doe.Ls.RAndD.CodeFirst.Bll
{
    public static  class DebuggerInfo
    {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DisplayCurrentMethod(MethodBase methodBase)
        {
            Console.WriteLine($"{methodBase.Name}");
        }

    }
}
