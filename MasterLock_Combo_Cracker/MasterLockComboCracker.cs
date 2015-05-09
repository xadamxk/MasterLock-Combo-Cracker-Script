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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterLock_Combo_Cracker
{
    class MasterLockComboCracker
    {
        static void Main()
        {
            // Constants
            const int constant1 = 4;
            const int constant2 = 10;
            const int constant3 = 2;

            // Variables

            // Instructions
            Start:
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

            // Input 1
            Input1:
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
            var inputValue1 = "";
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
                    goto Input1;
                }
                // Check input1 for max
                if (input1 > 11)
                {
                    Console.WriteLine("\n{0} is too large for an input.", input1);
                    Console.WriteLine("This input should be below 11.");
                    Console.WriteLine("Try the process over, incase you missed a value.");
                    Console.ReadKey();
                    goto Input1;
                }
            }
            else
            {
                Console.WriteLine("\n{0} is an invalid input.",inputValue1);
                Console.WriteLine("Inputs should be integer values.");
                Console.WriteLine("Press any key to return to the input menu...");
                Console.ReadKey();
                goto Input1;
            }

            // Input 2
            Input2:
            Console.Clear();
            Console.WriteLine("\t\t\tSecond Locked Position\n");
            Console.WriteLine("- Continue where you left off previously, from the recorded locked position.");
            Console.WriteLine("- Put pressure upward on the shackle, and turn the dial, \n\tuntil the next locked position.\n");
            Console.WriteLine("- If you are stopped on a whole number, record that value.");
            Console.WriteLine("- If you are stopped between two halfs (8.5 - 9.5) use the value between (9).");
            Console.WriteLine("- Remember, this value shouldn't be the 2nd locked position, since we\n\talready recorded that (and skipped the 1st), it should be the 3rd.\n");
            Console.WriteLine("- If this value is greater than 11, you missed a value,\n\t so you need to restart this process and re-record the values.\n");
            Console.Write("Second Locked Position: ");
            var inputValue2 = "";
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
                    goto Input2;
                }
                // Check input2 for max
                if (input2 > 11)
                {
                    Console.WriteLine("\n{0} is too large for an input.",input2);
                    Console.WriteLine("This input should be below 11.");
                    Console.WriteLine("Try the process over, incase you missed a value.");
                    Console.ReadKey();
                    goto Input2;
                }
            }
            else
            {
                Console.WriteLine("\n{0} is an invalid input.", inputValue2);
                Console.WriteLine("Inputs should be integer values.");
                Console.WriteLine("Press any key to return to the input menu...");
                Console.ReadKey();
                goto Input2;
            }

            // Input 3
            Input3:
            Console.Clear();
            Console.WriteLine("\t\t\tResistant Location\n");
            Console.WriteLine("- Apply less pressure on the shackle as you did before (about half),\n\tso the dial can turn and not get locked in place.\n");
            Console.WriteLine("- This time, turn the dial to the right (toward 30), until you feel resistance.");
            Console.WriteLine("- Note the value with 1 decimal place if needed,\n\t where the resistence begins to happen (ie 14.5).\n");
            Console.WriteLine("- Rotate the dial several more times to ensure that the recorded value is,\n\t the exact resistence location.\n");
            Console.Write("Resistant Location: ");
            var inputValue3 = "";
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
                    goto Input2;
                }
            }
            else
            {
                Console.WriteLine("\n{0} is an invalid input.", inputValue3);
                Console.WriteLine("Inputs should be decimal values (ie 14.5).");
                Console.WriteLine("Press any key to return to the input menu...");
                Console.ReadKey();
                goto Input3;
            }

            // Calculate Variable 1
            var combo1 = Convert.ToDouble(Math.Ceiling(input3) + 5) % (constant1 * constant2);

            // Calculate Variable 3
            var check1 = combo1 % constant1; // check 1 = mod
            var combo3List = new List<double>();

            for (int i = 0; i < constant1; i++)
            {
                if ((((constant2 * i) + input1) % constant1) == check1)
                {
                    combo3List.Add((constant2 * i) + input1);
                }

                if ((((constant2 * i) + input2) % constant1) == check1)
                {
                    combo3List.Add((constant2 * i) + input2);
                }
            }

            double[] combo3Array = combo3List.ToArray();

            // Narrow Combo3 Options
            Input4:
            var input4check = 0;
            Console.Clear();
            Console.WriteLine("\t\t\tFinding the 'Correct' 3rd Digit\n");
            Console.WriteLine("- Set the dial to the 1st possibility for the '3rd Digit'");
            Console.WriteLine("- Apply full pressure upward on the shackle, as if you are opening it.");
            Console.WriteLine("- Turn the dial and note how much give there is,\n\twhether it be a half a number or 2 full numbers worth.\n");
            Console.WriteLine("- Loosen the shackle and set the dial to the next value for the '3rd Digit'.");
            Console.WriteLine("- Apply full pressure upward again,\n\t and note the ammount of give for the 2nd 3rd Digit possibility.\n");
            Console.WriteLine("- Whichever option has a greater give, use that option (1 or 2 usually)");
            Console.WriteLine("Calculations show that there are multiple options for combo#3:\n");

            for (int i = 0; i < combo3Array.Count(); i++)
            {
                int combo3OptionsCount = i + 1;
                Console.Write("Possibility {0}: \t", combo3OptionsCount);
                Console.Write(combo3Array[i] + "\t\n");
            }
            Console.Write("Possibility a:\tNot Sure\n");

            Console.Write("\nWhich possibility has a greater give (1,2, etc, a): ");
            var inputValue4 = "";
            inputValue4 = Console.ReadLine();
            // Reset Input 4
            int input4 = 0;
            // Check input4 for all options
            if (inputValue4 == "a" || inputValue4 == "A")
            {
                input4check = 1;
            }
            // Check input4 for int
            else if (int.TryParse(inputValue4, out input4))
            {
                if (int.TryParse(inputValue4, out input4) == false)
                {
                    Console.WriteLine("\n{0} is an invalid input.", input4);
                    Console.WriteLine("Input values should be either:");
                    Console.WriteLine("\t- Integers");
                    Console.WriteLine("\t- or \"a\" if possibilities are unknown.");
                    Console.WriteLine("Press any key to return to the input menu...");
                    Console.ReadKey();
                    goto Input4;
                }

                input4check = 2;
            }

            switch (input4check)
            {
                case 1: goto CalculateComboAll;
                    break;
                case 2: goto CalculateCombo2;
                    break;
                default:
                    break;
            }

            // Calculate Combo 2
            CalculateCombo2:
            var y = input4 - 1;
            var x = combo3Array[y];
            var combo2List = new List<double>();

            for (int i = 0; i < constant2; i++)
            {
                var temp = ((check1 + constant3) % constant1) + (constant1 * i);

                if (((x + constant3) % (constant1*constant2)) != temp && ((x - constant3) % (constant1 * constant2)) != temp)
                {
                    combo2List.Add(temp);
                }
            }

            double[] combo2Array = combo2List.ToArray();

            // Calculate Output for known Combo3
            string outputString = "";

            if (input4check == 2)
            {

                for (int i = 0; i < combo2Array.Count(); i++)
                {
                    var count = i + 1;
                    var indexcombo2 = input4 - 1;
                    outputString += count + ").\t" + "( " + combo1 + " , ";
                    outputString += combo2Array[i] + " , ";
                    outputString += combo3Array[indexcombo2] + " )\n";
                }

                Console.Clear();
                Console.WriteLine("\t\t\tPossible Combination List\n");
                Console.WriteLine("\nBelow is a list of possible combinations for your lock:\n");
                Console.WriteLine("#).\t(Combo)");
                Console.WriteLine(outputString);
                goto LoopProgram;
            }

            // Calculate Unknown ComboAll
            CalculateComboAll:

            // Calculate Combo2All
            var combo2ListAll1 = new List<double>();
            var combo2ListAll2 = new List<double>();
            var combo2ListAll3 = new List<double>();
            var combo2ListAll4 = new List<double>();

            for (int b = 0; b < combo3Array.Count(); b++)
            {
                var c = combo3Array[b];

                for (int i = 0; i < constant2; i++)
                {
                    var temp = ((check1 + constant3)%constant1) + (constant1*i);

                    if (((c + constant3)%(constant1*constant2)) != temp &&
                        ((c - constant3)%(constant1*constant2)) != temp)
                    {
                        switch (b)
                        {
                            case 0: combo2ListAll1.Add(temp);
                                break;
                            case 1: combo2ListAll2.Add(temp);
                                break;
                            case 2: combo2ListAll3.Add(temp);
                                break;
                            case 3: combo2ListAll4.Add(temp);
                                break;
                        }
                    }

                }

            }
            double[] combo2ArrayAll1 = combo2ListAll1.ToArray();
            double[] combo2ArrayAll2 = combo2ListAll2.ToArray();
            double[] combo2ArrayAll3 = combo2ListAll3.ToArray();
            double[] combo2ArrayAll4 = combo2ListAll4.ToArray();

            // Calculate output for unknown combo 3







            // Loop Program
            LoopProgram:
            Console.WriteLine("\nWould you like to run the program again?");
            Console.WriteLine("If so, please type \"Y\".");
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
                goto Start;
            }

        }

    }
}
