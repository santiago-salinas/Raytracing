using BusinessLogic;
using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface IModelManagement
    {
        Model ConvertToModel(ModelDTO modelDTO);
        ModelDTO ConvertToModelDTO(Model model);
        PPM ConvertToPPM(PpmDTO dto);
        PpmDTO ConvertPpmToDTO(PPM ppm);
    }
}
