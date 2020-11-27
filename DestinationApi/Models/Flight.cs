using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class Flight
    {
        private string flightName;
        private int economyPrice;
        private int businessPrice;
        private int firstPrice;

        public Flight()
        {

        }
        public Flight(string flight, int economy, int business, int first)
        {
            flightName = flight;
            economyPrice = economy;
            businessPrice = business;
            firstPrice = first;
        }
        public string FlightName
        {
            get
            {
                return flightName;
            }
            set
            {
                flightName = value;
            }
        }
        public int EconomyPrice
        {
            get
            {
                return economyPrice;
            }
            set
            {
                economyPrice = value;
            }
        }
        public int BusinessPrice
        {
            get
            {
                return businessPrice;
            }
            set
            {
                businessPrice = value;
            }
        }
        public int FirstPrice
        {
            get
            {
                return firstPrice;
            }
            set
            {
                firstPrice = value;
            }
        }
    }
}
