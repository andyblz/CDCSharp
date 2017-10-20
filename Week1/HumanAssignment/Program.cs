using System;

namespace HumanAssignment
{
    class Program
    {
        public static void Main(string[] args)
        {
            // When an object is constructed from this class, it should have the abililty to pass a name.
            Human person1 = new Human("Jennifer");
            Human person2 = new Human("Victim");
            Human person3 = new Human("Not Human");
            Console.WriteLine("Victim's health is {0}.", person1.Attack(person3));    
        }
    }
}
