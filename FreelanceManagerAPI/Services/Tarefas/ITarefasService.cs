using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.Tarefas;

namespace FreelanceManagerAPI.Services.Tarefas
{
    public interface ITarefasService
    {
        Task<List<TarefaDto>> GetAllAsync();
        Task<TarefaDto> GetByIdAsync(Guid id);
        Task<TarefaDto> CreateAsync(TarefaModel model);
        Task<TarefaDto> UpdateAsync(Guid id, TarefaModel model);
        Task DeleteAsync(Guid id);
        Task<bool> CanDeleteAsync(Guid id);
        Task<string> GetNextCodeAsync();

    }
}