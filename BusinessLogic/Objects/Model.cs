using System;

namespace BusinessLogic
{
    public class Model
    {
        private string _name;
        public Model() { }

        public Model(string name, Sphere shape, Lambertian color, string owner)
        {
            Name = name;
            Shape = shape;
            Material = color;
            Owner = owner;
        }

        public HitRecord IsHitByRay(Ray ray, double tMin, double tMax, Vector position)
        {
            HitRecord hit = Shape.IsHitByRay(ray, tMin, tMax, position);
            hit.Attenuation = Material.Color;
            return hit;
        }

        public void RenderPreview()
        {
            Scene testScene = new Scene();

            Model model = new Model()
            {
                Material = this.Material,
                Shape = new Sphere() { Radius = 1 },
            };

            Vector position = new Vector(1, 1, 1);
            PositionedModel positionedModel = new PositionedModel()
            {
                Model = model,
                Position = position
            };

            testScene.AddPositionedModel(positionedModel);


            testScene.CameraDTO = new CameraDTO()
            {
                LookFrom = new Vector(0, 5, 0),
                LookAt = new Vector(1, 1, 1),
                Up = new Vector(0, 1, 0),
                FieldOfView = 40,
                ResolutionX = 50,
                ResolutionY = 50,
                SamplesPerPixel = 50,
                MaxDepth = 10,
            };


            Engine renderEngine = new Engine(testScene);
            Preview = renderEngine.Render();
        }

        public Ray GetBouncedRay(HitRecord hitRecord)
        {
            return Material.GetBouncedRay(hitRecord);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                value = value.Trim();
                CheckIfStringNull(value);
                _name = value;
            }
        }

        public string Owner { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }


        public Sphere Shape { get; set; }

        public Lambertian Material { get; set; }

        public PPM Preview { get; set; }

        public override bool Equals(object other)
        {
            bool nameEqual = this.Name == ((Model)other).Name;
            bool shapeEqual = this.Shape == ((Model)other).Shape;
            bool colorEqual = this.Material == ((Model)other).Material;

            return nameEqual && shapeEqual && colorEqual;
        }

    }
}
