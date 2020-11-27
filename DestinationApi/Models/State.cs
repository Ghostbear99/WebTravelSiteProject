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
        private string description;

        public State(string name, string imageURL, string description)
        {
            this.name = name;
            this.imageURL = imageURL;
            this.description = description;
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

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

    }
}
