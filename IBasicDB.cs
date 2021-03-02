using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    interface IBasicDB<T> where T : IPoco
    {
        void Add(T t);
        T Get();
        List<T> GetAll();
        void Remove(long id);
        void Update(T t);
    }
}
