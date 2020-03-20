using blogCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Interfaces
{
    public interface ITag
    {
        List<Tag> GetAll(); 
    }
}
