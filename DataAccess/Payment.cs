using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commission.DataAccess
{
    class Payment
    {
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _name;

        public string Name
        {
            get 
            {
                if (!_code.Equals(""))
                    _name = SqlHelper.ExecuteScalar("select Name from DictPayment where Code = " + _code).ToString();
                return _name; 
            }
            set { _name = value; }
        }
    }
}
