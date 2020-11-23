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
            using (StreamReader r = new StreamReader("test.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<State>>(json);
            }
            temp = items[stateID];

            string message = temp.Name + "|" + temp.BasicInfo + "|" + temp.LocationOneHeader + "|" + temp.LocationOneImage + "|" + temp.LocationOneText + "|" + temp.LocationTwoHeader + "|" + temp.LocationTwoImage + "|" + temp.LocationTwoText;
            //If I merge message and messageTwo something goes wrong with API, not sure why
            //string messageTwo = "|" + temp.LocationThreeHeader + "|" + temp.LocationThreeImage + "|" + temp.LocationThreeText;

            return message;


        }
    }
}