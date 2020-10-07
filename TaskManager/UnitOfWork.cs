using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager
{
    public class UnitOfWork : IUnitOfWork<Task>
    {
        public void Save(IList<Task> entities, string path)
        {
            var jsonData = JsonConvert.SerializeObject(entities);
            System.IO.File.WriteAllText(path, jsonData);
        }
    }
}
