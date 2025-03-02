using ProjetoAcademico.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.Entities
{
    public class Professor : EntityBase
    {
       
   
        public string Nome { get; set; } = string.Empty;
        public string Biografia { get; set; }


        public Professor (string nome, string biografia)
        {
            Nome = nome;
            Biografia = biografia;
        }

        public void Atualizar(string nome, string biografia)
        {
            Nome = nome;
            Biografia = biografia;
        }
    }
}
