using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactLibrary.Model
{
    public class FactModel
    {
        public string Fact { get; set;}
        public int Length { get; set; }

        public FactModel(string Fact, int length)
        {
            this.Fact = Fact;
            this.Length = length;
        }



    }
}
