using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class State
    {
        private string name;
        private string imageURL;

        public State(string name, string imageURL)
        {
            this.name = name;
            this.imageURL = imageURL;
        }
        public State() { }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Image
        {
            get
            {
                return imageURL;
            }
            set
            {
                imageURL = value;
            }
        }
    }
}
