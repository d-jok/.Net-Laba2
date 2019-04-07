using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Laba2
{
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }

    public class Person : IDateAndCopy
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        protected DateTime DateOfBirth { get; set; }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Person()
        {
            Name = "None";
            Surname = "None";
            DateOfBirth = new DateTime(1997, 10, 15);
        }

        public Person(string newName, string newSurname, DateTime Date)
        {
            Name = newName;
            Surname = newSurname;
            DateOfBirth = Date;
        }


        int ChangeDateOfBirth
        {
            get
            {
                return DateOfBirth.Year;
            }
            set
            {
                DateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day);
            }
        }

        

        //Equal визначає рівність об'єктів як рівність посилань на об'єкти
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (Name == p.Name) && (Surname == p.Surname) && (DateOfBirth == p.DateOfBirth);
            }
        }

        //Перезагрузка оператора ==
        public static bool operator ==(Person obj1, Person obj2)
        {
            return obj1.Equals(obj2);
        }

        //Перезагрузка оператора !=
        public static bool operator !=(Person obj1, Person obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + DateOfBirth.GetHashCode();
        }

        //Вивід
        public override string ToString()
        {
            return Name + " " + Surname + " " + DateOfBirth.ToShortDateString();
        }
        
        public string ToShortString()
        {
            return Name + " " + Surname;
        }

        public object DeepCopy()
        {
            Person J = new Person();
            J.Name = Name;
            J.Surname = Surname;
            J.DateOfBirth = DateOfBirth;
            return J;
        }

        public enum Education
        {
            Master,
            Bachelor,
            SecondEducation
        }

    }
}
