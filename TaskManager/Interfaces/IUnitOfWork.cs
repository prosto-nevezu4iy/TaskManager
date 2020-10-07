using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Interfaces
{
    public interface IUnitOfWork<T>
    {
        void Save(IList<T> entities, string path);
    }
}
