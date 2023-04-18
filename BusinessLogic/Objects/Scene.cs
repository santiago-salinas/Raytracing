using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessLogic
{
    public class Scene
    {
        private List<Model> _positionedModellList;
        private string _name;

        public Scene()
        {
            _positionedModellList = new List<Model>();
        }

        public string Name {
            get { return _name; }
            set
            {
                value = value.Trim();
                CheckIfStringNull(value);
                _name = value;
            }
        }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public Vector LookFrom { get; set; }
        public Vector LookAt { get; set; }

        public void AddPositionedModel(PositionedModel positionedModel) { 
        
        }

        public void RemovePositionedModel(PositionedModel positionedModel)
        {

        }

        public bool ContainsPositionedModel(PositionedModel positionedModel)
        {
            Random gen = new Random();
            return gen.Next(100) < 50 ? true : false;
        }

        public void DropPositionedModels()
        {
            
        }
    }
}