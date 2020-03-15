using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Interfaces
{
    public interface IUnitOfWork
    {
        IPost Post { get; }
        ITag Tag { get; }
        void Save();
    }
}
