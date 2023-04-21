using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Objects
{
    public class User
    {
        private String _userName;
        private String _passHash;
        private DateTime _registerDate;

        public User() { }

        public String UserName { 
            get { return _userName;  } 
            set { _userName = value; }
        } 

        public String PassHash
        {
            get { return _passHash;  }
            set { _passHash = value; }
        }

        public DateTime RegisterDate
        {
            get { return _registerDate;  }
            set { _registerDate = value; }
        }
         
    }
}
