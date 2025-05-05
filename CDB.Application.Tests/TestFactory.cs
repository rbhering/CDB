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
    public  class TestFactory 
    {
        private  IMesesImpostoRepository _mesesImpostoRepository;
        private  ITbCdiRepository _tbCdiRepository;

        public ICalculoCdbService CalculoCdbService { get; set; } 

        public TestFactory()
        {
            _mesesImpostoRepository = new MesesImpostoRepositoryFake();
            _tbCdiRepository = new TbCdiRepositorFake();
            CalculoCdbService = new CalculoCdbService(_mesesImpostoRepository, _tbCdiRepository);   
        }
    }
}
