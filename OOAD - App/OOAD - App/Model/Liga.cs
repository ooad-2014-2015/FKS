using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OOAD___App.Model
{
    [Table("Liga")]
    public class Liga
    {
        [PrimaryKey, AutoIncrement]
        public int liga_id { get; set; }
        public string naziv { get; set; }
        public int brojKlubova { get; set; }
        public DateTime pocetak { get; set; }
        public DateTime kraj { get; set; }
    }
}
