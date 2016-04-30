using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETProject.Models.Domain;

namespace NETProject.Models.DAL
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        T FindById(int id);
    }
}
