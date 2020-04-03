using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CoffeeMaker.Data_Access {
    public class BeverageQuantityUpdater {

        private string path = "../../../Data/BeverageLevels.csv";

        private List<BeverageLevel> levels;

        public BeverageQuantityUpdater() {
            levels = ReadLevels();
        }
        
        public List<BeverageLevel> ReadLevels() {
            List<BeverageLevel> mylevels = new List<BeverageLevel>();
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            mylevels = csv.GetRecords<BeverageLevel>().ToList();

            return mylevels;
        }

        public void WriteLevels(int water, int milk) {
            levels[0].Level = water;
            levels[1].Level = milk;

            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(levels);
            
            writer.Flush();
        }
        
    }

    public class BeverageLevel {
        public string Name { get; set; }
        public int Level { get; set; }

        public BeverageLevel(string Name, int Level) {
            this.Name = Name;
            this.Level = Level;
        }
        
    }
}