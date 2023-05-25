using BusinessLogic;
using DataTransferObjects;

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
