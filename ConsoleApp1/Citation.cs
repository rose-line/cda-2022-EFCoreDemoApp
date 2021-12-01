using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1
{
    public partial class Citation
    {
        public int Id { get; set; }
        public string Texte { get; set; }
        public int ActeurId { get; set; }

        public Acteur Acteur { get; set; }
    }
}
