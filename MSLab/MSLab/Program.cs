using System;
using System.Collections.Generic;

namespace MSLab
{
    class Program
    {

        static void Main(string[] args)
        {
            List<double> lstXCoordinates = new List<double>();
            List<double> lstYCoordinates = new List<double>();
            String strInput;
            bool validIn;

            Console.WriteLine("This program reformats coordinates. \nPlease enter as many as you would like to reformat (xx.xx, xx.xx). \n\nTo see the results, enter \"q\".");

            do
            {

                strInput = Console.ReadLine();
                validIn = ValidateInput(strInput);

                if (validIn)
                {
                    lstXCoordinates.Add(double.Parse(strInput.Split(',')[0].Trim()));
                    lstYCoordinates.Add(double.Parse(strInput.Split(',')[1].Trim()));

                }
            } while (validIn);

            List<String> lstFormatedCoordinates = ReformatCoordinates(lstXCoordinates, lstYCoordinates);

            Console.WriteLine("\n\n\n\n--- RESULTS ---\n\n");

            foreach (var coordinate in lstFormatedCoordinates)
            {
                Console.WriteLine(coordinate);
            }

            Console.WriteLine("\n\n\n\nPress Enter to Exit...");

            strInput = Console.ReadLine();
        }

        /// <summary>
        ///     Validates the input is a valid coordinate pair
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns>
        ///     True if valid
        ///     False if invalid
        /// </returns>
        public static bool ValidateInput(String strIn)
        {

            const double LatValue = 90;
            const double LonValue = 180;
            try
            {
                double d;
                if (
                    strIn.IndexOf(",") >= 0 
                    && double.TryParse(strIn.Split(',')[0], out d)
                    && Math.Abs(double.Parse(strIn.Split(',')[0].Trim())) <= LatValue
                    && double.TryParse(strIn.Split(',')[1], out d)
                    && Math.Abs(double.Parse(strIn.Split(',')[1].Trim())) <= LonValue
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        /// <summary>
        /// Formats the Coordinates onto one line in format: "x:aa.aa y:bb.bb"
        /// </summary>
        /// <param name="lstX"></param>
        /// <param name="lstY"></param>
        /// <returns>
        /// List of formated coordinate pairs
        /// OR
        /// Invalid coordinates message
        /// </returns>
        public static List<String> ReformatCoordinates(List<double> lstX, List<double> lstY)
        {
            List<String> lstResult = new List<String>();

            if (
                lstX.Count > 0
                && lstX.Count == lstY.Count
                )
            {
                for (int i = 0; i < lstX.Count; i++)
                {
                    if (!lstResult.Contains("x:" + lstX[i] + " y:" + lstY[i]))
                    {
                        lstResult.Add("x:" + lstX[i] + " y:" + lstY[i]);
                    }
                }

                return lstResult;
            }
            else
            {
                lstResult.Add("Please enter valid coordinates.");

                return lstResult;
            }
        }
    }
}
