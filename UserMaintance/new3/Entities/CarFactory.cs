using new3.Abstractions;
using new3.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new3.Entities
{
    public class CarFactory : IToyFactory

    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
