using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int val;
            try
            {
                while (true)
                {
                    Console.WriteLine("輸入數字(1-999999999)");
                    val = Convert.ToInt32(Console.ReadLine());



                    Console.WriteLine("輸入的數字: {0} \n 國字為: {1}", val, Delmuti10thousand(Delmutizero(ConvertLan2Dec(Getval(val)))));


                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
               
            }







        }
        public static string Getval(int val)
        {
            if (val < 1 || val > 999999999)
            {

                return "";
            }


            else
            {
                string valstr = val.ToString();
                string strch = valstr.Replace("0", "零").Replace("1", "壹")
                    .Replace("2", "貳").Replace("3", "參")
                    .Replace("4", "肆").Replace("5", "伍")
                    .Replace("6", "陸").Replace("7", "柒")
                    .Replace("8", "捌").Replace("9", "玖");
                return strch;
            }
        }
        static string ConvertLan2Dec(string str)
        {
            // 依據字串長度塞入對應的『拾』、『佰』、 ... 、『億』
            switch (str.Length)
            {
                case 1: return str;
                case 2: return str.Substring(0, 1) + "拾" + str.Substring(1);
                case 3: return str.Substring(0, 1) + "佰" + Delzero(str.Substring(1, 1), "拾") + str.Substring(2);
                case 4: return str.Substring(0, 1) + "仟" + Delzero(str.Substring(1, 1), "佰") + Delzero(str.Substring(2, 1), "拾") + str.Substring(3);
                case 5:
                    return str.Substring(0, 1) + "萬" + Delzero(str.Substring(1, 1), "仟") +
                    Delzero(str.Substring(2, 1), "佰") +
                    Delzero(str.Substring(3, 1), "拾") + str.Substring(4);
                case 6:
                    return str.Substring(0, 1) + "拾萬" + Delzero(str.Substring(1, 1), "萬") +
                   Delzero(str.Substring(2, 1), "仟") + Delzero(str.Substring(3, 1), "佰") +
                   Delzero(str.Substring(4, 1), "拾") + str.Substring(5);
                case 7:
                    return str.Substring(0, 1) + "佰萬" + Delzero(str.Substring(1, 1), "拾萬") +
                  Delzero(str.Substring(2, 1), "萬") + Delzero(str.Substring(3, 1), "仟") +
                  Delzero(str.Substring(4, 1), "佰") + Delzero(str.Substring(5, 1), "拾") + str.Substring(6);
                case 8:
                    return str.Substring(0, 1) + "仟萬" + Delzero(str.Substring(1, 1), "佰萬") +
                  Delzero(str.Substring(2, 1), "拾萬") + Delzero(str.Substring(3, 1), "萬") +
                  Delzero(str.Substring(4, 1), "仟") + Delzero(str.Substring(5, 1), "佰") +
                  Delzero(str.Substring(6, 1), "拾") + str.Substring(7);
                case 9:
                    return str.Substring(0, 1) + "億" + Delzero(str.Substring(1, 1), "仟萬") +
                    Delzero(str.Substring(2, 1), "佰萬") + Delzero(str.Substring(3, 1), "拾萬") +
                    Delzero(str.Substring(4, 1), "萬") +
                    Delzero(str.Substring(5, 1), "仟") +
                    Delzero(str.Substring(6, 1), "佰") +
                    Delzero(str.Substring(7, 1), "拾") + str.Substring(8);
                default: return "數字超出範圍";
            }
        }
        static string Delzero(string val, string ch)
        {
            return val.Equals("零") ? val : val + ch;
        }
        static string Delmutizero(string str)
        {
            return str.Replace("零零零零零零零零", "").Replace("零零零零零零零", "零").Replace("零零零零零零", "零").Replace("零零零零零", "零").Replace("零零零零", "零").Replace("零零零", "零").Replace("零零", "零");
        }
        static string Delmuti10thousand(string str)
        {
            //LinQ
            var query = from c in str.ToCharArray() where c == '萬' select c;
            while (query.Count() > 1)
            {
                    str = str.Replace("仟萬", "仟");
                    query = from c in str.ToCharArray() where c == '萬' select c;
                    if (query.Count() > 1)
                    {
                        str = str.Replace("佰萬", "佰");
                        query = from c in str.ToCharArray() where c == '萬' select c;
                        if (query.Count() > 1)
                        {
                            return str.Replace("拾萬", "拾");
                        }
                        else
                        {
                            return str;
                        }

                    }
                    else
                    {
                        return str;
                    }               
            }
            return str;
        }



    }
}

