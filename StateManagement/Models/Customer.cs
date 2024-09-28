using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateManagement.Models
{
    public class Customer
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string Account {  get; set; }
        public long Balance { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string Photo {  get; set; }
    }
}