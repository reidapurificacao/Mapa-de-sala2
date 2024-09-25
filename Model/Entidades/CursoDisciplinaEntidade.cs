using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class CursoDisciplinaEntidade
    {
        public long Id { get; set; }
        public long DisciplinaID { get; set; }
        public long CursoId { get; set; }
        public string Periodo { get; set; }

        public object[] Linha()
        {
            return new object[] { Id, DisciplinaID,CursoId };        }
    }
}
