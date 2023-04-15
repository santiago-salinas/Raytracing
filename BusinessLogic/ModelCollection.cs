using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ModelCollection
    {
        private List<Model> _modelList;

        public List<Model> ModelList
        {
            get { return _modelList; }
            set { _modelList = value; }
        }
        public ModelCollection()
        {
            _modelList = new List<Model>();
        }

        public bool ContainsModel(string name)
        {
            Model ret = _modelList.Find(m => m.Name == name);
            return ret != null;
        }

        public void AddModel(Model newElement)
        {
            if (!ContainsModel(newElement.Name))
            {
                _modelList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("Model with the same name already exists in the collection");
            }
        }

        public Model GetModel(string name)
        {
            Model ret = _modelList.Find(m => m.Name == name);
            if (ret == null) throw new BusinessLogicException("Model does not exist in the collection");
            return ret;
        }

        public void RemoveModel(string name)
        {
            Model model = _modelList.Find(s => s.Name == name);
            if (model == null)
            {
                throw new BusinessLogicException("Model does not exist in the collection");
            }
            _modelList.Remove(model);           
        }
    }
}
