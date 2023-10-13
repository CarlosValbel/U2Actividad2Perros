using U2Actividad2.Models.Entities;

namespace U2Actividad2.Models.ViewModels
{
    public class RazaViewModel
    {
        public Raza Perro { get; set; } = null!;
        public List<Razas> Otros { get; set; } = null!;
    }
}
