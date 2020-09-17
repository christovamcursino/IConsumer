using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class Address
    {
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
