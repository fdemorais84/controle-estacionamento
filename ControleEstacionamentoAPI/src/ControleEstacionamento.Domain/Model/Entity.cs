using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstacionamento.Domain.Model
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

    }
}
