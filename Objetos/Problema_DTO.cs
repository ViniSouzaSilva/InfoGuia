using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbiTroubleShooting.Objetos
{
    class Problema_DTO
    {
        public int ID_PROBLEMA { get; set; }
        public string DESCRICAO_PROBLEMA { get; set; }
        public int ID_PRODUTO { get; set; }
       public bool Finalizou { get; set; }
    }
}
