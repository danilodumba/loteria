using Loteria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Application
{
    public class SorteioService : ISorteioService
    {
        public void Sortear(Sorteio sorteio)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISorteioService
    {
        void Sortear(Sorteio sorteio);
    }
}
