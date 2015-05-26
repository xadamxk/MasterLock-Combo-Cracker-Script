/* Purpose: To produce possible combinations based on a series of inputs.
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
using System.Linq;

namespace MasterLock_Combo_Cracker
{
    class ComboCrackerClass
    {
        // Constants
        private const int constant1 = 4;
        private const int constant2 = 10;
        private const int constant3 = 2;

        // Data Fields
        private int input1;
        private int input2;
        private double input3;
        private int input4;
        private int input4check;
        private double combo1;
        private double check1;
        private double[] combo2Array;
        private double[] combo2ArrayAll1;
        private double[] combo2ArrayAll2;
        private double[] combo2ArrayAll3;
        private double[] combo2ArrayAll4;
        private double[] combo3Array;

        // Properties
        public int Input1 { get; set; }
        public int Input2 { get; set; }
        public int Input3 { get; set; }
        public int Input4 { get; set; }
        public int Input4check { get; set; }
        public double Check1 { get; set; }
        public double Combo1 { get; set; }
        public double[] Combo2Array { get; set; }
        public double[] Combo2ArrayAll1 { get; set; }
        public double[] Combo2ArrayAll2 { get; set; }
        public double[] Combo2ArrayAll3 { get; set; }
        public double[] Combo2ArrayAll4 { get; set; }
        public double[] Combo3Array { get; set; }

        // Constructors
            // Default
        public ComboCrackerClass()
        {
            
        }
            // Containing inputs
        public ComboCrackerClass(int i1, int i2, double i3)
        {
            input1 = i1;
            input2 = i2;
            input3 = i3;
            CalculateCombo1();
            CalculateCheck1();
            CalculateCombo3();
            NarrowCombo3(out input4check, out input4);
            CalculateCombo2(out combo2Array);
            CalculateCombo2All(out combo2ArrayAll1, out combo2ArrayAll2, out combo2ArrayAll3, out combo2ArrayAll4);

        }

        // Methods
            // Calculate Combo 1
        public double CalculateCombo1()
        {
            combo1 = 0;
            combo1 = Convert.ToDouble(Math.Ceiling(input3) + 5)%(constant1*constant2);

            return combo1;
        }
            // Calculate Check 1
        public double CalculateCheck1()
        {
            check1 = combo1%constant1;
            return check1;
        }
            // Calculate Combo 3 Options
        public double[] CalculateCombo3()
        {
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

         combo3Array = combo3List.ToArray();

            return combo3Array;

        }
            // Narrow Possible Combo 3 Options
        public void NarrowCombo3(out int input4check, out int input4)
        {
            input4check = 0;

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
            string inputValue4 = "";
            inputValue4 = Console.ReadLine();

            // Reset Input 4
            input4 = 0;
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
                    NarrowCombo3(out input4check, out input4);
                }

                input4check = 2;
            }
        }
            // Calculate Combo 2 Options (selected)
        public void CalculateCombo2(out double[] combo2Array)
        {
            var combo2List = new List<double>();
            // Known Combo 3
            if (input4check == 2)
            {
                int y = input4 - 1;
                double x = combo3Array[y];
                

                for (int i = 0; i < constant2; i++)
                {
                    var temp = ((check1 + constant3)%constant1) + (constant1*i);

                    if (((x + constant3)%(constant1*constant2)) != temp &&
                        ((x - constant3)%(constant1*constant2)) != temp)
                    {
                            combo2List.Add(temp);
                    }
                }
            }
            combo2Array = combo2List.ToArray();


        }
            // Calculate Combo 2 Options (all)
        public void CalculateCombo2All(out double[] combo2ArrayAll1, out double[] combo2ArrayAll2, out double[] combo2ArrayAll3, out double[] combo2ArrayAll4)
        {
            var combo2ListAll1 = new List<double>();
            var combo2ListAll2 = new List<double>();
            var combo2ListAll3 = new List<double>();
            var combo2ListAll4 = new List<double>();

            // Unknown Combo 3
            if (input4check == 1)
            {

                for (int e = 0; e < combo3Array.Count(); e++)
                {
                    double c = combo3Array[e];
                    for (int i = 0; i < combo3Array[e]; i++)
                    {
                        double temp = ((check1 + constant3)%constant1) + (constant1*i);

                        if (((c + constant3)%(constant1*constant2)) != temp &&
                            ((c - constant3)%(constant1*constant2)) != temp)
                        {
                            if (temp < 40)
                            {
                                string tempString = temp.ToString();

                                if (tempString.Length < 2)
                                {
                                    tempString = "0" + temp;
                                    temp = Convert.ToDouble(tempString);
                                }

                                switch (e)
                                {
                                    case 0:
                                        combo2ListAll1.Add(temp);
                                        break;
                                    case 1:
                                        combo2ListAll2.Add(temp);
                                        break;
                                    case 2:
                                        combo2ListAll3.Add(temp);
                                        break;
                                    case 3:
                                        combo2ListAll4.Add(temp);
                                        break;
                                }
                            }
                        }

                    }

                }
            }
            combo2ArrayAll1 = combo2ListAll1.ToArray();
            combo2ArrayAll2 = combo2ListAll2.ToArray();
            combo2ArrayAll3 = combo2ListAll3.ToArray();
            combo2ArrayAll4 = combo2ListAll4.ToArray();
        }
            // Calculate Output
        public override string ToString()
        {
            string outputString = "";

            // Unknown Combo 3
            if (input4check == 1)
            {
                // Cycle combo 3 options
                for (int i = 0; i < combo3Array.Count(); i++)
                {
                    int counta = 0;

                    if (i == 0) // Option 1
                    {
                        for (int a = 0; a < combo2ArrayAll1.Count(); a++)
                        {
                            counta = a + 1;
                            outputString += counta + ").\t" + "( " + combo1.ToString().PadLeft(2, '0') + " , ";
                            outputString += combo2ArrayAll1[a].ToString().PadLeft(2, '0') + " , ";
                            outputString += combo3Array[i].ToString().PadLeft(2, '0') + " )";

                            if (((counta % 2) == 0))
                            {
                                outputString += "\n";
                            }
                            else
                            {
                                outputString += "\t";
                            } if ((a + 1) == combo2ArrayAll1.Count())
                            {
                                outputString += "\n";
                            }
                        }

                    }

                    int countb = combo2ArrayAll1.Count();

                    if (i == 1) // Option 2
                    {
                        for (int b = 0; b < combo2ArrayAll2.Count(); b++)
                        {
                            countb += 1;
                            outputString += countb + ").\t" + "( " + combo1.ToString().PadLeft(2, '0') + " , ";
                            outputString += combo2ArrayAll2[b].ToString().PadLeft(2, '0') + " , ";
                            outputString += combo3Array[i].ToString().PadLeft(2, '0') + " )";

                            if (((countb % 2) == 0))
                            {
                                outputString += "\n";
                            }
                            else
                            {
                                outputString += "\t";
                            }
                            if ((b + 1) == combo2ArrayAll2.Count())
                            {
                                outputString += "\n";
                            }


                        }
                    }

                    int countc = combo2ArrayAll1.Count() + combo2ArrayAll2.Count();

                    if (i == 2) // Option 3
                    {
                        for (int c = 0; c < combo2ArrayAll3.Count(); c++)
                        {
                            countc += 1;
                            outputString += countc + ").\t" + "( " + combo1.ToString().PadLeft(2, '0') + " , ";
                            outputString += combo2ArrayAll3[c].ToString().PadLeft(2, '0') + " , ";
                            outputString += combo3Array[i].ToString().PadLeft(2, '0') + " )";

                            if (((countc % 2) == 0))
                            {
                                outputString += "\n";
                            }
                            else
                            {
                                outputString += "\t";
                            }
                            if ((c + 1) == combo2ArrayAll3.Count())
                            {
                                outputString += "\n";
                            }
                        }
                    }

                    int countd = combo2ArrayAll1.Count() + combo2ArrayAll2.Count() + combo2ArrayAll3.Count();

                    if (i == 3) // Option 4
                    {
                        for (int d = 0; d < combo2ArrayAll4.Count(); d++)
                        {
                            countd += 1;
                            outputString += countd + ").\t" + "( " + combo1.ToString().PadLeft(2, '0') + " , ";
                            outputString += combo2ArrayAll4[d].ToString().PadLeft(2, '0') + " , ";
                            outputString += combo3Array[i].ToString().PadLeft(2, '0') + " )";

                            if (((countd % 2) == 0))
                            {
                                outputString += "\n";
                            }
                            else
                            {
                                outputString += "\t";
                            }
                            if ((d + 1) == combo2ArrayAll4.Count())
                            {
                                outputString += "\n";
                            }
                        }
                    }
                }


            }
            // Known Combo 3
            if (input4check == 2)
            {
                for (int i = 0; i < combo2Array.Count(); i++)
                {
                    int count = i + 1;
                    int indexcombo2 = input4 - 1;
                    outputString += count + ").\t" + "( " + combo1.ToString().PadLeft(2, '0') + " , ";
                    outputString += combo2Array[i].ToString().PadLeft(2, '0') + " , ";
                    outputString += combo3Array[indexcombo2].ToString().PadLeft(2, '0') + " )";

                    if (((count % 2) == 0))
                    {
                        outputString += "\n";
                    }
                    else
                    {
                        outputString += "\t";
                    }

                }

            }

            return outputString;
        }
    }
}
