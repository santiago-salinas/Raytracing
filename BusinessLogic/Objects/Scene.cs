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
            _creationDate = DateTimeProvider.Now;
            UpdateLastModificationDate();
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

        private DateTime _creationDate;
        private DateTime _lastModificationDate;
        private DateTime _lastRenderDate;

        public DateTime CreationDate { get { return _creationDate; }}
        public DateTime LastModificationDate { get {return _lastModificationDate; } }
        public DateTime LastRenderDate { get { return _lastRenderDate; }}

        public User Owner { get; set; }
        public PPM Preview { get; set; }
        public List<PositionedModel> PositionedModels
        {
            get { return _positionedModellList; }
        }

        public CameraDTO CameraDTO { get; set; }

        public bool Blur { get; set; }

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
                UpdateLastModificationDate();
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
                UpdateLastModificationDate();
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
                if (elem.Model == model) { return true; }
            }
            return false;
        }

        public void UpdateLastRenderDate()
        {
            _lastRenderDate = DateTimeProvider.Now;
        }

        public void UpdateLastModificationDate()
        {
            _lastModificationDate = DateTimeProvider.Now;
        }

        public void DropPositionedModels()
        {
            _positionedModellList.Clear();
        }

    }
}