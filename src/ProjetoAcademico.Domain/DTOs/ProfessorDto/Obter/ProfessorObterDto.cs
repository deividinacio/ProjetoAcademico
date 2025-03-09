using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.ProfessorDto.Obter
{
    public class ProfessorObterDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Biografia { get; set; }
    }
}
