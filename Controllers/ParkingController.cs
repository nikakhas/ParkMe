using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ParkMe.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ILogger<ParkingController> _logger;

        public ParkingController(ILogger<ParkingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }

        private void ParseGpsData(string data)
        {
            string[] parts = data.Split(',');

            if (parts[0] == "$GPRMC" && parts[2] == "A")
            {
                // Parse latitude and longitude
                double latitude = double.Parse(parts[3]);
                double longitude = double.Parse(parts[5]);
                string latDirection = parts[4];
                string lonDirection = parts[6];

                if (latDirection == "S")
                {
                    latitude *= -1;
                }

                if (lonDirection == "W")
                {
                    longitude *= -1;
                }

                if (latDirection == "N")
                {
                    latitude *= 1;
                }
                if (lonDirection == "E")
                {
                    longitude *= 1;
                }

                // Do something with the latitude and longitude
                // For example, update the location of a parked car in the database
            }
        }

        [HttpPost]
        public IActionResult ReceiveGpsData(string data)
        {
            ParseGpsData(data);

            return Ok();
        }
    }
}
