using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Commission.DataAccess
{
    class SaleItem
    {
        private string _ID;

        public string ItemID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _building;

        public string Building
        {
            get { return _building; }
            set { _building = value; }
        }
        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        private string _itemNum;

        public string ItemNum
        {
            get { return _itemNum; }
            set { _itemNum = value; }
        }

        private string _itemTypeCode;

        public string ItemTypeCode
        {
            get
            {
                return _itemTypeCode; 
            }
            set 
            {
                _itemTypeCode = value;
            }
        }

        private string _itemTypeName;

        public string ItemTypeName
        {
            get { return _itemTypeName; }
            set { _itemTypeName = value; }
        }

        private string _isBind;

        public string IsBind
        {
            get { return _isBind; }
            set { _isBind = value; }
        }


        private string _area;

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public bool getSaleItemByID(string id)
        {
            bool result = false;

            string sql = "select ItemID,Building,Unit,ItemNum,Area, Price, ItemTypeCode,ItemTypeName,IsBind from SaleItem where ItemID = " + id;

            SqlDataReader rdr = SqlHelper.ExecuteReader(sql);

            if (rdr.Read())
            {
                _ID = rdr["ItemID"].ToString();
                _building = rdr["Building"].ToString();
                _unit = rdr["Unit"].ToString();
                _itemNum = rdr["ItemNum"].ToString();
                _area = rdr["Area"].ToString();
                _price = double.Parse(rdr["Price"].ToString()).ToString("F4") ;
                _itemTypeCode = rdr["ItemTypeCode"].ToString();
                _itemTypeName = rdr["ItemTypeName"].ToString();
                _isBind = rdr["IsBind"].ToString();

                result = true;
            }

            return result;
        }

        
    }

    public enum SaleItemType
    {
        all = 0,
        house = 1,      
        bissness = 2,
        basement = 3,
        parking = 4
    }
}
