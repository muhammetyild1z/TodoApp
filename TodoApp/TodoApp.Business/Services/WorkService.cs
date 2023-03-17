using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Business.Interfaces;
using TodoApp.DataAccsess.UnitOfWork;
using TodoApp.Dtos.WorkDtos;
using TodoApp.Entities.Concrete;

namespace TodoApp.Business.Services
{
    internal class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new()
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });

            await _uow.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();
            var worklist = new List<WorkListDto>();

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    worklist.Add(new()
                    {
                        Definition = item.Definition,
                        Id = item.Id,
                        IsCompleted = item.IsCompleted

                    });
                }
            }
            return worklist;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var work = await _uow.GetRepository<Work>().GetById( id);
            return new()
            {
                Definition = work.Definition,
                IsCompleted = work.IsCompleted
            };
        }

        public async Task Remove(object id)
        {
            var deletedWork = await _uow.GetRepository<Work>().GetById(id);
            _uow.GetRepository<Work>().Remove(deletedWork);
            await _uow.SaveChanges();
        }

        public async Task Update(object id, WorkUpdateDto  dto)
        {
            var upWork = await _uow.GetRepository<Work>().GetById(id);
            upWork.Definition = dto.Definition;
            upWork.IsCompleted = dto.IsCompleted;
            //_uow.GetRepository<Work>().Update(new()
            //{
            //    Definition = dto.Definition,
            //    Id = dto.Id,
            //    IsCompleted = dto.IsCompleted,
            //});
            await _uow.SaveChanges();

        }

        //
        Task IWorkService.Create(WorkCreateDto dto)
        {
            throw new NotImplementedException();
        }
        //
        Task<List<WorkListDto>> IWorkService.GetAll()
        {
            throw new NotImplementedException();
        }
        //
        Task IWorkService.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}

