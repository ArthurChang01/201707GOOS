using System;

namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(Budget budget);
        T Read(Func<T, bool> func);
    }
}
