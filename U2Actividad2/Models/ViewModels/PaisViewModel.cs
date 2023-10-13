using U2Actividad2.Models.Entities;

namespace U2Actividad2.Models.ViewModels
{
    public class PaisViewModel
    {
        public List<Pais> Pais { get; set; } = null!;
    }
    public class Pais
    {
        public List<Razas> Razas { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }
}
