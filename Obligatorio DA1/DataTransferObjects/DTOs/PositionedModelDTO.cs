﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PositionedModelDTO
    {
        public ModelDTO ModelDTO { get; set; }
        public VectorDTO Position { get; set; } 
    }
}
