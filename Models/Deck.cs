using System;
using System.Collections.Generic;

namespace ParkMe.Models;

public partial class Deck
{
    public int DeckId { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public virtual ICollection<Spot> Spots { get; set; } = new List<Spot>();
}
