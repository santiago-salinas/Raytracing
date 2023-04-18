using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Scene
    {
        private List<Model> _positionedModellList;

        public Scene()
        {
            _positionedModellList = new List<Model>();
        }

        public string Name { get; set; }
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