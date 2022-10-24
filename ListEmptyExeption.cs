using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLesson
{
    internal class ListEmptyExeption:Exception
    {
       internal ListEmptyExeption():base("Empty List")
        {
            
        }


    }
}
