using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise01
{
    public static class Exercise1
    {
        public static string Towards(this UInt64 numberVariable)
        {
            string isNegative = "";
            try
            {
                string number = numberVariable.ToString();
                number = Convert.ToDouble(number).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1, number.Length - 1);
                }
                if (number == "0")
                {
                    return "\nZero";
                }
                else
                {
                    string numberInWords = "\n " + isNegative + ConvertToWords(number);
                    return numberInWords;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        private static String ConvertToWords(string numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToUInt64(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents  
                        endStr = " " + endStr;//Cents  
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        private static string ConvertDecimals(string points)
        {
            throw new NotImplementedException();
        }

        private static string ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;

                        case 13:
                        case 14:
                        case 15:

                            pos = (numDigits % 13) + 1;
                            place = " Trillion ";
                    }



                    static void Main(string[] args)
                    {
                        string isNegative = "";
                        try
                        {
                            Console.WriteLine("Please Enter Number to convert to words");
                            string number = Console.ReadLine();
                            number = Convert.ToDouble(number).ToString();

                            if (number.Contains("-"))
                            {
                                isNegative = "Minus ";
                                number = number.Substring(1, number.Length - 1);
                            }
                            if (number == "0")
                            {
                                Console.WriteLine("The number fomat is \nZero Only");
                            }
                            else
                            {
                                Console.WriteLine("The number fomat is \n{0}", isNegative + ConvertToWords(number));
                            }
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

            }
    }
    }
}

