using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dtos.WorkDtos;

namespace TodoApp.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto dto);
        Task GetById(object id);
        Task Remove(object id);
        Task Update(object id, WorkUpdateDto dto);
    }
}
