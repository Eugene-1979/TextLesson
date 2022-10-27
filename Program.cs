using System.Collections;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TextLesson
{

    internal class Program
    {
        static void Main(string[] args) {
            List<Person> persons=null;

            try
            {
                /*создаём неотсортированный Лист Персон с учётом Regex -либо только Укр ,либо только 
                 Eng букві в name*/
                persons = Genegate.GenerateList(10, 7);
                Console.WriteLine(string.Join('\n', persons));
            }
            catch (ListEmptyExeption e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally {
                /*Добавим персон для поиска по критерию*/
                persons.Add(new Person("Bob", "Stiv", 1));
                persons.Add(new Person("Bob", "Stiv", 12));
                persons.Add(new Person("Bob", "StivStiv", 123));
                persons.Add(new Person("Bob", "StivStiv", 1234));
            }


            


            /*отфильтровали по FirstName -Bob*/
            var poz = Genegate.FindPersonWithPredicate(persons, PersomСriterion.FirstName, "Bob");
            Console.WriteLine(string.Join('\n', poz));


           /* Нашли позицию указанного персонажа,при єтом лист отсортировался ,т.к по ссілке ref*/
            var tt=  Genegate.BinarySearchPerson(ref persons, new Person("Bob", "StivStiv", 1234));


            Console.WriteLine(@"

                 Sorted List");
            for (int i = 0; i <persons.Count; i++)
            {
                Console.WriteLine(persons[i]+" "+i);
            }
            Console.WriteLine(tt);

        }

    }

    enum PersomСriterion {
        FirstName,
        LastName,
        Phone
    }
    


}