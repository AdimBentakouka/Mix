using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videotheque.Model
{
    public class Film : Media
    {
        public TimeSpan Duree { get; set; }
    }
}