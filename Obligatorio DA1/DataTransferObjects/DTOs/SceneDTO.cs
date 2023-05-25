using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class SceneDTO
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastRenderDate { get; set; }
        public string Owner { get; set; }
        public PpmDTO Preview { get; set; }
        public List<PositionedModelDTO> PositionedModels { get; set; }
        public CameraDTO CameraDTO { get; set; }
    }
}
