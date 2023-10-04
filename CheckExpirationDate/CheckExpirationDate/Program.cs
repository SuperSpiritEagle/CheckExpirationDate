using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckExpirationDate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Work();
        }
    }

    class Warehouse
    {
        private List<Product> _products;
        private int _currentYear;

        public Warehouse()
        {
            _currentYear = 2010;
            _products = new List<Product>();
            _products.Add(new Product("Говяжья Тушёнка", 2002, 3));
            _products.Add(new Product("Свиная Тушёнка", 2003, 2));
            _products.Add(new Product("Куриная Тушёнка", 2001, 4));
            _products.Add(new Product("Утиная Тушёнка", 2005, 6));
            _products.Add(new Product("Гусиная Тушёнка", 2006, 5));
            _products.Add(new Product("Индюшиная Тушёнка", 2009, 4));
        }

        public void Work()
        {
            Console.WriteLine("Просроченные банки тушенки");
            ShowSpoiledProducts();
        }

        private void ShowSpoiledProducts()
        {
            _products = _products.Where(product => product.YearProduction + product.ShelfLife <= _currentYear).ToList();
            ShowProductsInfo(_products);
        }

        private void ShowProductsInfo(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                products[i].ShowProduct();
            }
        }
    }

    class Product
    {
        private string _name;

        public Product(string name, int yearProduction, int shelfLife)
        {
            _name = name;
            YearProduction = yearProduction;
            ShelfLife = shelfLife;
        }

        public int YearProduction { get; private set; }
        public int ShelfLife { get; private set; }

        public void ShowProduct()
        {
            Console.WriteLine($"Название: {_name}. Год производства: {YearProduction}. Срок годности: {ShelfLife} года.");
        }
    }
}
