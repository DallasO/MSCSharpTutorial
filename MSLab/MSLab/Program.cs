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

            Console.WriteLine("This program reformats coordinates. Please enter as many as you would like to reformat (xx.xx, xx.xx). To see the results, enter \"q\".");

            strInput = Console.ReadLine();

            do
            {
                validIn = ValidateInput(strInput);

                if (validIn)
                {
                    lstXCoordinates.Add(float.Parse(strInput.Split(',')[0]));
                    lstYCoordinates.Add(float.Parse(strInput.Split(',')[1]));

                }
            } while (validIn);

            List<String> lstFormatedCoordinates = ReformatCoordinates(lstXCoordinates, lstYCoordinates);

            foreach (var coordinate in lstFormatedCoordinates)
            {
                Console.WriteLine(coordinate);
            }
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
            try
            {
                double d;
                if (strIn.IndexOf(",") >= 0 && double.TryParse(strIn.Split(',')[0], out d) && double.TryParse(strIn.Split(',')[1], out d))
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

            if (lstX.Count == lstY.Count)
            {
                for (int i = 0; i <= lstX.Count; i++)
                {
                    lstResult.Add("x:" + lstX[i] + " y:" + lstY[i]);
                }

                return lstResult;
            }
            else
            {
                lstResult.Add("You did not enter a valid Coordinate.");

                return lstResult;
            }
        }
    }
}
