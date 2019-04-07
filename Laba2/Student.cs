using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    class Student: Person, IDateAndCopy
    {
        //Person Z = new Person();
       // private Person StudentInfo { get; set; }
        private Education FormInfo { get; set; }
        private int GroupNumber { get; set; }
        //private Exam[] ExamInfo { get; set; }

        private List<Test> Credit = new List<Test>();
        private List<Exam> ListOfExam = new List<Exam>();    //private Exam ListOfExam
        private Person person;

        Student(string newName, string newSurname, DateTime Date, Education form, int group) : base(newName, newSurname, Date)
        {
            //StudentInfo = student;
            FormInfo = form;
            GroupNumber = group;
        }

        Student(): base()
        {
            //StudentInfo = new Person();
            FormInfo = Education.Bachelor;
            GroupNumber = 301;
        }

        public Student(Person person)
        {
            this.person = person;
        }

        public object DeepCopy()
        {
            Student J = new Student(this.Name, this.Surname, this.DateOfBirth, FormInfo, GroupNumber);
            return J;
        }

        public double MediumMark
        {
            get
            {
                double Value = 0;

                if (ListOfExam == null) return 0;
                else
                {
                    for (int i = 0; i < ListOfExam.Count; i++)
                    {
                        Value += ListOfExam[i].Mark;
                    }
                    Value = Value / ListOfExam.Count;
                    return Value;
                }
            }
        }

        public List<Test> AccessCredit
        {
            get
            {
                return Credit;
            }
            set
            {
                Credit = value;
            }
        }

        public List<Exam> AccessExam
        {
            get
            {
                return ListOfExam;
            }
            set
            {
                ListOfExam = value;
            }
        }

        public Person Info
        {
            get
            {
                return new Person(Name, Surname, DateOfBirth);
            }
            set
            {
                Student R = new Student(value.DeepCopy() as Person);
                Name = R.Name;
                Surname = R.Surname;
                DateOfBirth = R.DateOfBirth;
            }
        }

        public int AccessGroupNumber
        {
            get
            {
                return GroupNumber;
            }
            set
            {
                
                    if (value > 100 && value < 699)
                        GroupNumber = value;
                    else
                        throw new ArgumentOutOfRangeException("Error", "Group Number must be > 100 and < 699");
               
            }
        }

        public bool this[Education Check]
        {
            get
            {
                return Check == FormInfo;
            }
        }

        public IEnumerable<Exam> ExamBiggerThan(int Grade)
        {
            foreach(var v in ListOfExam)
            {
                if (v.Mark > Grade)
                {
                    yield return v;
                }
            }
        }

        public IEnumerable<object> ExamsAndTests()
        {
            foreach (var v in Credit)
                yield return v;

            foreach (var v in ListOfExam)
                yield return v;
        }

        public void AddExam(params Exam[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                ListOfExam.Add(input[i]);
            }            
        }

        public void AddCredit(params Test[] input)
        {
            for (int i = 0; i < input.Length; i++)
                Credit.Add(input[i]);
        }

        public override string ToString()
        {
            if (ListOfExam == null) return base.ToString() + " " + FormInfo + " " + GroupNumber + " ";
            else
            {
                Console.WriteLine("Exams: ");
                for (int i = 0; i < ListOfExam.Count; i++)
                {
                    Console.WriteLine(ListOfExam[i]);
                }
                Console.WriteLine("Tests: ");

                for (int i = 0; i < Credit.Count; i++)
                {                    
                    Console.WriteLine(Credit[i]);
                }
                return base.ToString() + " " + FormInfo + " " + GroupNumber + " ";
            }
        }

        public string ToShortString()
        {
            return base.ToString() + " " + FormInfo + " " + GroupNumber + " " + "Середнiй бал: " + MediumMark;  //+ T.ToShortString()
        }

        static void Main(string[] args)
        {
            Person Yes = new Person();
            Student T = new Student();
            Student Y = new Student();

            Person Title1 = new Person("Andrey", "Potapenko", new DateTime(1998, 10, 15));
            Person Title2 = new Person("Andrey", "Potapenko", new DateTime(1998, 10, 15));

            //Виконання
            Yes = new Person("Andrey", "Potapenko", new DateTime(1998, 10, 15));
            T = new Student("Andrey", "Potapenko", new DateTime(1998, 10, 15), Education.Bachelor, 311);

            T.AddExam(new Exam[] { new Exam("C++", 5, new DateTime()), new Exam("dotNet", 4, new DateTime()) });
            T.AddCredit(new Test[] { new Test("Photoshop", true), new Test("MatCad", true) });
              
            Console.WriteLine(T.ToString());

            Console.WriteLine(T.ToShortString());

            //Перевірка хеш кодів
            Yes = Title1;
            Console.WriteLine(Environment.NewLine + Yes.GetHashCode());

            Yes = Title2;
            Console.WriteLine(Environment.NewLine + Yes.GetHashCode());

            //Завдання 4
            Console.WriteLine(T.Info + Environment.NewLine);

            //Завдання 5            
            Y = T.DeepCopy() as Student;

            Y = new Student("Karl", "Krane", new DateTime(1998, 10, 15), Education.Bachelor, 318);
            Console.WriteLine(T.ToShortString());
            Console.WriteLine(Y.ToShortString());

            //Завдання 6
            try { T.AccessGroupNumber = 95; }
            catch { Console.WriteLine("Error" + Environment.NewLine + "Group Number must be > 100 and < 699"); }

            //Завдання 7
            foreach (var v in T.ListOfExam)
            {
                if (v.Mark > 3)
                {
                    Console.WriteLine(v);
                }
            }

            //Додаткові завдання
            


            Console.ReadKey();
        }
    }
}
