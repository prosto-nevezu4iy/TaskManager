using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Interfaces
{
    public interface ITaskRepository : IRepository<Task>
    {
    }
}
