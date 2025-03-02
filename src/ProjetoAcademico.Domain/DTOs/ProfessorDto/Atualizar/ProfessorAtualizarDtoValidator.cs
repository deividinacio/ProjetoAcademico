using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar
{
    public class ProfessorAtualizarDtoValidator : AbstractValidator<ProfessorAtualizarDto>
    {

        public ProfessorAtualizarDtoValidator()
        {
            RuleFor(p => p.Nome)
         .NotEmpty().WithMessage("Nome é obrigatório")
         .MaximumLength(50).WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(p => p.Biografia)
                    .NotEmpty().WithMessage("Biografia é obrigatório")
                    .MaximumLength(1000).WithMessage("Biografia não pode ultrapassar 1000 caracteres ");

        }

    }
}
