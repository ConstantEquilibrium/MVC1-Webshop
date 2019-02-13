using System;
using System.Collections.Generic;

namespace Inlämning_2___Webshop.Models
{
    public partial class MatrattProdukt
    {
        public int MatrattId { get; set; }
        public int ProduktId { get; set; }

        public virtual Matratt Matratt { get; set; }
        public virtual Produkt Produkt { get; set; }
    }
}
