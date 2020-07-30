using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Person
    {
        public Person(string argFirstName, string argLastName)
        {
            FirstName = argFirstName;
            LastName = argLastName;
        }

        //A struct is visually similar to a class but is just a way to group data, rather than have any effect on the values like a class would
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
