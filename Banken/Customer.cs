using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banken
{
    class Customer
    {
        public string Name { get; set; }
        public int Income { get; set; }

        public string ShowCustomerName()
        {
            return this.Name;
        }
    }
}