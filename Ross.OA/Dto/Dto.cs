using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ross.OA.Dto
{
    public class ResultDto<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public int pages { get; set; }
        public int total { get; set; }
        public T datas { get; set; }
    }

    public class OutDto<T>
    {
        public int code { get; set; }
        public string objects { get; set; }
        public string message { get; set; }
        public int num { get; set; }
        public T datas { get; set; }
    }
}
