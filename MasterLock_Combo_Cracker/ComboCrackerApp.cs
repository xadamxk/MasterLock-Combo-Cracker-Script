/* Purpose: To provide a list of possible combos for MasterLock Padlocks,
 * by using 3 inputs given by the user.
 * 
 * Dev: Adam K
 * Date: 5/8/2015
 * 
 * Credit: Credit to Samy Kamkar for figuring out the formula used.
 * Along with a special thanks to Nikey for helping me out.
 * 
 * Additional Notes: I'm new to C# and took this project on as a starter.
 * If you use this application, great, if you want to provide criticism, please make it constructive.
 * Thank you.
 */
using System;

namespace MasterLock_Combo_Cracker
{
    internal class ComboCrackerApp
    {
        private static void Main()
        {
            // Instructions
            DisplayInstructions();

            // Inputs
            int input1 = GetInput1();
            int input2 = GetInput2();
            double input3 = GetInput3();

            // Instantiate
            ComboCrackerClass instance1 = new ComboCrackerClass(input1, input2, input3);

            // Output
            Console.Clear();
            Console.WriteLine("\t\t\tPossible Combination List\n");
            Console.WriteLine("\nBelow is a list of possible combinations for your lock:\n");
            Console.WriteLine("#).\t(Combo)");
            Console.WriteLine(instance1);
            Console.ReadKey();

            // Loop Program
            LoopProgramInstructions();
            LoopProgram();


        }

        public static void DisplayInstructions()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tMasterLock Combo Cracker\n");
            Console.WriteLine("This application uses an algorithm found by 'Samy Kamkar',\n\tto predict (8) possible combos for MasterLock Padlocks.\n");
            Console.WriteLine("In order to predict these combinations, 3 inputs are needed.");
            Console.WriteLine("\t- First Locked Position");
            Console.WriteLine("\t- Second Locked Position");
            Console.WriteLine("\t- Resistance Location\n");
            Console.WriteLine("What these values are and how to find them will be defined as they are needed.");
            Console.WriteLine("\nPress any key to start the elimination process...");
            Console.ReadKey();
        }

        // Input 1
        public static int GetInput1()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tFirst Locked Position\n");
            Console.WriteLine("- Set the dial to 0.");
            Console.WriteLine("- Apply pressure upward on the shackle, like you are opening it.");
            Console.WriteLine("- Rotate the dial left (toward 5), until the dial feels locked in place.");
            Console.WriteLine("- You will be unable to turn at a certain number, but this value is irrelevant.");
            Console.WriteLine("- Skip this number (that it got locked at), by releasing pressure on the shackle\tand turn the dial enough to get past the value.\n");
            Console.WriteLine("- Again, apply pressure on the shackle, continue to turn left until you can't.");
            Console.WriteLine("- If you are stopped between two halfs (5.5 - 6.5), use the value between (6).");
            Console.WriteLine("- Remember, this value shouldn't be the 1st locked position,\n\t since we skipped it, it should be the 2nd.\n");
            Console.Write("First Locked Position: ");

            string inputValue1 = "";
            inputValue1 = Console.ReadLine();

            // Reset input1
            int input1 = 0;
            // Check input1 for int
            if (int.TryParse(inputValue1, out input1))
            {
                // Check input1 length
                if (input1.ToString().Length > 2)
                {
                    Console.WriteLine("\n{0} is too large of a number.", input1);
                    Console.WriteLine("Input values should be 2 digits or smaller.");
                    Console.WriteLine("Press any key to return to the input menu...");
                    Console.ReadKey();
                    GetInput1();
                }
                // Check input1 for max
                if (input1 > 11)
                {
                    Console.WriteLine("\n{0} is too large for an input.", input1);
                    Console.WriteLine("This input should be below 11.");
                    Console.WriteLine("Try the process over, incase you missed a value.");
                    Console.ReadKey();
                    GetInput1();
                }
            }
            else
            {
                Console.WriteLine("\n{0} is an invalid input.", inputValue1);
                Console.WriteLine("Inputs should be integer values.");
                Console.WriteLine("Press any key to return to the input menu...");
                Console.ReadKey();
                GetInput1();
            }

            return input1;
        }

        // Input 2
        public static int GetInput2()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tSecond Locked Position\n");
            Console.WriteLine("- Continue where you left off previously, from the recorded locked position.");
            Console.WriteLine("- Put pressure upward on the shackle, and turn the dial, \n\tuntil the next locked position.\n");
            Console.WriteLine("- If you are stopped on a whole number, record that value.");
            Console.WriteLine("- If you are stopped between two halfs (8.5 - 9.5) use the value between (9).");
            Console.WriteLine("- Remember, this value shouldn't be the 2nd locked position, since we\n\talready recorded that (and skipped the 1st), it should be the 3rd.\n");
            Console.WriteLine("- If this value is greater than 11, you missed a value,\n\t so you need to restart this process and re-record the values.\n");
            Console.Write("Second Locked Position: ");

            string inputValue2 = "";
            inputValue2 = Console.ReadLine();

            // Reset input2
            int input2 = 0;
            // Check input2 for int
            if (int.TryParse(inputValue2, out input2))
            {
                // Check input2 length
                if (input2.ToString().Length > 2)
                {
                    Console.WriteLine("\n{0} is too large of a number.", input2);
                    Console.WriteLine("Input values should be 2 digits or smaller.");
                    Console.WriteLine("Press any key to return to the input menu...");
                    Console.ReadKey();
                    GetInput2();
                }
                // Check input2 for max
                if (input2 > 11)
                {
                    Console.WriteLine("\n{0} is too large for an input.", input2);
                    Console.WriteLine("This input should be below 11.");
                    Console.WriteLine("Try the process over, incase you missed a value.");
                    Console.ReadKey();
                    GetInput2();
                }
            }
            else
            {
                Console.WriteLine("\n{0} is an invalid input.", inputValue2);
                Console.WriteLine("Inputs should be integer values.");
                Console.WriteLine("Press any key to return to the input menu...");
                Console.ReadKey();
                GetInput2();
            }
            return input2;
        }
        // Input 3
        public static double GetInput3()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tResistant Location\n");
            Console.WriteLine("- Apply less pressure on the shackle as you did before (about half),\n\tso the dial can turn and not get locked in place.\n");
            Console.WriteLine("- This time, turn the dial to the right (toward 30), until you feel resistance.");
            Console.WriteLine("- Note the value with 1 decimal place if needed,\n\t where the resistence begins to happen (ie 14.5).\n");
            Console.WriteLine("- Rotate the dial several more times to ensure that the recorded value is,\n\t the exact resistence location.\n");
            Console.Write("Resistant Location: ");

            string inputValue3 = "";
            inputValue3 = Console.ReadLine();

            // Reset input3
            double input3 = 0;
            // Check input3 for double
            if (double.TryParse(inputValue3, out input3))
            {
                // Check input2 length
                if (input3.ToString().Length > 4)
                {
                    Console.WriteLine("\n{0} is too large of a number.", input3);
                    Console.WriteLine("Input values should be 3 digits or smaller (ie 14.5).");
                    Console.WriteLine("Press any key to return to the input menu...");
                    Console.ReadKey();
                    GetInput3();
                }
            }
            else
            {
                Console.WriteLine("\n{0} is an invalid input.", inputValue3);
                Console.WriteLine("Inputs should be decimal values (ie 14.5 or 16.0).");
                Console.WriteLine("Press any key to return to the input menu...");
                Console.ReadKey();
                GetInput3();
            }
            return input3;
        }

        public static void LoopProgramInstructions()
        {
            Console.WriteLine("\nWould you like to run the program again?");
            Console.WriteLine("If so, please type \"Y\".");
        }

        public static void LoopProgram()
        {
            var inputValue5 = Console.ReadLine();
            char loopProgram = 'Y';
            // Check inputValue5 for char
            if (char.TryParse(inputValue5, out loopProgram) == false)
            {
                ;
            }
            // Check loopProgram for yes
            if (loopProgram == 'y' || loopProgram == 'Y')
            {
                Console.Clear();
                Main();
            }

        }

    }
}
