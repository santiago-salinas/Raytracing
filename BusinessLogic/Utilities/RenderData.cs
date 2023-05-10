using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utilities
{
    public class RenderData
    {
        public int height { set; get; }
        public int width { set; get; }
        public int aspectRatio { get { return width / height; } } 
        public int samplesPerPixel { get; set; }
        public int maxBounces { get; set; }        

    }
}
