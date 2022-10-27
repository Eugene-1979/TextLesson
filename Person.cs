using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLesson
{
    class Person : IEquatable<Person?>,IComparable
    {

        public Person(string firstName, string lastName, int phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public string FirstName { get; init; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public int CompareTo(object? other)
        {
           return this.ToString().CompareTo(other.ToString());
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   Phone == other.Phone;
        }

        public override string ToString()
        {
            return $"{FirstName,10} {LastName,10}  {Phone,10}";
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }
    }
}
