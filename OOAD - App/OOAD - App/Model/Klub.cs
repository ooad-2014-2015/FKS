using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OOAD___App.Model
{
    [Table("Klub")]
    public class Klub
    {
        [PrimaryKey, AutoIncrement]
        public int klub_id { get; set; }
        public string naziv { get; set; }
        public string grad { get; set; }
        public bool liveStream { get; set; }
        public string trener { get; set; }
        public DateTime datumRegistracije { get; set; }
        public int liga_id { get; set; }


    }
}
