using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidéotèque
{
    public class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public String Nom { get; set; }

        [InverseProperty(nameof(Media_Genre.Genre))]
        public List<Media_Genre> Media { get; set; }
    }
}
