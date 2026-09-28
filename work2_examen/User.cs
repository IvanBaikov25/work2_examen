using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace work2_examen
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("fio")]
        public string LastName { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
