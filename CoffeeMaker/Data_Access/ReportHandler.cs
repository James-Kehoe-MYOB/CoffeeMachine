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
            GetData();
            orders.Add(order);
            UpdateData();
        }

        private void GetData() {
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
                            orderby o.ID
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
            GetData();
            var teas = from order in orders
                where order.Drink == DrinkType.Tea
                select order;
            
            var coffees = from order in orders
                where order.Drink == DrinkType.Coffee
                select order;
            
            var chocolates = from order in orders
                where order.Drink == DrinkType.Chocolate
                select order;

            var myreport = "Drink        Orders    Total $\n" +
                           $"Tea          {teas.Count()}         ${0.4 * teas.Count():0.00}\n" +
                           $"Coffee       {coffees.Count()}         ${0.6 * coffees.Count():0.00}\n" +
                           $"Chocolate    {chocolates.Count()}         ${0.5 * chocolates.Count():0.00}";

            Console.WriteLine(myreport);
        }
    }
}