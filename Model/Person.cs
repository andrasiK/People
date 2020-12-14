using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Person
    {
        /**********************************************************
       * Fields - in this case no need to declare them separate  *
       **********************************************************/
        private int id;
        private readonly string homePlanet;                         // try out readonly field...

        /*****************************************************************************************************
        * Properties                                                                                         *
        * Auto implemented property - can use, when we don't want to write any specific logic in the get or  *
        *                             set method.                                                            *
        *                             Encapsulates also a private field behind the scene                     *
        *****************************************************************************************************/
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string HomePlanet
        {
            get { return homePlanet; }
        }
        public int Age { get; set; }
        public List<Hobby> Hobby { get; set; }
        public bool Pet { get; set; }
        public string PetName { get; set; }
        public int Hunger { get; set; }
        public double Trained { get; set; }


        /*********************************************************************************************
        * Constructor - default constructor we don't need to write                                   *
        *             - as best practie define constructor only when the object needs to initialized *
        *                or it won't be able to do its job                                           *
        **********************************************************************************************/

        public Person()
        {
            this.homePlanet = "Earth";         // initialize readonly field
            this.Hobby = new List<Hobby>();    // initialize a list to not have nullreference exception
            this.PetName = "p";

        }

        public Person(string gender, string name, string id) : this()     // make another constructor just to see how it's works in this case. 
        {
            this.Gender = gender;
            this.Name = name;
            this.Id = int.Parse(id);
        }



        /*********************************************************************************************
        * Methods                                                                                    *
        *                                                                                            *
        **********************************************************************************************/


        public Person Configure(string[] fromXML, Person p)   // when loading from XML
        {
            p.Id = int.Parse(fromXML[0]);
            p.Name = fromXML[1];
            p.Gender = fromXML[2];
            return p;
        }


        public void AssignHobby(int i)
        {
            if (i < 4)
            {
                Hobby hobby = (Hobby)i;      // Explicit cast
                this.Hobby.Add(hobby);

            }
        }


        public void GetAPet(Person p)
        {
            this.Pet = true;
        }

        public void GetAPet(Person p, string petName)   // method overload for 'GetAPet' method
        {
            this.Pet = true;
            this.PetName = petName;

        }



        public void GiveFood(params string[] food)     // just to try out params keyword
        {

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Thank you for giving food! You gave:  ");
            foreach (var item in food)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();


        }

        public void Train()
        {

        }






    }
}
