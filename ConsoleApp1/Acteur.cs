using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1
{
    public partial class Acteur
    {
        public Acteur()
        {
            Citations = new HashSet<Citation>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Citation> Citations { get; set; }
    }
}
