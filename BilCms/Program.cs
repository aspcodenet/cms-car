using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilCms
{
    class Program
    {
        static Car CreateCar()
        {
            string make = "",model="";
            string priceInput = "";
            decimal price = 0;
            do
            {
                if(make.Length == 0)
                {
                    Console.Write("Make:");
                    make = Console.ReadLine();
                }
                if (model.Length == 0)
                {
                    Console.Write("Model:");
                    model = Console.ReadLine();
                }
                if (priceInput.Length == 0)
                {
                    Console.Write("Price:");
                    priceInput = Console.ReadLine();
                    if (decimal.TryParse(priceInput, out price) == false)
                        priceInput = "";
                }

            } while (make.Length == 0 || model.Length == 0 || priceInput.Length == 0);
            var car = new Car();
            car.Make = make;
            car.Model = model;
            car.Price = price;
            return car;
        }

        static void Main(string[] args)
        {
            var allaBilar = new List<Car>();

            while(true)
            {
                Console.WriteLine("Meny");
                Console.WriteLine("1. New car to sale");
                Console.WriteLine("2. List all cars");
                Console.WriteLine("3. Update car");
                Console.WriteLine("4. Delete car");
                Console.WriteLine("5. Search car");
                int sel = Convert.ToInt32(Console.ReadLine());
                if(sel == 1)
                {
                    var car = CreateCar();
                    allaBilar.Add(car);
                }
                else if(sel == 2)
                {
                    ListCars(allaBilar,
                        " ***Cars for sale ***") ;
                }
                else if (sel == 3)
                {
                    var car = SelectACar(allaBilar);
                    UpdateCar(car);
                }
                else if (sel == 4)
                {
                    var car = SelectACar(allaBilar);
                    allaBilar.Remove(car);
                }
                else if (sel == 5)
                {
                    SearchCar(allaBilar);
                }
            }


        }

        private static void SearchCar(List<Car> allaBilar)
        {
            Console.WriteLine("*** Search car ***");
            Console.Write("Search for");
            string input = Console.ReadLine().ToLower();
            var searchResultList = new List<Car>();

            foreach(var car in allaBilar)
            {
                if (car.Make.ToLower().Contains(input) ||
                    car.Model.ToLower().Contains(input))
                    searchResultList.Add(car);
            }
            ListCars(searchResultList, $"Search result - searching for {input}");

        }

        private static void UpdateCar(Car car)
        {
            Console.WriteLine("*** Update car ***");
            Console.WriteLine("Leave blank if not updating");
            Console.WriteLine($"Make (existing:{car.Make})");
            string make = Console.ReadLine();
            Console.WriteLine($"Model (existing:{car.Model})");
            string model = Console.ReadLine();
            Console.WriteLine($"Model (existing:{car.Price})");
            string priceInput = Console.ReadLine();

            if (make != "") car.Make = make;
            if (model != "") car.Model = model;
            if (priceInput != "") car.Price = Convert.ToDecimal(priceInput);
        }

        private static Car SelectACar(List<Car> allaBilar)
        {
            Console.WriteLine("*** Select a car ***");
            int index = 0;
            foreach (var car in allaBilar)
            {
                Console.WriteLine($"{index+1}: {car.Make} {car.Model} costs {car.Price}");
                index++;
            }
            Console.WriteLine("Select a car by its number");
            int selectedCar = Convert.ToInt32(Console.ReadLine());
            return allaBilar[selectedCar-1];
        }


        private static void ListCars(List<Car> allaBilar,
            string text)
        {
            Console.WriteLine(text);
            foreach(var car in allaBilar)
            {
                Console.WriteLine($"{car.Make} {car.Model} costs {car.Price}");
            }
        }
    }
}
