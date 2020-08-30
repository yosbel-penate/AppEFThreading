using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppEFThreading
{
    class EmployeerM
    {
        private bool multiThreaded;
        AdventureWorksDW2019Entities ctx;
        private const int TimeDelay= 300;

        public EmployeerM(bool _multiThreaded)
        {
            multiThreaded = _multiThreaded;
        }

        public EmployeerM():this(false)
        {
            ctx = new AdventureWorksDW2019Entities();
            ctx.Database.CommandTimeout = TimeDelay;
        }

        public IEnumerable<DimEmployee> GetAll()
        {
            if (multiThreaded)
            {
                using (AdventureWorksDW2019Entities ctx = new AdventureWorksDW2019Entities())
                {
                    ctx.Database.CommandTimeout = TimeDelay;
                    return ctx.DimEmployees.ToList();
                }
            }
            else
            {
                return ctx.DimEmployees.ToList();
            }
        }

        public DimEmployee GetEmployeerById(int id)
        {
            if (multiThreaded)
            {
                using (AdventureWorksDW2019Entities ctx = new AdventureWorksDW2019Entities())
                {
                    ctx.Database.CommandTimeout = TimeDelay;
                    return ctx.DimEmployees.SingleOrDefault(d => d.EmployeeKey == id);
                }
            }
            else
            {
                return ctx.DimEmployees.SingleOrDefault(d => d.EmployeeKey == id);
            }
        }

        public DimEmployee Create(DimEmployee employeer)
        {
            if (multiThreaded)
            {
                using (AdventureWorksDW2019Entities ctx = new AdventureWorksDW2019Entities())
                {
                    ctx.Database.CommandTimeout = TimeDelay;
                    return _CreateEmployeer(employeer, ctx);
                }
            }
            else
            {
                return _CreateEmployeer(employeer, ctx);
            }

            DimEmployee _CreateEmployeer(DimEmployee _employeer, AdventureWorksDW2019Entities _ctx)
            {
                _ctx.Database.CommandTimeout = TimeDelay;
                _ctx.DimEmployees.Add(_employeer);
                _ctx.SaveChanges();
                return _employeer;
            }
        }
    }
}
