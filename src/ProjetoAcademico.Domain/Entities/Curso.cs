using ProjetoAcademico.Domain.Entities.Base;
using ProjetoAcademico.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.Entities
{
    public class Curso : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public EnumPeriodo Periodo { get; set;}
        public string ? Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public int QuantidadeMaximaAlunos { get; set; }
       
        
        // Nome string  50
        // Periodo (Manhã, Tarde, Noite) -> Enumerador
        // Descrição 500
        // Carga Horária -int 
        // Quantidade Máxima de ALunos -int

        // Construtor
        public Curso(string nome,EnumPeriodo periodo,string? descricao,int cargaHoraria,int quantidadeMaximaAlunos) 
        { 
            Nome = nome;
            Periodo = periodo;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            QuantidadeMaximaAlunos = quantidadeMaximaAlunos;

        }
        // Metodos

        public void Atualizar( string nome , EnumPeriodo periodo, string? descricao, int cargaHoraria, int quantidadeMaximAlunos)
        {
            Nome = nome;
            Periodo = periodo;
            Descricao = descricao;
            CargaHoraria= cargaHoraria;
            QuantidadeMaximaAlunos= quantidadeMaximAlunos;
        }

    }
}
