using System.Collections.Generic;

namespace BusinessLogic
{
    public class UserObjectsCollection
    {
        private List<UserObject> _userObjectList;
        public UserObjectsCollection()
        {
            _userObjectList = new List<UserObject>();
        }
        public bool AddUserObject(UserObject newElement)
        {
            if (_userObjectList.Find(s => s.Name == newElement.Name) == null)
            {
                _userObjectList.Add(newElement);
                return true;
            }
            else
            {
                throw new BusinessLogicException("UserObject with the same name already exists in the collection");
            }

        }

        public UserObject GetUserObject(string name)
        {
            UserObject ret = _userObjectList.Find(s => s.Name == name);
            if (ret == null) throw new BusinessLogicException("UserObject does not exist in the collection");
            return ret;
        }

        public bool RemoveUserObject(string name)
        {
            UserObject userobject = _userObjectList.Find(s => s.Name == name);
            if (userobject == null)
            {
                throw new BusinessLogicException("UserObject does not exist in the collection");
            }
            _userObjectList.Remove(userobject);
            return true;
        }
    }
}