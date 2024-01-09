using System;
using System.Collections.Generic;

namespace ExamenFlores3.Models.Entities;

public partial class Datos
{
    public uint Id { get; set; }

    public string NombreFlor { get; set; } = null!;

    public string Origen { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
