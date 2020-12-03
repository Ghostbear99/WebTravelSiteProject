using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class HotelOrder
    {
        private string destination;
        private string hotelName;
        private string roomType;
        private string customerFirst;
        private string customerLast;
        private string customerEmail;
        private string tripStart;
        private string tripEnd;
        private string pickedUp;
        private string flightNum;
        private string additionalRequests;
        private int numRooms;
        private int cost;

        public HotelOrder() { }
        public HotelOrder(string destination, string hotelName, string roomType, string customerFirst, string customerLast, string tripStart,
            string tripEnd, string pickedUp, string flightNum, string additionalRequests, int numRooms, int cost)
        {
            this.destination = destination;
            this.hotelName = hotelName;
            this.roomType = roomType;
            this.customerFirst = customerFirst;
            this.customerLast = customerLast;
            this.tripStart = tripStart;
            this.tripEnd = tripEnd;
            this.pickedUp = pickedUp;
            this.flightNum = flightNum;
            this.additionalRequests = additionalRequests;
            this.numRooms = numRooms;
            this.cost = cost;
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
        public string RoomType
        {
            get
            {
                return roomType;
            }
            set
            {
                roomType = value;
            }
        }
        public string CustomerFirst
        {
            get
            {
                return customerFirst;
            }
            set
            {
                customerFirst = value;
            }
        }
        public string CustomerLast
        {
            get
            {
                return customerLast;
            }
            set
            {
                customerLast = value;
            }
        }
        public string CustomerEmail
        {
            get
            {
                return customerEmail;
            }
            set
            {
                customerEmail = value;
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
        public string PickedUp
        {
            get
            {
                return pickedUp;
            }
            set
            {
                pickedUp = value;
            }
        }
        public string FlightNum
        {
            get
            {
                return flightNum;
            }
            set
            {
                flightNum = value;
            }
        }
        public string AdditionalRequests
        {
            get
            {
                return additionalRequests;
            }
            set
            {
                additionalRequests = value;
            }
        }
        public int NumRooms
        {
            get
            {
                return numRooms;
            }
            set
            {
                numRooms = value;
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
