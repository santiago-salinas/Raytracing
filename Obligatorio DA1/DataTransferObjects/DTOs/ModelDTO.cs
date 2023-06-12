namespace DataTransferObjects
{
    public class ModelDTO
    {
        public string Name { get; set; }
        public SphereDTO Shape { get; set; }
        public MaterialDTO Material { get; set; }
        public string OwnerName { get; set; }
        public PpmDTO Preview { get; set; }

        public ModelDTO() { }

    }
}
