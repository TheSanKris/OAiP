using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethLab1
{
    internal class Test
    {
       
        public string Name { get; set; }
        public bool IsPass { get; set; }

        public Test(string name, bool isPass)
        {
            Name = name;
            IsPass = isPass;
        }

        public Test()
        {
            Name = "undefined";
            IsPass = false;
        }

        public override string? ToString()
        {
            return Name + " " + IsPass;
        }
    }
}
