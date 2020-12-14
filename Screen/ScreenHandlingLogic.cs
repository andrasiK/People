using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class ScreenHandlingLogic
    {
        bool createFlag = false;
        bool exitFlag = false;
        bool loadFlag = false;
        bool falseFlag = false;
        Person createdP = new Person();
        Person loadedP = new Person();
        Person pToManage;
        string[] loadedHuman = new string[3];
        int inputFromManage;

        public int Welcome()
        {
            do
            {
                Console.Clear();
                WriteToConsole.WelcomeScreen();
                var input = int.Parse(Console.ReadLine());

                // Processing menu choise

                string[] idNameGender = new string[3];
                switch (input)
                {
                    // Create a new one
                    case 1:
                        idNameGender = WriteToConsole.PersonCreation();
                        //create the instance and also save to XML file
                        createdP = createdP.Configure(idNameGender, createdP);
                        // also save the new created person
                        XmlOperations x = new XmlOperations();
                        x.Save(createdP);
                        createFlag = true;
                        break;
                    // Load an existing from XML file
                    case 2:
                        var idToLoad = WriteToConsole.PersonLoad();
                        XmlOperations xx = new XmlOperations();
                        loadedHuman = xx.Load(idToLoad);
                        loadedP = loadedP.Configure(loadedHuman, loadedP);
                        loadFlag = true;

                        break;
                    // Exit
                    case 3:
                        WriteToConsole.Exit();
                        exitFlag = true;
                        break;
                    default:
                        WriteToConsole.PleaseChoose();
                        falseFlag = true;
                        break;
                }
                if (exitFlag == true)
                {
                    return 0;
                }
                if (falseFlag)
                {
                    return 1;
                }
                else
                    return 2;

            } while (createFlag == false && exitFlag == false && loadFlag == false);

        }


        public void Manage()
        {
            if (exitFlag == false)
            {
                do
                {
                    if (createFlag) { pToManage = createdP; }
                    else { pToManage = loadedP; }

                    WriteToConsole.PersonManage(pToManage);
                    bool success = Int32.TryParse(Console.ReadLine(), out inputFromManage);
                    switch (inputFromManage)
                    {
                        case 1:
                            WriteToConsole.ChooseAHobby(pToManage);
                            Int32.TryParse(Console.ReadLine(), out var choosedHobby);
                            choosedHobby = choosedHobby - 1;
                            pToManage.AssignHobby(choosedHobby);
                            break;
                        case 2:
                            WriteToConsole.GivePetName();
                            var petName = Console.ReadLine();
                            if (petName.Length > 0)
                            {
                                pToManage.GetAPet(pToManage, petName);
                            }
                            else
                            {
                                pToManage.GetAPet(pToManage);
                            }
                            break;
                        case 3:
                            var foodGiven = WriteToConsole.GiveFoodToThePoorMan();
                            string[] food = new string[20];
                            food = foodGiven.Split(',').ToArray();
                            pToManage.GiveFood(food);
                            break;
                        default:
                            break;
                    }


                } while (inputFromManage != 9);

            }


        }


    }
}
