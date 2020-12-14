using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    class Program
    {
        static void Main(string[] args)
        {
            // Displaying welcome screen
            int inputFromScreen;
            var leaveProgram = false;
            do
            {
                ScreenHandlingLogic Screen = new ScreenHandlingLogic();
                inputFromScreen = Screen.Welcome();      // 'leaveprogram' returns as 0 if user wants to exit
                if (inputFromScreen == 0)
                {
                    leaveProgram = true;
                }

                if (inputFromScreen != 0 && inputFromScreen != 1)
                {
                    Screen.Manage();
                }


            } while (leaveProgram == false);




        }
    }
}
