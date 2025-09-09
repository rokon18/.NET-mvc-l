using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class News
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("ctg")]
        public int cId { get; set; }
        public virtual Category ctg { get; set; }

    }
}
