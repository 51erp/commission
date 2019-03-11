using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Commission.DataAccess
{
    public class Customer
    {
        private string _id;
        private string _customerName;
        private string _phone;
        private string _PID;
        private string _addr;
        private string _type;



        public string CustomerID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        public string Addr
        {
            get { return _addr; }
            set { _addr = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public bool getCustomerByID(string id)
        {
            bool result = false;

            string sql = "select CustomerID,CusName,Phone,PID,Addr,CusType from Customer where CustomerID = " + id;

            SqlDataReader rdr = SqlHelper.ExecuteReader(sql);

            if (rdr.Read())
            {
                _id = rdr["CustomerID"].ToString();
                _customerName = rdr["CusName"].ToString();
                _phone = rdr["Phone"].ToString();
                _PID = rdr["PID"].ToString();
                _addr = rdr["Addr"].ToString();
                _type = rdr["CusType"].ToString();

                result = true;
            }

            return result;
        }
    }
}
