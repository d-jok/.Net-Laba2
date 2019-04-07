using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    class Test
    {
        string SubjectName { get; set; }
        bool Passed { get; set; }

        public Test(string Subject, bool Pass)
        {
            this.SubjectName = Subject;
            this.Passed = Pass;
        }

        public Test()
        {
            this.SubjectName = "None";
            this.Passed = false;
        }

        public override string ToString()
        {
            return SubjectName + " " + Passed;
        }
    }
}
