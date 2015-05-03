/* Purpose: To provide a list of possible combos for MasterLock Padlocks,
 * by using 3 inputs given by the user.
 * 
 * Dev: Adam K
 * Date: 5/3/2015
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
using System.Linq;


// ReSharper disable CompareOfFloatsByEqualityOperator

namespace MasterLock_Combo_Cracker
{
    class MasterLockComboCracker
    {

        private static double firstInput;
        private static double secondInput;
        private static double thirdInput;
        private static double[] array3out;
        private static double[] array2out;
        private static int array3index;
        private static double var1out;

        static void Main()
        {

            // Variables
            char newValue = 'Y';

            do
            {
                
            // Instructions
            DisplayInstructions();

            // Inputs
            GetFirstInput(out firstInput);
            GetSecondInput(out secondInput);
            GetThirdInput(out thirdInput);

            // Calculations
            CalculateVar1(out var1out);
            CalculateVar3(out array3out);
            GetReplyforVar2(out array3index);
            CalculateVar2(out array2out);

            // Output
            CalculateOutput();
            Console.ReadKey();

            // Run Again Instructions
            RunAgainInstructions();

            var inputValue = Console.ReadLine();
            if (char.TryParse(inputValue, out newValue) == false)
            {
                ;
            }
            }
            while ((newValue) == 'Y' || (newValue) == 'y');

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

        public static void GetFirstInput(out double output) // I1
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
            var inputValue = Console.ReadLine();

            var input1 = Convert.ToInt32(inputValue);
            output = input1;
        }

        public static void GetSecondInput(out double output) // I2
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
            var inputValue = Console.ReadLine();

            var input2 = Convert.ToInt32(inputValue);
            output = input2;
        }

        public static void GetThirdInput(out double output) // rl
        {
            Console.Clear();
            Console.WriteLine("\t\t\tResistant Location\n");
            Console.WriteLine("- Apply less pressure on the shackle as you did before (about half),\n\tso the dial can turn and not get locked in place.\n");
            Console.WriteLine("- This time, turn the dial to the right (toward 30), until you feel resistance.");
            Console.WriteLine("- Note the value with 1 decimal place if needed,\n\t where the resistence begins to happen (ie 14.5).\n");
            Console.WriteLine("- Rotate the dial several more times to ensure that the recorded value is,\n\t the exact resistence location.\n");
            Console.Write("Resistant Location: ");
            var inputValue = Console.ReadLine();

            var input3 = Convert.ToDouble(inputValue);
            output = input3;
        }

        public static void CalculateVar1(out double output)
        {
            var result = Convert.ToDouble((Math.Ceiling(thirdInput) + 5)) % 40;
            output = result;

        }

        public static void CalculateVar3(out double[] array3out)
        {
            var mod = var1out % 4;
            var input1 = firstInput;
            var input2 = secondInput;
            var var3 = new List<double>();


            for (var i = 0; i < 4; i++)
            {
                if ((((10 * i) + input1) % 4) == mod)
                {
                    var3.Add((10*i) + input1);
                }

                if ((((10 * i) + input2) % 4) == mod)
                {
                    var3.Add((10 * i) + input2);
                }
            }
            array3out = var3.ToArray();

        }

        public static void GetReplyforVar2(out int array3index)
        {
            int replyIndex;
            string inputValue = "";

            Console.Clear();
            Console.WriteLine("\t\t\tFinding the 'Correct' 3rd Digit\n");
            Console.WriteLine("- Set the dial to the 1st possibility for the '3rd Digit'");
            Console.WriteLine("- Apply full pressure upward on the shackle, as if you are opening it.");
            Console.WriteLine("- Turn the dial and note how much give there is,\n\twhether it be a half a number or 2 full numbers worth.\n");
            Console.WriteLine("- Loosen the shackle and set the dial to the next value for the '3rd Digit'.");
            Console.WriteLine("- Apply full pressure upward again,\n\t and note the ammount of give for the 2nd 3rd Digit possibility.\n");
            Console.WriteLine("- Whichever option has a greater give, use that option (1 or 2 usually)");
            Console.WriteLine("Calculations show that there are multiple options for combo#3:\n");

            for (var i = 0; i < array3out.Count(); i++)
            {
                Console.Write("Possibility {0}:\t", i+1);
                Console.Write(array3out[i] + "\t\n");
            }
            Console.Write("\nWhich possibility has a greater give (1,2, etc): ");
            inputValue = Console.ReadLine();
            if (int.TryParse(inputValue, out replyIndex) == false)
            {
                Console.WriteLine("Invalid Input!");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
                GetReplyforVar2(out array3index);
            }
            array3index = replyIndex;
        }

        public static void CalculateVar2(out double[] array2out)
        {
            var mod = var1out % 4;
            var input3 = thirdInput;
            var y = array3index - 1;
            var x = array3out[y];
            var var2 = new List<double>();

            for (var i = 0; i < 10; i++)
            {
                var temp = ((mod + 2)%4) + (4*i);

                if (((x + 2) % 40 != temp && (x - 2) % 40 != temp))
                {
                  var2.Add(temp);  
                }

            }
            array2out = var2.ToArray();

        }

        public static string CalculateOutput()
        {
            var output1 = var1out;
            var output3 = array3out[array3index - 1];
            string outputString = "";

            for (int i = 0; i < array2out.Count(); i++)
            {
                var count = i + 1;
                outputString += count + ").\t" + "( " + output1 + " , ";
                outputString += array2out[i] + " , ";
                outputString += output3 + " )\n";
            }

            Console.Clear();
            Console.WriteLine("\t\t\tPossible Combination List\n");
            Console.WriteLine("\nBelow is a list of possible combinations for your lock:\n");
            Console.WriteLine("#).\t(Combo)");
            Console.WriteLine(outputString);
            return outputString;
        }

        public static void RunAgainInstructions()
        {
            Console.WriteLine("\nWould you like to run the program again?");
            Console.WriteLine("If so, please type \"Y\".");
        }

    }
}
