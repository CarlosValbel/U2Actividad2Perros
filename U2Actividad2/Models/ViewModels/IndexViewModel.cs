using U2Actividad2.Models.Entities;

namespace U2Actividad2.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Razas> Razas { get; set; } = null!;
    }
    public class Razas
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
