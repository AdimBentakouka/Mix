using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidéotèque
{
    public class Enum
    {
        public enum StatutMedia
        {
            Vide,
            AVoir,
            Vu,
            EnCours
        }

        public enum Langue
        {
            Anglais,
            Français,
            Portugais,
            Algérien
        }

        public enum Civilite
        {
            Monsieur,
            Madame,
            PersonneMorale
        }

        public enum Fonction
        {
            Producteur,
            Realisateur,
            Acteur,
            Compositeur
        }

    }
}
