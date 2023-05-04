using BusinessLogic.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace BusinessLogic
{
    public class Scene
    {
        private List<PositionedModel> _positionedModellList;
        private string _name;

        private DateTime _creationDate;
        private DateTime _lastModificationDate;
        private DateTime _lastRenderDate;

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

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }
        public DateTime LastModificationDate
        {
            get { return _lastModificationDate; }
            set { _lastModificationDate = value; }
        }
        public DateTime LastRenderDate
        {
            get { return _lastRenderDate; }
            set { _lastRenderDate = value; }
        }


        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public List<PositionedModel> GetModels()
        {
            return _positionedModellList;
        }

        public void AddPositionedModel(PositionedModel newElement)
        {
            PositionedModel oldElement = GetPositionedModelLike(newElement);
            if (oldElement is null)
            {
                _positionedModellList.Add(newElement);
                LastModificationDate = DateTime.Now;
            }
            else
            {
                throw new BusinessLogicException("Duplicated PositionedModel in Scene");
            }
        }

        public void RemovePositionedModel(PositionedModel element)
        {
            PositionedModel elementToRemove = GetPositionedModelLike(element);
            if (elementToRemove is null)
            {
                throw new BusinessLogicException("PositionedModel is not in scene");
            }
            else
            {
                _positionedModellList.Remove(elementToRemove);
                LastModificationDate = DateTime.Now;
            }
        }
        private PositionedModel GetPositionedModelLike(PositionedModel element)
        {
            return _positionedModellList.Find(s => (s.PositionedModelModel == element.PositionedModelModel) && (s.PositionedModelPosition == element.PositionedModelPosition));
        }

        public bool ContainsPositionedModel(PositionedModel element)
        {
            PositionedModel positionedModel = _positionedModellList.Find(s => (s.PositionedModelModel == element.PositionedModelModel) && (s.PositionedModelPosition == element.PositionedModelPosition));
            return positionedModel != null;
        }

        public bool ContainsModel(string name)
        {
            foreach (PositionedModel model in _positionedModellList)
            {
                if (model.PositionedModelModel.Name == name) { return true; }
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