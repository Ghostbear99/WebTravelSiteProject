using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DestinationApi.Models;

namespace DestinationApi.Controllers
{
    [Route("api/[controller]")]
    public class DestinationController : Controller
    {
        State temp = new State();

        [HttpGet]
        public string Get()
        {
            return "GET has been executed";
        }
        [HttpGet("GetState/{stateID}")]
        public String GetState(int stateID)
        {
            return "Http GET executed, the state is " + stateID;
        }
        [HttpGet("States")]
        public string GetStates()
        {
            return temp.BasicInfo;
        }
    }
}