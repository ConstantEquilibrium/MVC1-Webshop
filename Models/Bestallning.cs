﻿using System;
using System.Collections.Generic;

namespace Inlämning_2___Webshop.Models
{
    public partial class Bestallning
    {
        public Bestallning()
        {
            BestallningMatratt = new HashSet<BestallningMatratt>();
        }

        public int BestallningId { get; set; }
        public DateTime BestallningDatum { get; set; }
        public int Totalbelopp { get; set; }
        public bool Levererad { get; set; }
        public string KundId { get; set; }

        public virtual AspNetUsers Kund { get; set; }
        public virtual ICollection<BestallningMatratt> BestallningMatratt { get; set; }
    }
}
