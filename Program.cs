using ExcelDataReader;
using RecordChecker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program obj = new Program();
            var original=obj.ReadExcel(@"C:\Users\91790\Downloads\Original.xlsx");
            var duplicate=obj.ReadExcel(@"C:\Users\91790\Downloads\Duplicate.xlsx");


            var match = obj.MatchFiles(original, duplicate);

            if (match.Count == 0)
            {
                Console.WriteLine("All records match.");
            }
            else
            {
                Console.WriteLine("Following records do not match.");
                foreach (var item in match)
                {
                    Console.WriteLine(item.Name+" "+item.Age+" "+item.ID);
                }
            }
            //var match = obj.MatchFiles();
        }

        #region ReadExcel

        public List<Sheet> ReadExcel(string fileName)
        {
            List<Sheet> records = new List<Sheet>();
            int rowNumber = 0;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        rowNumber++;
                        records.Add(new Sheet
                        {
                            Name=reader.GetValue(0).ToString(),
                            Age= reader.GetValue(1).ToString(),
                            ID=rowNumber
                        });
                    }
                }
            }
            return records;
        }
        #endregion

         
        public List<Sheet> MatchFiles(List<Sheet> original, List<Sheet> duplicate)
        {
            List<Sheet> duplicateRecords=new List<Sheet>();
            //List<Columns> original1 = new List<Columns>
            //{
            //    new Columns{Age="9",ID=1,Name="A"},
            //    new Columns{Age="10",ID=2,Name="B"},
            //    new Columns{Age="11",ID=3,Name="C"},
            //};
            //List<Columns> duplicate1 = new List<Columns>
            //{
            //    new Columns{Age="9",ID=1,Name="A"},
            //    new Columns{Age="1r0",ID=2,Name="B"},
            //    new Columns{Age="11",ID=3,Name="C"}
            //};
            //}

            //bool comparisonResult = original. Zip(duplicate, (x, y) => new { x, y }).All(z => Sheet.Compare(z.x, z.y));

            //foreach (var item in original)
            //{
            //    foreach (var dup in duplicate)
            //    {
            //        if (item.Age!=dup.Age ||item.Name!=dup.Name)
            //        {
            //            differentRecords.Add(dup);
            //        }
            //    }
            //}
            //foreach (var item in original)
            //{
            //    foreach (var dup in duplicate)
            //    {
            //        var result=item.Equals(dup);
            //        if (result==false)
            //        {
            //            differentRecords.Add(item);
            //        }
            //    }
            //}
            //var result = duplicate.Where(p => !original.Any(p2 => p2.Name == p.Name && p2.Age==p.Age));
            //bool isRecordExists;
            
            foreach (var item in original)
            {
                int i = 0;
                foreach (var dup in duplicate)
                {
                    if(item.Age==dup.Age && item.Name == dup.Name)
                    {
                        //duplicateRecords.Add(dup);
                        i++;
                    }
                }
                if (i > 0)
                {
                    duplicateRecords.Add(item);
                }
                //Console.WriteLine(  item);
            }

            //var excludedIDs = new HashSet<string>(original.Select(p => p.Name));
            //var result = duplicate.Where(p => !excludedIDs.Contains(p.Name));
            return duplicateRecords;
        }


    }
}
