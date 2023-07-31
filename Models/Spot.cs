using System;
using System.Collections.Generic;

namespace ParkMe.Models;

public partial class Spot
{
    public int SpotId { get; set; }

    public int DeckId { get; set; }

    public string SpotName { get; set; }

    public virtual Deck Deck { get; set; }
}
