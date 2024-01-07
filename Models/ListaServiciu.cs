using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Irimia_mobila.Models
{
    public class ListaServiciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Programare))]
        public int ProgramareID { get; set; }
        public int ServiciuID { get; set; }
    }
}