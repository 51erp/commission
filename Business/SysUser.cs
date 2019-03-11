using System;
using System.Collections.Generic;
using System.Text;

namespace Commission.Business
{
    class SysUser
    {
        private string _userID;

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private SysUserType _userType;

        public SysUserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        private string _roleID;

        public string RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        private string _roleName;

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        private string _projectID;

        public string ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }
        private string _projectName;

        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }
    }

    enum SysUserType
    {
        supermanager = 0,
        user = 1,
    }
}
