using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(0 > 1000000);
                // Создание компании (свойства только для записи устанавливаются через конструктор)
                var company = new CargoCompany("ГрузЭкспресс", 10000);
                var company2 = new CargoCompany("ГрузЭкспресс2");
                Console.WriteLine($"Имя компании: {company.CompanyName}");

                // Добавление перевезенных грузов
                company.AddTransportation(10.5m);
                company.AddTransportation(25.3m);
                company.AddTransportation(15.7m);
                company2.AddTransportation(123);
                company2.AddTransportation(234);
                company2.AddTransportation(345);

                // Вывод информации
                Console.WriteLine(company.GetCompanyInfo());
                Console.WriteLine();
                Console.WriteLine(company2.GetCompanyInfo());
                Console.WriteLine();


                // Демонстрация расчета выручки
                Console.WriteLine($"Выручка за последнюю перевозку: {15.7m * company.PricePerTon:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}