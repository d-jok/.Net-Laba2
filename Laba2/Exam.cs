using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    class Exam
    {
        public string Subject;
        public int Mark;
        public DateTime TimeOfExam;

        public Exam()
        {
            Subject = "C#";
            Mark = 5;
            TimeOfExam = new DateTime(2019, 02, 26);
        }

        public Exam(string subject, int mark, DateTime time)
        {
            Subject = subject;
            Mark = mark;
            TimeOfExam = time;
        }

        public object DeepCopy()
        {
            Exam J = new Exam();
            J.Subject = Subject;
            J.Mark = Mark;
            J.TimeOfExam = TimeOfExam;
            return J;
        }

        public override string ToString()
        {
            return Subject + " " + Mark + " " + TimeOfExam;
        }
    }
}
