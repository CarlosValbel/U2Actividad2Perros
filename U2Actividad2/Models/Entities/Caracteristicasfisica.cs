using System;
using System.Collections.Generic;

namespace U2Actividad2.Models.Entities;

public partial class Caracteristicasfisica
{
    public uint Id { get; set; }

    public string? Patas { get; set; }

    public string? Cola { get; set; }

    public string? Hocico { get; set; }

    public string? Pelo { get; set; }

    public string? Color { get; set; }

    public virtual Raza IdNavigation { get; set; } = null!;
}
