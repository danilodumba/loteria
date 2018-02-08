using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain
{
    public class MegaSena : Jogo
    {
        public MegaSena()
            :base(1, 60, 6, 4)
        {

        }

        public override void SetGanhadores(List<int> numeros)
        {
            throw new NotImplementedException();
        }
    }
}
