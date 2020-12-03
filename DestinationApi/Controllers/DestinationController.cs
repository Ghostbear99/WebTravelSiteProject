using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DestinationApi.Models;
using Newtonsoft.Json;
using System.IO;
using Utilities;
using System.Data;
using System.Diagnostics;

namespace DestinationApi.Controllers
{
    [Route("api/[controller]")]
    public class DestinationController : Controller
    {
        State temp = new State();

        [HttpGet("GetState/{stateID}")]
        public String GetState(int stateID)
        {
            List<State> items = null;
            using (StreamReader r = new StreamReader("stateInfo.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<State>>(json);
            }
            temp = items[stateID];

            string message = temp.Name + "|" + temp.Image + "|" + temp.Description;
            return message;
        }
        [HttpGet("GetFlight/{flightName}")]
        public Flight GetFlight(string flightName)
        {
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM Flights WHERE FlightName='" + flightName + "'";
            DataSet recordSet = db.GetDataSet(sql);
            Flight newFlight = new Flight();
            if (recordSet.Tables[0].Rows.Count > 0)
            {
                DataRow record = recordSet.Tables[0].Rows[0];
                newFlight.FlightName = record["FlightName"].ToString();
                newFlight.EconomyPrice = int.Parse(record["Economy Class"].ToString());
                newFlight.BusinessPrice = int.Parse(record["Business Class"].ToString());
                newFlight.FirstPrice = int.Parse(record["First Class"].ToString());
            }
            return newFlight;
        }
        [HttpGet("GetHotel/{hotelName}")]
        public Hotel GetHotel(string hotelName)
        {
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM Hotels WHERE HotelName='" + hotelName + "'";
            DataSet recordSet = db.GetDataSet(sql);
            Hotel newHotel = new Hotel();
            if (recordSet.Tables[0].Rows.Count > 0)
            {
                DataRow record = recordSet.Tables[0].Rows[0];
                newHotel.ID = int.Parse(record["Id"].ToString());
                newHotel.Name = record["HotelName"].ToString();
                newHotel.SuiteBedPrice = int.Parse(record["SuitePrice"].ToString());
                newHotel.TwoBedPrice = int.Parse(record["TwoBedPrice"].ToString());
                newHotel.SingleBedPrice = int.Parse(record["SingleBedPrice"].ToString());
            }
            return newHotel;
        }
        [HttpPost("InsertFlightOrder")]
        public string InsertFlightOrder(string origin, string destination, string company, string flightClass, int numSeats, string tripStart, string tripEnd, int cost)
        {
            DBConnect db = new DBConnect();
            String sql = "INSERT INTO FlightOrder VALUES('" + origin + "','" + destination + "','" + company + "','" + flightClass + "'," + numSeats + ",'" + tripStart + "','" + tripEnd + "'," + cost + ")";

            string result = db.DoUpdate(sql);
            return result;

        }
        [HttpGet("GetAllFlightOrder")]
        public List<FlightOrder> GetAllFlightOrder()
        {
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM FlightOrder";
            DataSet recordSet = db.GetDataSet(sql);
            List<FlightOrder> newOrderList = new List<FlightOrder>();
            for (int row = 0;  row < recordSet.Tables[0].Rows.Count; row++)
            {
                FlightOrder newOrder = new FlightOrder();
                DataRow record = recordSet.Tables[0].Rows[row];
                newOrder.Origin = record["Origin"].ToString();
                newOrder.Destination = record["Destination"].ToString();
                newOrder.Company = record["Company"].ToString();
                newOrder.FlightClass = record["FlightClass"].ToString();
                newOrder.NumSeats = int.Parse(record["NumSeats"].ToString());
                newOrder.TripStart = record["TripStart"].ToString();
                newOrder.TripEnd = record["TripEnd"].ToString();
                newOrder.Cost = int.Parse(record["Cost"].ToString());

                newOrderList.Add(newOrder);
            }
            return newOrderList;
        }
        [HttpGet("PurgeFlightOrder")]
        public string DeleteAllFlightOrder()
        {
            DBConnect db = new DBConnect();
            String sql = "DELETE FROM FlightOrder";

            string result = db.DoUpdate(sql);
            return result;

        }
        [HttpPost("InsertHotelOrder")]
        public string InsertHotelOrder(string destination, string hotelName, string roomType, string customerFirst, string customerLast, string customerEmail, string tripStart, string tripEnd, string pickedUp, string flightNum, string additionalRequests, int numRooms, int cost)
        {
            DBConnect db = new DBConnect();
            String sql = "INSERT INTO HotelOrder VALUES('" + destination + "','" + hotelName + "','" + roomType + "','" + customerFirst + "','" + customerLast + "','" + customerEmail + "','" + tripStart + "','" + tripEnd + "','" + pickedUp + "','" + flightNum + "','" + additionalRequests + "'," + numRooms + "," + cost + ")";

            string result = db.DoUpdate(sql);
            return result;

        }
        [HttpGet("GetAllHotelOrder")]
        public List<HotelOrder> GetAllHotelOrder()
        {
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM HotelOrder";
            DataSet recordSet = db.GetDataSet(sql);
            List<HotelOrder> newOrderList = new List<HotelOrder>();
            for (int row = 0; row < recordSet.Tables[0].Rows.Count; row++)
            {
                HotelOrder newOrder = new HotelOrder();
                DataRow record = recordSet.Tables[0].Rows[0];
                newOrder.Destination = record["Destination"].ToString();
                newOrder.HotelName = record["HotelName"].ToString();
                newOrder.RoomType = record["RoomType"].ToString();
                newOrder.CustomerFirst = record["CustomerFirst"].ToString();
                newOrder.CustomerLast = record["CustomerLast"].ToString();
                newOrder.CustomerEmail = record["CustomerEmail"].ToString();
                newOrder.TripStart = record["TripStart"].ToString();
                newOrder.TripEnd = record["TripEnd"].ToString();
                newOrder.PickedUp = record["PickedUp"].ToString();
                newOrder.FlightNum = record["FlightNum"].ToString();
                newOrder.AdditionalRequests = record["AdditionalRequests"].ToString();
                newOrder.NumRooms = int.Parse(record["NumRooms"].ToString());
                newOrder.Cost = int.Parse(record["Cost"].ToString());

                newOrderList.Add(newOrder);
            }
            return newOrderList;
        }
        [HttpGet("PurgeHotelOrder")]
        public string DeleteAllHotelOrder()
        {
            DBConnect db = new DBConnect();
            String sql = "DELETE FROM HotelOrder";

            string result = db.DoUpdate(sql);
            return result;

        }
    }
}