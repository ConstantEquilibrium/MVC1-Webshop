using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class MatrattMatrattTypViewModel
    {
        public List<Matratt> MatrattList { get; set; }
        public List<MatrattTyp> MatrattTypList { get; set; }

        public MatrattMatrattTypViewModel()
        {
            MatrattList = new List<Matratt>();
            MatrattTypList = new List<MatrattTyp>();
        }
    }
}
