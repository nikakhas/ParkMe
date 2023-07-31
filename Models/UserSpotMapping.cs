using System;
using System.Collections.Generic;

namespace ParkMe.Models;

public partial class UserSpotMapping
{
    public string CampusId { get; set; }

    public int SpotId { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public decimal Charge { get; set; }
}
