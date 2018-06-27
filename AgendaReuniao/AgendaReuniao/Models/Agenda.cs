using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgendaReuniao.Models
{
    public class Agenda
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo deve ser preenchido!")]
        public string Evento { get; set; }
        [Required(ErrorMessage = "O campo deve ser preenchido!")]
        public string Responsavel { get; set; }
        [Required(ErrorMessage = "O campo deve ser preenchido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo deve ser preenchido!")]
        public DateTime DataHora { get; set; }
        [Required(ErrorMessage = "O campo deve ser preenchido!")]
        public string Status { get; set; }

    }
}