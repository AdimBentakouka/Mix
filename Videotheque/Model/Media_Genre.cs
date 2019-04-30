using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    public class Media_Genre
    {
        public int Id_Genre { get; set; }
        public int Id_Media { get; set; }

        [ForeignKey(nameof(Id_Genre))]
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Id_Media))]
        public Media Media { get; set; }
    }
}
