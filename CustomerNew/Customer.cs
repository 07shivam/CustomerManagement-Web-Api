using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerNew
{
    public class Customer
    { 
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string customerType { get; set; }
        public string emailAddress { get; set; }
       public DateTime dateOfBirth { get; set; }
        
    }
}
