using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Domain.Interfaces.Repositories;
using ProjetoAcademico.Infra.Data.Context;
using ProjetoAcademico.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Infra.Data.Repositories
{
    public class RepositoryProfessor(ProjetoAcademicoContext context)
        : RepositoryBase<Professor>(context), IRepositoryProfessor;
    
}
