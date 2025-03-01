﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar
{
    public class CursoAtualizarDtoValidator : AbstractValidator<CursoAtualizarDto>
    {
        public CursoAtualizarDtoValidator()
        {
            RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");

            RuleFor(p => p.Periodo)
                .NotEmpty().WithMessage("Período é obrigatório");

            RuleFor(p => p.Descricao)
                .MaximumLength(500).WithMessage("Descrição deve ter no máximo 500 caracteres");

            RuleFor(p => p.CargaHoraria)
                .NotEmpty().WithMessage("Carga horária é obrigatória")
                .GreaterThan(0).WithMessage("Carga horária deve ser maior que 0");

            RuleFor(p => p.QuantidadeMaximaAlunos)
                .NotEmpty().WithMessage("Quantidade máxima de alunos é obrigatória")
                .GreaterThan(0).WithMessage("Quantidade máxima de alunos deve ser maior que 0");
        }
    }
}
