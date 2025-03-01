using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.CursoDto.Listar
{
    public class CursoListarDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
    }
}
