using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Scene
    {
        private List<PositionedModel> _positionedModellList;
        private string _name;

        public Scene()
        {
            _positionedModellList = new List<PositionedModel>();
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

        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastRenderDate { get; set; }

        public User Owner
        {
            get;
            set;
        }

        public PPM Preview
        {
            get;
            set;
        }
        public List<PositionedModel> PositionedModels
        {
            get { return _positionedModellList; }
        }

        public CameraDTO CameraDTO
        {
            set; get;
        }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be blank");
            }
        }        

        public List<PositionedModel> GetModels()
        {
            return _positionedModellList;
        }

        public void AddPositionedModel(PositionedModel newElement)
        {
            if (!ContainsPositionedModel(newElement))
            {
                _positionedModellList.Add(newElement);
                LastModificationDate = DateTime.Now;
            }
            else
            {
                throw new BusinessLogicException("Duplicated PositionedModel in Scene");
            }
        }

        public void RemovePositionedModel(PositionedModel oldElement)
        {
            if (!ContainsPositionedModel(oldElement))
            {
                throw new BusinessLogicException("PositionedModel is not in scene");
            }
            else
            {
                _positionedModellList.Remove(oldElement);
                LastModificationDate = DateTime.Now;
            }

        }

        public bool ContainsPositionedModel(PositionedModel element)
        {
           return _positionedModellList.Contains(element);
        }

        public bool ContainsModel(Model model)
        {
            foreach (PositionedModel elem in _positionedModellList)
            {
                if (elem.PositionedModelModel == model) { return true; }
            }
            return false;
        }

        public void RenderScene()
        {
            LastRenderDate = DateTime.Now;
        }

        public void DropPositionedModels()
        {
            _positionedModellList.Clear();
        }

    }
}