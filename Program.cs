using System.Linq;
using System.Numerics;
using System.Text;

namespace TextLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
        }
        static int BinarySearchPerson(List<Person> mas, Person human) {
            List<String> result=mas.
                    OrderBy(p => p.LastName).
                    ThenBy(p => p.FirstName).
                    ThenBy(p => p.Phone).
                    Select(p =>p.ToString()).
                    ToList();


            return result.BinarySearch(human.ToString());


            
        }
        static List<Person> FindPerson (List<Person> mas, PersomСriterion сriterion, string valus) {
            int phone=0;
            if (сriterion == PersomСriterion.Phone) {

                if (!int.TryParse(valus, out  phone)) throw new ArgumentException(" no good");

            }            
            return сriterion switch
            {
                PersomСriterion.FirstName =>mas.Where( (p) => p.FirstName == valus).ToList(),
                PersomСriterion.LastName => mas.Where((p) => p.LastName == valus).ToList(),
                PersomСriterion.Phone => mas.Where((p) => p.Phone == phone).ToList()     
            };
        }

        static List<Person> FindPersonWithPredicate(List<Person> mas, PersomСriterion сriterion, string valus)
        {
            int phone = 0;
            if (сriterion == PersomСriterion.Phone)
            {

                if (!int.TryParse(valus, out phone)) throw new ArgumentException(" no good");

            }
            Predicate<Person> pred= сriterion switch
            {
                PersomСriterion.FirstName =>(p) => p.FirstName == valus,
                PersomСriterion.LastName => (p) => p.LastName == valus,
                PersomСriterion.Phone => (p) => p.Phone == phone
            };
            List<Person> result = new List<Person>();
            foreach (var item in mas)
            {
                if (pred.Invoke(item)) result.Add(item);
            }
            return result;
        }

    }

    enum PersomСriterion {
        FirstName,
        LastName,
        Phone
    }
    class Person {
        public Person(string firstName, string lastName, int phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public override string ToString()
        {
            return $"{LastName}{FirstName}{Phone}";
        }
    }


}