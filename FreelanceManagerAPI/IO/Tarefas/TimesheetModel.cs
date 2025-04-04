
using System.ComponentModel.DataAnnotations;

namespace FreelanceManagerAPI.IO.Tarefas
{
        public class TimesheetModel
        {
                public Guid Id { get; set; }
                [Required]
                public Guid TarefaId { get; set; }
                public DateTime? Date { get; set; }
                [Required]
                public string Hours { get; set; }
                [MaxLength(500)]
                public string Notes { get; set; }
            
        }
}