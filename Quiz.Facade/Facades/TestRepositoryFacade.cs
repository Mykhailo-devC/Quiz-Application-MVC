using Quiz.Logic;
using Quiz.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Facade.Facades
{
    public class TestRepositoryFacade : RepositoryFacade<Answer>
    {
        public TestRepositoryFacade(RepositoryFactory factory) : base(factory)
        {
        }
    }
}
