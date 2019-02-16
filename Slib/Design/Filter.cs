using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class Filter
    {
        public class Person
        {
            private string name;
            private string gender;
            private string maritalStatus;

            public Person(string name, string gender, string maritalStatus)
            {
                this.name = name;
                this.gender = gender;
                this.maritalStatus = maritalStatus;
            }

            public string getName()
            {
                return name;
            }

            public string getGender()
            {
                return gender;
            }

            public string getMaritalStatus()
            {
                return maritalStatus;
            }

            public override string ToString()
            {
                return name + "," + gender + "," + maritalStatus;
            }
        }
        public interface Criteria
        {
            List<Person> meetCriteria(List<Person> persons);
        }

        public class CriteriaMale : Criteria
        {
            public List<Person> meetCriteria(List<Person> persons)
            {
                List<Person> malePersons = new List<Person>();
                foreach (Person person in persons)
                {
                    if (person.getGender().ToLower().Equals("male"))
                    {
                        malePersons.Add(person);
                    }
                }
                return malePersons;
            }
        }

        public static void invoke()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("john", "Male", "Single"));
            Criteria male = new CriteriaMale();
            Console.WriteLine(new CriteriaMale().meetCriteria(persons).Print());
        }

    }
}
