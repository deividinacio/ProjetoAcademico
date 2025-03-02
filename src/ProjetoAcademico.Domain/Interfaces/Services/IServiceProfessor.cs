using ProjetoAcademico.Domain.DTOs.Common;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Listar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Obter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.Interfaces.Services
{
    public interface IServiceProfessor
    {
        ServiceResponse<IEnumerable<ProfessorListarDto>> Listar();
        ServiceResponse<ProfessorObterDto> Obter(Guid id);
        ServiceResponse<BaseResponse> Adicionar(ProfessorAdicionarDto professorDto);
        ServiceResponse<BaseResponse> Atualizar(ProfessorAtualizarDto professorDto);
        ServiceResponse<BaseResponse> Remover(Guid id);

    }
}
