using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

        public string Owner { get; set; }
        public PPM Preview { get; set; }
        public List<PositionedModel> PositionedModels
        {
            set { _positionedModellList = value;}
            get { return _positionedModellList; }
        }

        public BLCameraDTO CameraDTO { get; set; }

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
            _positionedModellList.Add(newElement);
            UpdateLastModificationDate();
        }

        public void RemovePositionedModel(PositionedModel posModel)
        {
            if (!ContainsPositionedModel(posModel.Model.Name, posModel.Position))
            {
                throw new BusinessLogicException("PositionedModel is not in scene");
            }
            else
            {
                PositionedModel instanceToRemove = GetPositionedModel(posModel.Model.Name, posModel.Position);
                _positionedModellList.Remove(instanceToRemove);
                UpdateLastModificationDate();
            }
        }

        public bool ContainsPositionedModel(string name, Vector position)
        {
            return GetPositionedModel(name, position) != null;
        }

        public PositionedModel GetPositionedModel(string name, Vector position)
        {
            return _positionedModellList.Find(m => m.Model.Name == name && m.Position.Equals(position));
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