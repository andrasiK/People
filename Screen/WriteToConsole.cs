using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public static class WriteToConsole
    {
     /*
     * Here in this class are the 'write out to console' related methods
     */
        
            const string notDefined = "NOT DEFINED";



            public static void WelcomeScreen()
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t**********************************");
                Console.WriteLine("\t\t\t* Welcome to the Life Simulator! *");
                Console.WriteLine("\t\t\t**********************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\tPlease choose an option: ");
                Console.WriteLine("\t\t\t1 - Create a new human");
                Console.WriteLine("\t\t\t2 - Load a previous human from file");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t3 - Exit");

                Console.ForegroundColor = ConsoleColor.White;
            }

            public static void NotImplemented()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tSorry this function is not implemented yet!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }

            public static void PleaseChoose()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tPlease choose from the menu.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }

            public static void Exit()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tThe program exits.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
            }


            public static string[] PersonCreation()
            {
                string[] returnArray = new string[3];

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t***********************************");
                Console.WriteLine("\t\t\t* Here you can create a new human *");
                Console.WriteLine("\t\t\t***********************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\tPlease choose the gender of the new human: ");
                Console.WriteLine("\t\t\t1 - Male");
                Console.WriteLine("\t\t\t2 - Female");
                Console.ForegroundColor = ConsoleColor.White;
                var input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        returnArray[2] = "Male";
                        break;
                    case 2:
                        returnArray[2] = "Female";
                        break;
                    default:
                        returnArray[2] = "Male";
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\tPlease give a name to the new human:");
                Console.ForegroundColor = ConsoleColor.White;
                returnArray[1] = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\tPlease assign an unique ID to him/her:");
                Console.ForegroundColor = ConsoleColor.White;
                returnArray[0] = Console.ReadLine();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\t\t\tThank you.");
                Console.WriteLine(" \t\t\tYour new human will be a {0} and ", returnArray[2]);
                Console.WriteLine("\t\t\this/her name will be {0} and", returnArray[1]);
                Console.WriteLine("\t\t\this/her unique ID is {0}.", returnArray[0]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

                return returnArray;

            }


            public static int PersonLoad()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine("\tPlease give the ID of the person to load it: ");
                Console.ForegroundColor = ConsoleColor.White;
                var pId = int.Parse(Console.ReadLine());
                return pId;
            }


            public static void PersonManage(Person p)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t*******************************************");
                Console.WriteLine("\t\t      Here you can manage {0}      ", p.Name);
                Console.WriteLine("\t\t*******************************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tThe ID of {0} is              :              {1}", p.Name, p.Id.ToString());
                Console.WriteLine("\t{0}'s gender is               :              {1}", p.Name, p.Gender);
                Console.WriteLine("\t{0} lives on planet:          :              {1}", p.Name, p.HomePlanet);
                Console.WriteLine("\tThe hobby(s) from {0} is/are  :              {1}", p.Name, WriteToConsole.ListHobbys(p));
                if (p.Pet == true)
                {
                    Console.Write("\t{0} has a pet. ", p.Name);

                    if (p.PetName.Length > 1)
                    {
                        Console.Write("The name of the animal is {0}", p.PetName);
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t1 - Choose a hobby");
                Console.WriteLine("\t2 - Get a pet");
                Console.WriteLine("\t3 - Give food to {0}", p.Name);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t9 - Return to welcome screen");


                /*
                Console.WriteLine("The AGE of this person is       :              {0}", p.Age == 0 ? notDefined : p.Age.ToString());
                Console.WriteLine("Hobby(s)                        :              {0}", ConsoleCheck.HobbyCheck(p)) ;
                Console.WriteLine( p.Pet == false ? "This person doesn't have a pet." : "This person has a pet." );
                Console.WriteLine("This persons hunger level is    :              {0}", p.Hunger == 0 ? notDefined : p.Hunger.ToString());
                Console.WriteLine("This persons training level is  :              {0}", p.Trained == 0 ? notDefined : p.Trained.ToString());
                */
            }


            public static void ChooseAHobby(Person p)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t\t***********************************************************");
                Console.WriteLine("\t\t      Here you can set a hobby for {0}      ", p.Name);
                Console.WriteLine("\t\t***********************************************************");
                Console.WriteLine();
                Console.WriteLine("\tPlease choose from the list: ");
                Console.WriteLine("\t(A person can have maximum 4 hobbys)");
                Console.WriteLine();
                Console.WriteLine("\t1 - Add {0}", Hobby.Drawing.ToString());
                Console.WriteLine("\t2 - Add {0}", Hobby.Jogging.ToString());
                Console.WriteLine("\t3 - Add {0}", Hobby.Hiking.ToString());
                Console.WriteLine("\t4 - Add {0}", Hobby.Cooking.ToString());
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t9 - Return to manage screen");

            }

            public static string ListHobbys(Person p)
            {
                string hobbyString = "   ";

                if (p.Hobby.Count() == 0)
                {
                    hobbyString = "No hobby...";
                }
                else
                {
                    for (int i = 0; i < p.Hobby.Count(); i++)
                    {

                        hobbyString += p.Hobby[i].ToString();
                        hobbyString = hobbyString.Trim();
                        hobbyString += " ";

                    }
                }

                return hobbyString;
            }

            public static void GivePetName()
            {
                Console.WriteLine();
                Console.WriteLine("Type in the pet's name or just press ENTER: ");
            }

            public static string GiveFoodToThePoorMan()
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You can type in the foods what you want to give (please separate with comma): ");
                Console.ForegroundColor = ConsoleColor.White;
                string foods = Console.ReadLine();

                return foods;
            }






        

    }
}
