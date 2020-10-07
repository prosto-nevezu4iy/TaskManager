using Microsoft.Extensions.DependencyInjection;
using System;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddScoped<ITaskRepository, TaskRepository>()
            .AddSingleton<IUnitOfWork<Task>, UnitOfWork>()
            .BuildServiceProvider();

            var task = new Task
            {
                Id = Guid.NewGuid(),
                Name = "Sleep"
            };

            var repository = serviceProvider.GetService<ITaskRepository>();
            repository.Add(task);

            var unitOfWork = serviceProvider.GetService<IUnitOfWork<Task>>();
            unitOfWork.Save(repository.GetAll(), repository.Path);
        }
    }
}
