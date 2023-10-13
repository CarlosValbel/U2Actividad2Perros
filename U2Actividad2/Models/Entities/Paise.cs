using System;
using System.Collections.Generic;

namespace U2Actividad2.Models.Entities;

public partial class Paise
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
