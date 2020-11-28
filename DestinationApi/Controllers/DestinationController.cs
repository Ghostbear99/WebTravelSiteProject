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
        [HttpGet("GetHotel/{hotelName}/{state}")]
        public Hotel GetHotel(string hotelName, string state)
        {
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM Hotels WHERE HotelName='" + hotelName + "'AND State='" + state + "'";
            DataSet recordSet = db.GetDataSet(sql);
            Hotel newHotel = new Hotel();
            if (recordSet.Tables[0].Rows.Count > 0)
            {
                DataRow record = recordSet.Tables[0].Rows[0];
                newHotel.ID = int.Parse(record["Id"].ToString());
                newHotel.Name = record["HotelName"].ToString();
                newHotel.State = record["State"].ToString();
                newHotel.SuiteBedPrice = decimal.Parse(record["SuitePrice"].ToString());
                newHotel.TwoBedPrice = decimal.Parse(record["TwoBedPrice"].ToString());
                newHotel.SingleBedPrice = decimal.Parse(record["SingleBedPrice"].ToString());
            }
            return newHotel;
        }
        [HttpGet("GetAllHotel/{state}")]
        public List<Hotel> GetAllHotel(string state)
        {
            List<Hotel> temp = new List<Hotel>();
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM Hotels WHERE State='" + state + "'";
            DataSet recordSet = db.GetDataSet(sql);
            if (recordSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < recordSet.Tables[0].Rows.Count; i++)
                {
                    DataRow record = recordSet.Tables[0].Rows[i];
                    Hotel newHotel = new Hotel();
                    newHotel.ID = int.Parse(record["Id"].ToString());
                    newHotel.Name = record["HotelName"].ToString();
                    newHotel.State = record["State"].ToString();
                    newHotel.SuiteBedPrice = decimal.Parse(record["SuitePrice"].ToString());
                    newHotel.TwoBedPrice = decimal.Parse(record["TwoBedPrice"].ToString());
                    newHotel.SingleBedPrice = decimal.Parse(record["SingleBedPrice"].ToString());

                    temp.Add(newHotel);
                }

            }
            return temp;
        }
        [HttpPost("InsertOrder")]
        public string InsertOrder([FromBody]Order theOrder)
        {
            DBConnect db = new DBConnect();
            string format = "yyyy-MM-dd";
            String sql = "INSERT INTO Orders VALUES('" + theOrder.FlightName + "','" + theOrder.FlightClass + "'," + theOrder.FlightPrice +
                ",'" + theOrder.HotelName + "','" + theOrder.HotelType + "'," + theOrder.HotelPrice + ",'" + theOrder.TripStart.ToString(format) + "','" + theOrder.TripEnd.ToString(format) + "'," 
                + theOrder.NumFlight + "," + theOrder.NumHotel + ",'" + theOrder.StateOrigin + "','" + theOrder.StateDestination + "')";

            string result = db.DoUpdate(sql);
            return result;

        }
        [HttpGet("GetOrders")]
        public List<Order> GetOrder(string name)
        {
            DBConnect db = new DBConnect();
            String sql = "SELECT * FROM Orders";
            DataSet recordSet = db.GetDataSet(sql);
            List<Order> newOrderList = new List<Order>();
            if (recordSet.Tables[0].Rows.Count > 0)
            {
                Order newOrder = new Order();
                DataRow record = recordSet.Tables[0].Rows[0];
                newOrder.FlightName = record["FlightName"].ToString();
                newOrder.FlightClass = record["FlightClass"].ToString();
                newOrder.FlightPrice = int.Parse(record["FlightPrice"].ToString());
                newOrder.HotelName = record["HotelName"].ToString();
                newOrder.HotelType = record["HotelType"].ToString();
                newOrder.HotelPrice = decimal.Parse(record["HotelPrice"].ToString());
                newOrder.TripStart = DateTime.Parse(record["TripStartDate"].ToString());
                newOrder.TripEnd = DateTime.Parse(record["TripEndDate"].ToString());
                newOrder.NumFlight = int.Parse(record["NumFlight"].ToString());
                newOrder.NumHotel = int.Parse(record["NumHotel"].ToString());
                newOrder.StateOrigin = record["StateOrigin"].ToString();
                newOrder.StateDestination = record["StateDestination"].ToString();

                newOrderList.Add(newOrder);
            }
            return newOrderList;
        }
        [HttpGet("PurgeOrder")]
        public string DeleteAllOrder()
        {
            DBConnect db = new DBConnect();
            String sql = "DELETE FROM Orders";

            string result = db.DoUpdate(sql);
            return result;

        }
        [HttpGet("DeleteSpecificOrder/{id}")]
        public string DeleteSpecificOrder(int id)
        {
            DBConnect db = new DBConnect();
            String sql = "DELETE FROM Orders WHERE Id='" + id + "'";

            string result = db.DoUpdate(sql);
            return result;
        }
    }
}