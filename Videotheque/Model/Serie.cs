using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videotheque.Model
{
    public class Serie : Media
    {
        public int Duree { get; set; }
        public int Nb_Saisons { get ; set; }
    }
}