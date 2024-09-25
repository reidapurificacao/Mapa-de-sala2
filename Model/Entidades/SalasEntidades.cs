using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class SalasEntidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NumComputadores { get; set; }
        public int NumCadeiras { get; set; }
        public bool Disponivel { get; set; }
        public bool IsLab { get; set; }
        public object[] Linha()
        {
            return new object[] { Id, Nome, NumComputadores, NumCadeiras, Disponivel, IsLab };
        }
    }
}
