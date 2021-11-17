using System;
using System.Collections.Generic;

namespace DOBTOWORD
{
    class DTWConverter
    {
        private static readonly Dictionary<int, string> NumbersToWords = new Dictionary<int, string>()
        {
            { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" },
            { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }, { 20, "Twenty" },
            { 21, "Twenty One" }, { 22, "Twenty Two" }, { 23, "Twenty Three" }, { 24, "Twenty Four" }, { 25, "Twenty Five" }, { 26, "Twenty Six" }, { 27, "Twenty Seven"  }, { 28, "Twenty Eight" }, { 29, "Twenty Nine" }, { 30, "Thirty" },
            { 31, "Thirty One" }, { 32, "Thirty Two" }, { 33, "Thirty Three" }, { 34, "Thirty Four" }, { 35, "Thirty Five" }, { 36, "Thirty Six" }, { 37, "Thirty Seven"  }, { 38, "Thirty Eight" }, { 39, "Thirty Nine" }, { 40, "Fourty" },
            { 41, "Fourty One" }, { 42, "Fourty Two" }, { 43, "Fourty Three" }, { 44, "Fourty Four" }, { 45, "Fourty Five" }, { 46, "Fourty Six" }, { 47, "Fourty Seven"  }, { 48, "Fourty Eight" }, { 49, "Fourty Nine" }, { 50, "Fifty" },
            { 51, "Fifty One" }, { 52, "Fifty Two" }, { 53, "Fifty Three" }, { 54, "Fifty Four" }, { 55, "Fifty Five" }, { 56, "Fifty Six" }, { 57, "Fifty Seven"  }, { 58, "Fifty Eight" }, { 59, "Fifty Nine" }, { 60, "Sixty" },
            { 61, "Sixty One" }, { 62, "Sixty Two" }, { 63, "Sixty Three" }, { 64, "Sixty Four" }, { 65, "Sixty Five" }, { 66, "Sixty Six" }, { 67, "Sixty Seven"  }, { 68, "Sixty Eight" }, { 69, "Sixty Nine" }, { 70, "Seventy" },
            { 71, "Seventy One" }, { 72, "Seventy Two" }, { 73, "Seventy Three" }, { 74, "Seventy Four" }, { 75, "Seventy Five" }, { 76, "Seventy Six" }, { 77, "Seventy Seven"  }, { 78, "Seventy Eight" }, { 79, "Seventy Nine" }, { 80, "Eighty" },
            { 81, "Eighty One" }, { 82, "Eighty Two" }, { 83, "Eighty Three" }, { 84, "Eighty Four" }, { 85, "Fourty Five" }, { 86, "Eighty Six" }, { 87, "Eighty Seven"  }, { 88, "Eighty Eight" }, { 89, "Eighty Nine" }, { 90, "Ninty" },
            { 91, "Ninty One" }, { 92, "Ninty Two" }, { 93, "Ninty Three" }, { 94, "Ninty Four" }, { 95, "Ninty Five" }, { 96, "Ninty Six" }, { 97, "Ninty Seven"  }, { 98, "Ninty Eight" }, { 99, "Ninty Nine" }
        };

        private static string GetNumberToWord(int number)
        {
            if (number > 0)
                return NumbersToWords[number];
            else
                return null;
        }

        private static string GetYearInWord(string year)
        {
            string returnValue = string.Empty;
            int y = int.Parse(year);
            if(y > 0)
            {
                if(year[1] == '0' && year[2] == '0')
                {
                    returnValue += GetNumberToWord(int.Parse(year[0].ToString()));
                    if (year[3] == '0')
                        returnValue += " Thousand";
                    else
                        returnValue += " Thousand " + GetNumberToWord(int.Parse(year[3].ToString()));
                }
                else if(year[1] == '0' && year[2] != '0')
                {
                    returnValue += GetNumberToWord(int.Parse(year[0].ToString()));
                    returnValue += " Thousand " + GetNumberToWord(int.Parse(year.Substring(2)));
                }
                else
                {
                    returnValue += GetNumberToWord(int.Parse(year.Substring(0, 2)));
                    returnValue += " " + GetNumberToWord(int.Parse(year.Substring(2)));
                }
            }
            return returnValue;
        }

        public static string ConvertDOBToWord(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return GetNumberToWord(dt.Day) + " " + dt.ToString("MMMM") + " " + GetYearInWord(dt.Year.ToString());
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
