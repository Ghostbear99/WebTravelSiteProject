using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class Order
    {
        private string flightName;
        private string flightClass;
        private int flightPrice;
        private string hotelName;
        private string hotelType;
        private decimal hotelPrice;
        private DateTime tripStart;
        private DateTime tripEnd;
        private string name;
        private int numFlight;
        private int numHotel;
        private string stateOrigin;
        private string stateDestination;

        public Order()
        {

        }
        public Order(string flightName, string flightClass, int flightPrice, string hotelName, string hotelType, decimal hotelPrice, DateTime start, DateTime end, string customerName, int numFlight,int numHotel,string origin, string destination)
        {
            this.flightName = flightName;
            this.flightClass = flightClass;
            this.flightPrice = flightPrice;
            this.hotelName = hotelName;
            this.hotelType = hotelType;
            this.hotelPrice = hotelPrice;
            tripStart = start;
            tripEnd = end;
            name = customerName;
            this.numFlight = numFlight;
            this.numHotel = numHotel;
            stateOrigin = origin;
            stateDestination = destination;
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
        public int FlightPrice
        {
            get
            {
                return flightPrice;
            }
            set
            {
                flightPrice = value;
            }
        }
        public string HotelName
        {
            get
            {
                return hotelName;
            }
            set
            {
                hotelName = value;
            }
        }
        public string HotelType
        {
            get
            {
                return hotelType;
            }
            set
            {
                hotelType = value;
            }
        }
        public decimal HotelPrice
        {
            get
            {
                return hotelPrice;
            }
            set
            {
                hotelPrice = value;
            }
        }
        public DateTime TripStart
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
        public DateTime TripEnd
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
        public int NumFlight
        {
            get
            {
                return numFlight;
            }
            set
            {
                numFlight = value;
            }
        }
        public int NumHotel
        {
            get
            {
                return numHotel;
            }
            set
            {
                numHotel = value;
            }
        }
        public string StateOrigin
        {
            get
            {
                return stateOrigin;
            }
            set
            {
                stateOrigin = value;
            }
        }
        public string StateDestination
        {
            get
            {
                return stateDestination;
            }
            set
            {
                stateDestination = value;
            }
        }
    }
}
