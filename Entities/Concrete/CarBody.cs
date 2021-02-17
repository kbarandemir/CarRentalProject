using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarBody : IEntity
    {
        public int CarBodyId { get; set; }
        public string CarBodyName { get; set; }
    }
}
