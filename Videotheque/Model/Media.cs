using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Vidéotèque.Enum;



namespace Vidéotèque
{
    public class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime Date_Creation { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; }
        public string Synopsis { get; set; }
        public int Age_minimum { get; set; }
        public bool AudioDescription { get; set; }
        public bool Support_physique { get; set; }
        public bool Support_numerique { get; set; }

        public StatutMedia Statut { get; set; }
        public Langue Langue_vo { get; set; }
        public Langue Langue_media { get; set; }
        public Langue Sous_titre { get; set; }


    
        [InverseProperty(nameof(Media_Genre.Media))]
        public List<Media_Genre> Genre { get; set; }
    }
}
