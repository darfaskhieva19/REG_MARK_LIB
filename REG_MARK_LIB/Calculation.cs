using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class Calculation
    {
        public static List<char> symbol = new List<char>() { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X' };
        public static bool CheckMark(String mark) //Правильность номерного знака
        {
            try
            {
                Regex regex = new Regex("^[ABEKMHOPCTYX]{1}[0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{3}");
                bool a = regex.IsMatch(mark);
                if (a)
                {
                    string registrNumber = mark.Substring(1, mark.Length - 6);
                    string registCode = mark.Substring(mark.Length - 3);
                    if(registCode == "000" || registrNumber == "000")
                    {
                        return false;
                    }
                    else
                    {
                        return true
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public string GetNextMarkAfter(String mark) //Выдаёт следующий знак в данной серии или создает следующую серию
        {

        }
        public string GetNextMarkAfterInRange(String prevMark, String rangeStart, String rangeEnd) //Выдаёт следующий номер
        {

        }
        public int GetCombinationsCountInRange(String mark1, String mark2) //Расчёт оставшихся свободных номеров для региона
        {

        }
    }
}
