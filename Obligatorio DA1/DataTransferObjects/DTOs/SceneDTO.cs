using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace DataTransferObjects
{
    public class SceneDTO
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastRenderDate { get; set; }
        public string Owner { get; set; }
        public bool Blur { get; set; }
        public PpmDTO Preview { get; set; }
        public List<PositionedModelDTO> PositionedModels { get; set; }
        public UICameraDTO CameraDTO { get; set; }
    }
}
