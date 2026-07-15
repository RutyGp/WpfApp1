using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.MyClasses
{
    public class Contacts
    {
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime? BornDate { get; set; } = DateTime.MinValue;
        public bool IsFavorite { get; set; } = false;

        public override string ToString()
        {
            return $"{Name} Lives in {City}, BornDate={BornDate}, IsFavorite ={IsFavorite}";
        }
    }
}
