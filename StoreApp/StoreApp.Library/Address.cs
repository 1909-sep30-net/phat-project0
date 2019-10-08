using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    public class Address
    {
        private string stress;
        private string city;
        private string state;

        public string Stress { get => stress; set => stress = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
    }
}
