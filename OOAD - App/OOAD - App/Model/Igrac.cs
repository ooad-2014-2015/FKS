using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OOAD___App.Model
{
    [Table("Igrac")]
    public class Igrac
    {
        [PrimaryKey, AutoIncrement]
        public int igrac_id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodenja { get; set; }
        public bool suspenzija { get; set; }
        public int brojZutih { get; set; }
        public int brojCrvenih { get; set; }
        public int brojGolova { get; set; }
        public int brojAsistencija { get; set; }
        public string drzava { get; set; }
        public string jmbg { get; set; }
        public DateTime datumRegistracije { get; set; }
        public int klub_id { get; set; }
        public string displayMember { get{ return ime + " " + prezime; } set {} }

    }
}
