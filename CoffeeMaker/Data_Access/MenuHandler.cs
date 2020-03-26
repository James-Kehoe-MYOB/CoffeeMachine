using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CoffeeMaker.Data_Access {
    public static class MenuHandler {
        private static string _menuSource = "../../../Data/Menu.csv";
        
        public static List<MenuItem> FillMenu() {
            List<MenuItem> menu;
            using (var reader = new StreamReader(_menuSource)) {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                menu = csv.GetRecords<MenuItem>().ToList();
            }
            return menu;
        }
    }
}