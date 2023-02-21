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
        public static bool CheckMark(String mark) 
        {
            if (Regex.IsMatch(mark, "^[ABEKMHOPCTYX]{1}[0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{3}"))
            {
                return false;
            }
            else
            {
                string num = mark.Substring(1, mark.Length - 6);
                string kodReg = mark.Substring(mark.Length - 3);
                if (num == "000" || kodReg == "000")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static string GetNextMarkAfter(String mark) 
        {
            try
            {
                string Nmark = "";
                string num = mark.Substring(1, mark.Length - 6);
                if (num == "999")
                {
                    num = "001";
                    string seria = "" + mark[0] + mark[4] + mark[5];
                    if (seria[2] != symbol[symbol.Count - 1])
                    {
                        int indexSym = -1;
                        for (int i = 0; i < symbol.Count; i++)
                        {
                            if (symbol[i] == seria[2])
                            {
                                indexSym = i;
                            }
                        }
                        Nmark = "" + seria[2] + num + seria[1] + symbol[indexSym + 1] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                    }
                    else
                    {
                        if (seria[0] != symbol[symbol.Count - 1])
                        {
                            int indexSymbol = -1;
                            for (int i = 0; i < symbol.Count; i++)
                            {
                                if (symbol[i] == seria[0])
                                {
                                    indexSymbol = i;
                                }
                            }
                            Nmark = "" + symbol[indexSymbol + 1] + num + seria[1] + symbol[0] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                        }
                        else
                        {
                            if (seria[1] != symbol[symbol.Count - 1])
                            {
                                int indexSymbol = -1;
                                for (int i = 0; i < symbol.Count; i++)
                                {
                                    if (symbol[i] == seria[1])
                                    {
                                        indexSymbol = i;
                                    }
                                }
                                Nmark = "" + symbol[0] + num + symbol[indexSymbol + 1] + symbol[0] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                            }
                            else
                            {
                                Nmark = "Ошибка";
                            }
                        }
                    }
                }
                else
                {
                    num = string.Format("{0:D3}", Convert.ToInt32(num) + 1);
                    int j = 0;
                    for (int i = 0; i < mark.Length; i++)
                    {
                        if (i == 1 || i == 2 || i == 3)
                        {
                            Nmark += num[j];
                            j++;
                        }
                        else
                        {
                            Nmark += mark[i];
                        }
                    }
                }
                return Nmark;
            }           
            catch
            {
                return "Ошибка";
            }
        }
        public static string GetNextMarkAfterInRange(String prevMark, String rangeStart, String rangeEnd) //Выдаёт следующий номер
        {
            if(rangeStart == rangeEnd)
            {
                string result = GetNextMarkAfter(prevMark);
                if(result == rangeStart)
                {
                    return result;
                }
                else
                {
                    return "out of stock";
                }
            }
            else
            {
                List<string> list = new List<string>() { rangeStart, rangeEnd };
                list.Sort();

                if (list[0] == rangeEnd)
                {
                    return "out of stock";
                }
                else
                {
                    string res = rangeStart;
                    for (int i = 0; res != rangeEnd; i++)
                    {
                        res = GetNextMarkAfter(res);

                        if (res == prevMark && res != rangeEnd)
                        {
                            return GetNextMarkAfter(res);
                        }
                    }
                    return "out of stock";
                }
            }
        }
        public static int GetCombinationsCountInRange(String mark1, String mark2) //Расчёт оставшихся свободных номеров для региона
        {
            string kodReg = mark1.Substring(mark1.Length - 3);
            string KodRegion = mark1.Substring(mark1.Length - 3);
            if(kodReg != KodRegion)
            {
                return 0;
            }
            int k = 0;
            for(int i = 0; mark1 != mark2; i++)
            {
                mark1 = GetNextMarkAfter(mark1);
                k++;
            }
            return k;           
        }
    }
}
