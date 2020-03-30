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
            try {
                report = JObject.Load(new JsonTextReader(new StreamReader(path)));
                if (report["orders"].HasValues) {
                    orders = JsonConvert.DeserializeObject<List<MenuItem>>(report["orders"].ToString());
                }
                orders.Add(order);
                UpdateData();
            }
            catch (FileNotFoundException e) {
                orders.Add(order);
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
    }
}