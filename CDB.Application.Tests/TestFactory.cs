using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Domain.Interfaces.Repositories;
using CDB.Infra.Data.Fake;

namespace CDB.Application.Tests.Unit
{
    public class CalculoCdbServiceFactoryTest : CalculoCdbService() base(IServiceCollection services) 
    {
        public ICalculoCdbService CalculoCdbService { get; set; }

        public CalculoCdbServiceFactoryTest()
        {
            var mesesImpostoRepository = new MesesImpostoRepositoryFake();
            var tbCdiRepository = new TbCdiRepositorFake();
            CalculoCdbService = new CalculoCdbService(mesesImpostoRepository, tbCdiRepository);
        }
    }
}
