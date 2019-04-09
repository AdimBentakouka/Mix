using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidéotèque{
    public class Serie : Media
    {
        public int Duree { get; set; }
        public int Nb_saisons { get ; set; }
    }
}