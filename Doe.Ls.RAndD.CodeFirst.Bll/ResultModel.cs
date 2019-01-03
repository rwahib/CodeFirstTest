using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doe.Ls.RAndD.CodeFirst.Bll
{
    public class ResultModel<T>
    {
        public T Model { get; set; }
        public List<T> ModelList { get; set; }
        public string Search { get; set; }
        public string Label { get;set; }
    }
}
