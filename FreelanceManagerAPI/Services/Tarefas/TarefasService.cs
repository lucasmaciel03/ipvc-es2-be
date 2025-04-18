using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.UnitOfWork;
using FreelanceManagerAPI.IO.Tarefas;
using Microsoft.EntityFrameworkCore;

namespace FreelanceManagerAPI.Services.Tarefas
{
    public class TarefasService : ITarefasService
    {
        private IUnitOfWork _unitOfWork;
        public TarefasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TarefaDto>> GetAllAsync() => await _unitOfWork.TarefasRepository.GetEntityAsNoTracking().Select(t => new TarefaDto(t)).ToListAsync();

        public async Task<TarefaDto> GetByIdAsync(Guid id) => await _unitOfWork.TarefasRepository.GetEntityAsNoTracking(t => t.Id == id).Select(t => new TarefaDto(t)).FirstAsync();

        public async Task<TarefaDto> CreateAsync(TarefaModel model)
        {
            int newNumber = await GetNextNumberAsync();
            var entity = await _unitOfWork.TarefasRepository.CreateAsync(new Tarefa(model, newNumber));
            return await GetByIdAsync(entity.Id);
        }
        public async Task<TarefaDto> UpdateAsync(Guid id, TarefaModel model)
        {
            var entity = await _unitOfWork.TarefasRepository.GetEntityAsNoTracking(t => t.Id == id).FirstAsync();

            entity.Code = model.Code;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;
            entity.Notes = model.Notes;
            entity.Status = model.Status;

            await _unitOfWork.TarefasRepository.Edit(entity);

            return await GetByIdAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.TarefasRepository.Delete(id);
        }

        public async Task<bool> CanDeleteAsync(Guid id) => true;

        private async Task<int> GetNextNumberAsync()
        {
            List<int> lastInternalNumber = await _unitOfWork.
                ClientsRepository.
                GetEntityAsNoTracking().
                Select(entity => entity.InternalNumber).
                ToListAsync();

            int newNumber = 1;
            if (lastInternalNumber.Any())
                newNumber = lastInternalNumber.Max() + 1;

            return newNumber;
        }

        public async Task<string> GetNextCodeAsync()
        {
            int newNumber = await GetNextNumberAsync();
            return $"TAR{newNumber.ToString("0000")}";
        }

    }
}