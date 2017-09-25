using System;
using System.Collections.Generic;

namespace CSharp7Samples
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public Person(string name)
        { }

        public string FirstName => _firstName;
        public string LastName => _lastName;
    }

    public static class PersonExtensions
    {

    }

    public static class StringCollectionExtension
    {
        public static void MoveElementsTo(this IList<string> coll, out string s1, out string s2)
        {
            if (coll.Count != 2) throw new ArgumentException("wrong collection count", nameof(coll));

            s1 = coll[0];
            s2 = coll[1];
        }
    }
}
