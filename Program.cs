using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TextLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
             /*var range = new List<int>() { 1,1,1,1,2, 3, 4, 5, 6, 7, 8, 9 };
             foreach (var VARIABLE in range)
             {
                 Console.WriteLine(MyBinarySearch(range,VARIABLE));
             }*/
             var b = new List<int> { }.Count();
            bool f= b == 0;
             new Regex("[a-z,A-Z,а-ябА_Я]+").IsMatch("sdfghj");
             new Regex("[a-z,A-Z,а-ябА_Я]+").IsMatch("sdллллj");
             new Regex("\b[a-z,A-Z,а-ябА_Я]+\b").IsMatch("sdfg1hj");
             new Regex("\b[a-z,A-Z,а-ябА_Я]+\b").IsMatch("sdf?ghj");
             // MyBinarySearch(range, 5);

        }
        static int BinarySearchPerson(List<Person> mas, Person human) {
            if ((mas==null)||(human==null)) 
                throw new ArgumentNullException("inpup null");
            string HumanString = human.ToString();
            string RegexHuman = "\b[a-z,A-Z,а-ябА_Я]+\b";
            if (!new Regex(RegexHuman).IsMatch(HumanString))
                throw new ArgumentException("incorrect human");
            


            List<String> result=mas.
                    OrderBy(p => p.LastName).
                    ThenBy(p => p.FirstName).
                    ThenBy(p => p.Phone).
                    Select(p =>p.ToString()).
                    ToList();


            
            return MyBinarySearch(result, HumanString);
            /*return result.BinarySearch(human.ToString());*/


            
        }


        /*Добавил собственную реализацию BinarySearch*/
        static int MyBinarySearch<T>(List<T> mas, T human, int start = 0, int end = 0) where T : IComparable
        {
            return MyBinarySearch(mas, human, 0, mas.Count);

            static int MyBinarySearch<T>(List<T> mas, T human, int start, int end) where T : IComparable
            {




                int mediana = (end+start)  / 2;
                while ((end-start) > 0)
                {
                    if (mas[mediana].Equals(human))
                    {
                        return mediana;
                    }
                    if (mas[mediana].CompareTo(human ) > 0) end = mediana;
                    else start = mediana+1;
                   return  MyBinarySearch<T>(mas, human, start, end);

                     
                }

                return -1;

            }
        }

        static List<Person> FindPerson (List<Person> mas, PersomСriterion сriterion, string value) {
            if ((mas == null) || (value == null))
                throw new ArgumentNullException("inpup null");
            string RegexHuman = "\b[a-z,A-Z,а-ябА_Я]+\b";
            if (!new Regex(RegexHuman).IsMatch(value))
                throw new ArgumentException("incorrect value");
            // if(mas.Count)



            int phone=0;
            if (сriterion == PersomСriterion.Phone) {

                if (!int.TryParse(value, out  phone)) throw new ArgumentException(" no good");

            }            
            return сriterion switch
            {
                PersomСriterion.FirstName =>mas.Where( (p) => p.FirstName == value).ToList(),
                PersomСriterion.LastName => mas.Where((p) => p.LastName == value).ToList(),
                PersomСriterion.Phone => mas.Where((p) => p.Phone == phone).ToList()     
            };
        }

        static List<Person> FindPersonWithPredicate(List<Person> mas, PersomСriterion сriterion, string value)
        {

            if ((mas == null) || (value == null))
                throw new ArgumentNullException("inpup null");
            string RegexHuman = "\b[a-z,A-Z,а-ябА_Я]+\b";
            if (!new Regex(RegexHuman).IsMatch(value))
                throw new ArgumentException("incorrect value");

            int phone = 0;
            if (сriterion == PersomСriterion.Phone)
            {

                if (!int.TryParse(value, out phone)) throw new ArgumentException(" no good");

            }
            Predicate<Person> pred= сriterion switch
            {
                PersomСriterion.FirstName =>(p) => p.FirstName == value,
                PersomСriterion.LastName => (p) => p.LastName == value,
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