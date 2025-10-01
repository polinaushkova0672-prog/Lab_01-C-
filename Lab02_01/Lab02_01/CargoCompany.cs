using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_01
{
    public class CargoCompany
    {
        // Поля класса
        string _companyName;
        decimal _pricePerTon;
        decimal _totalWeightTransported;

        // Конструктор
        public CargoCompany(string companyName, decimal pricePerTon)
        {
            CompanyName = companyName;
            PricePerTon = pricePerTon;
            _totalWeightTransported = 0;
        }
        public CargoCompany(string companyName)
        {
            CompanyName = companyName;
            PricePerTon = 12345;
            _totalWeightTransported = 0;
        }

        // Свойство только для записи - Наименование фирмы
        public string CompanyName
        {
            get => _companyName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название компании не может быть пустым");
                _companyName = value;
            }
        }

        // Свойство только для записи - Цена за тонну
        public decimal PricePerTon
        {
            get => _pricePerTon;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Цена за тонну должна быть положительной");
                if (value > 1000000) // ВЕРХНЯЯ ГРАНИЦА
                    throw new ArgumentException("Цена за тонну не может превышать 1,000,000");
                _pricePerTon = value;
            }
        }

        // Свойство для чтения - Общая масса перевезенных грузов
        public decimal TotalWeightTransported => _totalWeightTransported;

        // Метод для добавления перевезенного груза
        public void AddTransportation(decimal weight)
        {
            if (weight <= 0)
                throw new ArgumentException("Вес груза должен быть положительным");

            _totalWeightTransported += weight;
        }

        // Метод для подсчета общей выручки
        public decimal CalculateTotalRevenue()
        {
            return _totalWeightTransported * _pricePerTon;
        }

        // Метод для получения информации о компании
        public string GetCompanyInfo()
        {
            return $"Компания: {CompanyName}\n" +
                   $"Цена за тонну: {PricePerTon:F2}\n" +
                   $"Перевезено грузов: {TotalWeightTransported:F2} тонн\n" +
                   $"Общая выручка: {CalculateTotalRevenue():F2}";
        }

        // Статический метод для создания компании с валидацией
        public static CargoCompany CreateCompany(string name, decimal price)
        {
            return new CargoCompany(name, price);
        }
    }
}
