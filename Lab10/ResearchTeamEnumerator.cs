using System;
using System.Collections;

namespace Lab10
{
    class ResearchTeamEnumerator : IEnumerator
    {
        System.Collections.Generic.List<Person> persons;
        int position = -1;
        public ResearchTeamEnumerator(System.Collections.Generic.List<Person> persons)
        {
            this.persons = persons;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= persons.Count) throw new InvalidOperationException();
                return persons[position];
            }
        }
        public bool MoveNext()
        {
            if (position < persons.Count - 1)
            {
                position++; return true;
            }
            return false;
        }
        public void Reset() => position = -1;
    }

}
