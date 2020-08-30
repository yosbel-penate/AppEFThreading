using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Forms;

namespace AppEFThreading
{
    class EmployeerM
    {
        private bool multiThreaded;
        AdventureWorksDW2019Entities ctx;
        private const int TimeOut = 300;

        public EmployeerM(bool _multiThreaded)
        {
            multiThreaded = _multiThreaded;
        }

        public EmployeerM() : this(false)
        {
            ctx = new AdventureWorksDW2019Entities();
            ctx.Database.CommandTimeout = TimeOut;
        }

        public IEnumerable<DimEmployee> GetAll()
        {
            try
            {
                if (multiThreaded)
                {
                    using (AdventureWorksDW2019Entities ctx = new AdventureWorksDW2019Entities())
                    {
                        ctx.Database.CommandTimeout = TimeOut;
                        return ctx.DimEmployees.ToList();
                    }
                }
                else
                {

                    return ctx.DimEmployees.ToList();
                }
            }
            catch (EntityException)
            {
                throw;
            }
        }

        public DimEmployee GetEmployeerById(int id)
        {
            try
            {
                if (multiThreaded)
                {
                    using (AdventureWorksDW2019Entities ctx = new AdventureWorksDW2019Entities())
                    {
                        ctx.Database.CommandTimeout = TimeOut;
                        return ctx.DimEmployees.SingleOrDefault(d => d.EmployeeKey == id);
                    }
                }
                else
                {
                    return ctx.DimEmployees.SingleOrDefault(d => d.EmployeeKey == id);
                }
            }
            catch (EntityCommandExecutionException entityCommandExecutionException)
            {
                throw;
            }

        }

        public DimEmployee Create(DimEmployee employeer)
        {
            try
            {
                if (multiThreaded)
                {
                    using (AdventureWorksDW2019Entities ctx = new AdventureWorksDW2019Entities())
                    {
                        ctx.Database.CommandTimeout = TimeOut;
                        return _CreateEmployeer(employeer, ctx);
                    }
                }
                else
                {
                    return _CreateEmployeer(employeer, ctx);
                }
            }
            catch (EntityCommandExecutionException entityCommandExecutionException)
            {
                throw;
            }

            DimEmployee _CreateEmployeer(DimEmployee _employeer, AdventureWorksDW2019Entities _ctx)
            {
                _ctx.Database.CommandTimeout = TimeOut;
                _ctx.DimEmployees.Add(_employeer);
                _ctx.SaveChanges();
                return _employeer;
            }
        }
    }
}
