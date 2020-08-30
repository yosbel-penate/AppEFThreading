using System.Collections.Generic;

namespace AppEFThreading
{
    public interface IEmployeerMV
    {
        DimEmployee Create(DimEmployee employeer);
        IEnumerable<DimEmployee> GetAll();
        DimEmployee GetEmployeerById(int id);
    }
}