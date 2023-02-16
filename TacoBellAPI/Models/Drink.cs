using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace TacoBellAPI.Models;

public partial class Drink
{
    public int Id { get; set; }

    public string Name { get; set; }

    public float Cost { get; set; }

    public bool Slushie { get; set; }

    public Drink(int id, string name, float cost, bool slushie)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Slushie = slushie;
    }
}
