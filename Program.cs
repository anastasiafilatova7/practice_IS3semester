using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;

namespace pisPractice1_13._10
{
    class Estate
    {
        public string Owner;
        public DateTime Date;
        public int Price;

        public Estate(string owner, DateTime date, int price)
        {
            Owner = owner;
            Date = date;
            Price = price; //или через this, Owner, Date
        }

        //для красоты, для качества кода
        public void Print_String()
        {
            Console.WriteLine("Создан объект недвижимости");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Дата постановки на учет: {Date:yyyy.MM.dd}");
            Console.WriteLine($"Ориентировочная стоимость: {Price}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, содержащую: Недвижимость: владелец (строка), дата постановки на учет, ориентировочная стоимость (целое число)");
            Console.WriteLine("Ведите строку по примеру: Недвижимость: \"Громов С.А.\" 2008.09.08 4000");
            //тру кэч  чтобы бесконечно пользователь мог вводить вариантов строки
            while (true)
            {
                try
                {
                    string User_str_Start = Console.ReadLine();
                    //^-начало строки, строгое условие с чего начинается строка
                    //* - любое, кроме то, что в []
                    string str_regex = @"^Недвижимость\:\s+""([А-Яа-я. ]+)""\s+(\d{4}\.\d{2}\.\d{2})\s+(\d+)$";//по скобкам определяет 1,2,3 и \s понимает, что пробел, разделение
                                                                                                               //проверка введенной пользователем строки на соответвие нашему регулярному выражению
                    Match regex = Regex.Match(User_str_Start, str_regex);

                    //чтобы сказать пользователю, что он неверно ввел строку
                    string owner_Program = regex.Groups[1].Value; //0-вся строка, а 1,2,3 - подходящее
                    string date_Program = regex.Groups[2].Value; //без времени
                    DateTime date_1Program = DateTime.ParseExact(date_Program, "yyyy.MM.dd", null);
                    string price_Program = regex.Groups[3].Value;
                    int price_1Program = Convert.ToInt32(price_Program);
                    Estate estate = new Estate(owner_Program, date_1Program, price_1Program);
                    estate.Print_String();
                    break;
                }
                catch
                {
                    Console.WriteLine("Строка введена неверно, не как в примере");
                    continue;
                }
            }
        }
    }
}
