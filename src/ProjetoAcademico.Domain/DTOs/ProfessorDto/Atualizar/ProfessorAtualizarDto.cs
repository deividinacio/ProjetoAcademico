﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar
{
    public class ProfessorAtualizarDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;
    }
}
