using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEFThreading
{
    public class EmployeerMV : IEmployeerMV
    {
        private EmployeerM employeerDAO;

        public EmployeerMV() : this(false) { }

        public EmployeerMV(bool isMultiThreaded)
        {
            employeerDAO=new EmployeerM(isMultiThreaded);
        }

        public DimEmployee Create(DimEmployee employeer)
        {
            return employeerDAO.Create(employeer);
        }

        public IEnumerable<DimEmployee> GetAll()
        {
            return employeerDAO.GetAll();
        }

        public DimEmployee GetEmployeerById(int id)
        {
            return employeerDAO.GetEmployeerById(id);
        }
    }
}
