using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Domain.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int SessionId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataDaCompra { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Seat { get; set; }
    }
}
