using ProjetoAcademico.Domain.DTOs.Common;
using ProjetoAcademico.Domain.DTOs.CursoDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Listar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Obter;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Listar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Obter;
using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Domain.Interfaces.Repositories;
using ProjetoAcademico.Domain.Interfaces.Services;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.Services
{
    public class ServiceProfessor(IRepositoryProfessor repositoryProfessor): Notifiable, IServiceProfessor
    {
        public ServiceResponse<IEnumerable<ProfessorListarDto>> Listar()
        {
            var professores = repositoryProfessor.Listar();
            var professoresDto = professores.Select(professor => new ProfessorListarDto
            {
                Id = professor.Id,
                Nome = professor.Nome
            });
            return new ServiceResponse<IEnumerable<ProfessorListarDto>>(professoresDto, this);
        }

        public ServiceResponse<ProfessorObterDto> Obter(Guid id)
        {
            var professor = repositoryProfessor.Obter(id);
            if (professor is null) // ou if (professor == null)
            {
                AddNotification("Professor", "Professor não encontrado");
                return new ServiceResponse<ProfessorObterDto>(this);
            }

            var professorDto = new ProfessorObterDto()
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Bibliografia = professor.Biografia
            };

            return new ServiceResponse<ProfessorObterDto>(professorDto, this);
        }

        public ServiceResponse<BaseResponse> Adicionar(ProfessorAdicionarDto professorDto)
        {
            var validation = new ProfessorAdicionarDtoValidator().Validate(professorDto);
            if (!validation.IsValid)
            {
                AddNotifications(validation.Errors);
                return new ServiceResponse<BaseResponse>(this);
            }

            var professor = new Professor(
                professorDto.Nome,
                professorDto.Biografia);

            repositoryProfessor.Adicionar(professor);
            repositoryProfessor.Commit();

            return new ServiceResponse<BaseResponse>(
                new BaseResponse(professor.Id, "Professor adicionado com sucesso."),
                this);
        }

        public ServiceResponse<BaseResponse> Atualizar(ProfessorAtualizarDto professorDto)
        {
            var validation = new ProfessorAtualizarDtoValidator().Validate(professorDto);
            if (!validation.IsValid)
            {
                AddNotifications(validation.Errors);
                return new ServiceResponse<BaseResponse>(this);
            }

            var professor = repositoryProfessor.Obter(professorDto.Id);
            if (professor is null)
            {
                AddNotification("Professor", "Professor não encontrado");
                return new ServiceResponse<BaseResponse>(this);
            }

            professor.Atualizar(
                professorDto.Nome,
                professorDto.Biografia
            );

            repositoryProfessor.Commit();

            return new ServiceResponse<BaseResponse>(new BaseResponse(professor.Id, "Professor Atualizado com Sucesso."), this);
        }
        public ServiceResponse<BaseResponse> Remover(Guid id)
        {
            var professor = repositoryProfessor.Obter(id);
            if (professor is null)
            {
                AddNotification("Professor", "Professor não encontrado");
                return new ServiceResponse<BaseResponse>(this);
            }

            repositoryProfessor.Remover(professor);
            repositoryProfessor.Commit();

            return new ServiceResponse<BaseResponse>(new BaseResponse(id, "Professor Removido com Sucesso."), this);
        }

        public ServiceResponse<BaseResponse> Atualizar(ProfessorListarDto professorDto)
        {
            throw new NotImplementedException();
        }
    }
}
