using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEFThreading
{
    class EmployeerThreaded
    {
        EmployeerMV emp=new EmployeerMV(true);

        public Task<DimEmployee> Create(DimEmployee employeer)
        {
            return Task<DimEmployee>.Factory.StartNew(() => {
                return emp.Create(employeer);
            });         
        }

        public Task<IEnumerable<DimEmployee>> GetAll()
        {
            return Task<IEnumerable<DimEmployee>>.Factory.StartNew(() => {
                return emp.GetAll();
            });            
        }

        public Task<DimEmployee> GetEmployeerById(int id)
        {
            return Task<DimEmployee>.Factory.StartNew(() => {
                return emp.GetEmployeerById(id);
            });
        }
    }
}
