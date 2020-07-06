using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        private int id;
        private string name;
        public Movie() { }
        public Movie(string Name) {
            this.name = Name;
        }
        public Movie(int Id, string Name)
        {
            this.id = Id;
            this.name = Name;
        }
        public int Id {
            get { return this.id;}
            set { this.id = value;} 
        }
        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }

    }
}