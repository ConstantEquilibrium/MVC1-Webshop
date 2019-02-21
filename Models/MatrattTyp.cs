using System;
using System.Collections.Generic;

namespace Inlämning_2___Webshop.Models
{
    public partial class MatrattTyp
    {
        public MatrattTyp()
        {
            Matratt = new HashSet<Matratt>();
        }

        public int MatrattTypId { get; set; }
        public string Beskrivning { get; set; }

        public virtual ICollection<Matratt> Matratt { get; set; }
    }
}
