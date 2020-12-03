using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class FlightOrder
    {
        private string origin;
        private string destination;
        private string company;
        private string flightClass;
        private int numSeats;
        private string tripStart;
        private string tripEnd;
        private int cost;

        public FlightOrder() { }
        public FlightOrder(string origin, string destination, string company, string flightClass, int numSeats,
            string tripStart, string tripEnd, int cost)
        {
            this.origin = origin;
            this.destination = destination;
            this.company = company;
            this.flightClass = flightClass;
            this.numSeats = numSeats;
            this.tripStart = tripStart;
            this.tripEnd = tripEnd;
            this.cost = cost;
        }
        public string Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
            }
        }
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string FlightClass
        {
            get
            {
                return flightClass;
            }
            set
            {
                flightClass = value;
            }
        }
        public int NumSeats
        {
            get
            {
                return numSeats;
            }
            set
            {
                numSeats = value;
            }
        }
        public string TripStart
        {
            get
            {
                return tripStart;
            }
            set
            {
                tripStart = value;
            }
        }
        public string TripEnd
        {
            get
            {
                return tripEnd;
            }
            set
            {
                tripEnd = value;
            }
        }
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
    }
}
