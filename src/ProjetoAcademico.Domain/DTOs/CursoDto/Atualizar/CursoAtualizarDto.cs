using ProjetoAcademico.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar
{
    public class CursoAtualizarDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public EnumPeriodo   Periodo { get; set; }
        public string ? Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public int QuantidadeMaximaAlunos { get; set; }
    }
}
