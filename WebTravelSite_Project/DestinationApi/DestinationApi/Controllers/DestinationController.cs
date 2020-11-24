using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DestinationApi.Models;
using Newtonsoft.Json;
using System.IO;

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

            string message = temp.Name + "|" + temp.Image;
            return message;
        }
        [HttpGet("GetFlight/{flightName}")]
        public string GetFlight(string flightName)
        {
            return "";
        }
        [HttpPost("PutCustomer/{customerName}/{flightName}/{flightPrice}/{hotelName}/{hotelPrice}")]
        public void PostCustomer(string customerName, string flightName, Decimal flightPrice, string hotelName, Decimal hotelPrice)
        {

        }
        [HttpGet("GetCustomer")]
        public string GetCustomer()
        {
            return "";
        }
    }
}