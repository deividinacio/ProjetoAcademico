using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademico.Domain.Entities.Base
{
    public abstract class EntityBase // abstrct serve para não permir que a clase seja instanciada, somente herdada
    {
        public Guid Id { get; protected set; } = Guid.NewGuid(); // Guid gera de forma randomica letras e números (assim na url não será passado o id do cara)
        // deixamos o SET como protect para que somente classe Entitybase e quem herdar dela, possa alterar
       // essa  propriedade
    
    }
}
