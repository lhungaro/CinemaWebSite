using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Domain.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Date { get; set; }
        public string Theater { get; set; }
        public string TicketPrice { get; set; }
        public int AvailableSeats { get; set; }
    }
}
