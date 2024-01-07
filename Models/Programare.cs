using System.ComponentModel.DataAnnotations;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Irimia_mobila.Models
{
    public class Programare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [SQLite.MaxLength(250), SQLite.NotNull, Unique]

        public string Descriere { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }
        [ForeignKey(typeof(Clinica))]
        public int ClinicaID { get; set; }

    }
}
