using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.entidades
{
       public class CursoDisciplinaEntidade
    {
        public long Id { get; set; }
        public long DisciplinaId { get; set; }
        public long CursoId { get; set; }
        public string Periodo { get; set; }
        public string NomeDisciplina { get; set; }
        public string NomeCurso { get; set; }
        public object[] Linha()
        {
            return new object[] { NomeCurso, NomeDisciplina, Periodo };
        }
    }
   
}
