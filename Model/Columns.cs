using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RecordChecker.Model
{
   class Sheet//:IEquatable<Sheet>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        //public bool Equals([AllowNull] Sheet other)
        //{
        //    if (other is null)
        //        return false;

        //    return this.Name == other.Name && this.Age == other.Age;
        //}
        //public static bool Compare(Sheet a,Sheet b )
        //{
        //return (a.Age != b.Age || a.Name != b.Name);
        //}

    }
}
