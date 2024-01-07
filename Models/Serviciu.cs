using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Irimia_mobila.Models
{
    public class Serviciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [SQLite.MaxLength(250), SQLite.NotNull]
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListaServiciu> ListaServicii { get; set; }
    }
}
