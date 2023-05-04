using BusinessLogic.Objects;
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

        private User _owner;
        private PPM _preview;

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

        public User Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public PPM Preview
        {
            get { return _preview; }
            set { _preview = value; }
        }

        public List<PositionedModel> PositionedModels
        {
            get { return _positionedModellList; }
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
            /*if (_positionedModellList.Find(
                s => (s.PositionedModelModel == newElement.PositionedModelModel)
                    && (s.PositionedModelPosition == newElement.PositionedModelPosition)) == null)*/
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
           /* PositionedModel positionedModel = _positionedModellList.Find(s => (s.PositionedModelModel == oldElement.PositionedModelModel) 
                                                                        && (s.PositionedModelPosition == oldElement.PositionedModelPosition));*/


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
           /* PositionedModel positionedModel = _positionedModellList.Find(s => (s.PositionedModelModel == element.PositionedModelModel) 
                                                                        && (s.PositionedModelPosition == element.PositionedModelPosition));*/
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