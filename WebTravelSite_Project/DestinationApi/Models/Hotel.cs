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
        private string state;
        private decimal suitePrice;
        private decimal twoBedPrice;
        private decimal singleBedPrice;

        public Hotel()
        {

        }
        public Hotel(int id, string name,string state, decimal suite, decimal twoBed, decimal singleBed)
        {
            Id = id;
            this.name = name;
            this.state = state;
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
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public decimal SuiteBedPrice
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
        public decimal TwoBedPrice
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
        public decimal SingleBedPrice
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
