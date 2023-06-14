using BusinessLogic.Exceptions;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.DomainObjects
{
    public class Scene
    {
        private List<PositionedModel> _positionedModellList;
        private string _name;

        public Scene()
        {
            _positionedModellList = new List<PositionedModel>();
            CreationDate = DateTimeProvider.Now;
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

        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastRenderDate { get; set; }

        public string Owner { get; set; }
        public PPM Preview { get; set; }
        public List<PositionedModel> PositionedModels
        {
            set { _positionedModellList = value; }
            get { return _positionedModellList; }
        }

        public BLCameraDTO CameraDTO { get; set; }

        public bool Blur { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new BusinessLogicException("Name cannot be blank");
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
                if (elem.Model.Name == model.Name && elem.Model.Owner == model.Owner) { return true; }
            }
            return false;
        }

        public void UpdateLastRenderDate()
        {
            LastRenderDate = DateTimeProvider.Now;
        }

        public void UpdateLastModificationDate()
        {
            LastModificationDate = DateTimeProvider.Now;
        }

        public void DropPositionedModels()
        {
            _positionedModellList.Clear();
        }

        public override bool Equals(object other)
        {
            Scene otherScene = (Scene)other;
            bool nameEquals = Name == otherScene.Name;
            bool creationDateEquals = CreationDate== otherScene.CreationDate;

            if (_name != otherScene._name)
                return false;


            if (CreationDate != otherScene.CreationDate ||
                LastModificationDate != otherScene.LastModificationDate ||
                LastRenderDate != otherScene.LastRenderDate)
                return false;

            if(!CameraEquals(otherScene.CameraDTO))
                return false;

            if (_positionedModellList.Count != otherScene._positionedModellList.Count)
                return false;

            foreach (PositionedModel positionedModel in _positionedModellList)
            {
                if (!otherScene._positionedModellList.Any(otherModel =>
                    positionedModel.Equals(otherModel)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CameraEquals(BLCameraDTO otherCamera)
        {
            if(CameraDTO.Aperture != otherCamera.Aperture ||
                CameraDTO.MaxDepth != otherCamera.MaxDepth ||
                CameraDTO.SamplesPerPixel != otherCamera.SamplesPerPixel ||
                !CameraDTO.Up.Equals(otherCamera.Up) ||
                CameraDTO.FieldOfView != otherCamera.FieldOfView ||
                !CameraDTO.LookAt.Equals(otherCamera.LookAt) ||
                !CameraDTO.LookFrom.Equals(otherCamera.LookFrom) ||
                CameraDTO.ResolutionY != otherCamera.ResolutionY ||
                CameraDTO.ResolutionX != otherCamera.ResolutionX)
                return false;
                


            return true;
        }
    }
}