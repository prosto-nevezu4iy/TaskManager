using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository, IRepository<Task>
    {
        public string Path { get; } = "/Projects/TaskManager/TaskManager/db.json";
        private readonly IUnitOfWork<Task> _unitOfWork;

        public TaskRepository(IUnitOfWork<Task> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Task entity)
        {
            var tasks = GetAll();

            tasks.Add(entity);

            _unitOfWork.Save(tasks, Path);
        }

        public void Delete(Task entity)
        {
            var tasks = GetAll();

            tasks.Remove(entity);

            _unitOfWork.Save(tasks, Path);
        }

        public IList<Task> GetAll()
        {
            var jsonData = System.IO.File.ReadAllText(Path);

            return JsonConvert.DeserializeObject<List<Task>>(jsonData) ?? new List<Task>();
        }

        public void Update(Guid id, Task entity)
        {
            var tasks = GetAll();

            tasks.FirstOrDefault(t => t.Id == id).Name = entity.Name;

            _unitOfWork.Save(tasks, Path);
        }
    }
}
