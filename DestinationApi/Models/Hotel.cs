using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class Hotel
    {
        private int Id;
        private string name;
        private int suitePrice;
        private int twoBedPrice;
        private int singleBedPrice;

        public Hotel()
        {

        }
        public Hotel(int id, string name,int suite, int twoBed, int singleBed)
        {
            Id = id;
            this.name = name;
            suitePrice = suite;
            twoBedPrice = twoBed;
            singleBedPrice = singleBed;
        }
        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
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
        public int SuiteBedPrice
        {
            get
            {
                return suitePrice;
            }
            set
            {
                suitePrice = value;
            }
        }
        public int TwoBedPrice
        {
            get
            {
                return twoBedPrice;
            }
            set
            {
                twoBedPrice = value;
            }
        }
        public int SingleBedPrice
        {
            get
            {
                return singleBedPrice;
            }
            set
            {
                singleBedPrice = value;
            }
        }
    }
}
