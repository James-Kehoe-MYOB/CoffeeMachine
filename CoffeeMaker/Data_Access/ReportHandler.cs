using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoffeeMaker.Data_Access {
    public class ReportHandler {
        private List<MenuItem> orders = new List<MenuItem>();
        private JObject report;
        private string report_string;
        
        private static string date = $"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";
        private static string path = $"../../../Data/Reports/{date}.json";

        public void AddOrder(MenuItem order) {
            InitData();
            orders.Add(order);
            UpdateData();
        }

        private void InitData() {
            try {
                report = JObject.Load(new JsonTextReader(new StreamReader(path)));
                if (report["orders"].HasValues) {
                    orders = JsonConvert.DeserializeObject<List<MenuItem>>(report["orders"].ToString());
                }
            }
            catch (FileNotFoundException) {
                UpdateData();
            }
            
        }
        
        private void UpdateData() {
            report =
                new JObject(
                    new JProperty("date", $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}"),
                    new JProperty("orders",
                        new JArray(
                            from o in orders
                            orderby o.Drink
                            select new JObject(
                                new JProperty("drink", o.Drink),
                                new JProperty("cost", o.Cost)
                            )
                        )
                    )
                );

            report_string = report.ToString();
            File.WriteAllText(path, report_string);
        }

        public void GenerateReport() {
            InitData();
            var drinksByDrinktype = from order in orders
                group order by order.Drink;
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Drink        | Orders | Total $");
            Console.WriteLine("-------------------------------");
            
            foreach (var drinkType in drinksByDrinktype) {
                int numberOfDrinks = 0;
                double totalRevenue = 0;
                string name = "";
                foreach (var drink in drinkType) {
                    numberOfDrinks++;
                    totalRevenue += drink.Cost;
                    name = $"{drink.Drink}";
                    if (drink.Drink == DrinkType.OrangeJuice) { name = "Orange Juice"; }
                }

                Console.WriteLine($"{name,-12} | {numberOfDrinks,-6} | ${totalRevenue:0.00}");

            }
            
            Console.WriteLine("-------------------------------");
        }
    }
}