using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.ProfessorDto.Listar
{
    public class ProfessorListarDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Biografia { get; set; }
    }
}
