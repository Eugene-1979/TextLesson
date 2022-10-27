using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextLesson
{
    internal class Genegate
    {
        static string Ukr = "([а-я]|[А-Я])";
        static string Eng = "([a-z]|[A-Z])";
        static Regex rgx = new Regex($@"(^{Ukr}{Ukr}*{Ukr}$)|(^{Eng}{Eng}*{Eng}$)");



        static public int BinarySearchPerson(ref List<Person> mas, Person human)
        {
            if ((mas == null) || (human == null))
                throw new ArgumentNullException("inpup null");
          
           
            if (!rgx.IsMatch(human.FirstName)||
                !rgx.IsMatch(human.LastName))
                throw new ArgumentException("incorrect human");
         
            if (mas.Count() == 0) throw new ListEmptyExeption();


            mas = mas.
                    OrderBy(p => p.FirstName).
                    ThenBy(p => p.LastName).
                    ThenBy(p => p.Phone).      
                    ToList();

            

            return MyBinarySearch( mas,human);
           /* return result.BinarySearch(human.ToString());*/



        }

       /* Добавил собственную реализацию BinarySearch*/
        static  int MyBinarySearch<T>(List<T> mas, T human, int start = 0, int end = 0) where T : IComparable
        {

            if ((mas == null) || (human == null)) throw new ArgumentException("no god argument");

            return MyBinarySearch(mas, human, 0, mas.Count);

            static int MyBinarySearch<T>(List<T> mas, T human, int start, int end) where T : IComparable
            {




                int mediana = (end + start) / 2;
                while ((end - start) > 0)
                {
                    if (mas[mediana].Equals(human))
                    {
                        return mediana;
                    }
                    if (mas[mediana].CompareTo(human) > 0) end = mediana;
                    else start = mediana + 1;
                    return MyBinarySearch<T>(mas, human, start, end);


                }

                return -1;

            }
        }
        static public List<Person> GenerateList(int amount, int lenWord)
        {
            string english = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ukr = "АБВГДЕЖЗИКЛМНОПРСТУФХЧШЩЬЮЯ";
            char[] UpplettersEng = english.ToCharArray();
            char[] lettersEng = english.ToLower().ToCharArray();
            char[] digit = "1234567890".ToCharArray();
            char[] UpplettersUkr = ukr.ToCharArray();
            /*     char[] UpplettersUkr = UnicodeEncoding.UTF8.GetChars(Encoding.UTF8.GetBytes(ukr));*/
            char[] lettersUkr = ukr.ToLower().ToCharArray();

            List<Person> book = new List<Person>();



            Random rnd = new Random();
           

            for (int i = 0; i < amount; i++)
            {
               
                int yyy = rnd.Next(16) % 2;
                Person temp;

                temp = yyy switch
                {
                    /*english Person*/
                   0 => new Person(generateWord(UpplettersEng, lettersEng, lenWord),
                    generateWord(UpplettersEng, lettersEng, lenWord),
                    rnd.Next()),

                    /* ukr Person*/
                    1 => new Person(generateWord(UpplettersUkr, lettersUkr, lenWord),
                    generateWord(UpplettersEng, lettersEng, lenWord),
                    rnd.Next()),
                };
                book.Add(temp);
            }
            return book;

           
        }
        static string generateWord(char[] firstLetter, char[] letter, int lenWord)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            sb.Append(firstLetter[rnd.Next(firstLetter.Length)]);
            for (int i = 0; i < lenWord; i++)
            {
                sb.Append(letter[rnd.Next(letter.Length)]);
            }
            return sb.ToString();
        }
        static public List<Person> FindPerson(List<Person> mas, PersomСriterion сriterion, string value)
        {
            if ((mas == null) || (value == null))
                throw new ArgumentNullException("inpup null");

            string Ukr = "([а-я]|[А-Я])";
            string Eng = "([a-z]|[A-Z])";
            

           
            if (!rgx.IsMatch(value))
                throw new ArgumentException("incorrect value");
            if (mas.Count() == 0) throw new ListEmptyExeption();



            int phone = 0;
            if (сriterion == PersomСriterion.Phone)
            {

                if (!int.TryParse(value, out phone)) throw new ArgumentException(" no good");

            }
            return сriterion switch
            {
                PersomСriterion.FirstName => mas.Where((p) => p.FirstName == value).ToList(),
                PersomСriterion.LastName => mas.Where((p) => p.LastName == value).ToList(),
                PersomСriterion.Phone => mas.Where((p) => p.Phone == phone).ToList()
            };
        }

        static public List<Person> FindPersonWithPredicate(List<Person> mas, PersomСriterion сriterion, string value) 
        {      
            if ((mas == null) || (value == null))
                throw new ArgumentNullException("inpup null");
           
            if (!rgx.IsMatch(value))
                throw new ArgumentException("incorrect value");
            if (mas.Count() == 0) throw new ListEmptyExeption();


            int phone = 0;
            if (сriterion == PersomСriterion.Phone)
            {

                if (!int.TryParse(value, out phone)) throw new ArgumentException(" no good");

            }
            Predicate<Person> pred = сriterion switch
            {
                PersomСriterion.FirstName => (p) => p.FirstName == value,
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
}
