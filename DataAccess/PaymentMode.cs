using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Commission.DataAccess
{
    public class PaymentMode
    {
        public PaymentMode()
        {

        }

        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _payName;

        public string PayName
        {
            get { return _payName; }
            set { _payName = value; }
        }
        private string _payTypeCode;

        public string PayTypeCode
        {
            get { return _payTypeCode; }
            set { _payTypeCode = value; }
        }
        private string _payTypeName;

        public string PayTypeName
        {
            get { return _payTypeName; }
            set { _payTypeName = value; }
        }
        private string _downPayRate;

        public string DownPayRate
        {
            get { return _downPayRate; }
            set { _downPayRate = value; }
        }
        private string _standardCode;

        public string StandardCode
        {
            get { return _standardCode; }
            set { _standardCode = value; }
        }
        private string _standardName;

        public string StandardName
        {
            get { return _standardName; }
            set { _standardName = value; }
        }
        private string _baseCode;

        public string BaseCode
        {
            get { return _baseCode; }
            set { _baseCode = value; }
        }
        private string _baseName;

        public string BaseName
        {
            get { return _baseName; }
            set { _baseName = value; }
        }
        private string _memo;

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private PayType _paymentType;

        public PayType PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }


        public void GetPaymentModeByID(string id)
        {
            string sql = string.Format("select ID,PayName, PayType, PayTypeName,DownPayRate,StandardCode,StandardName,BaseCode,BaseName,Memo from PaymentMode where ID = {0}", id);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            if (sdr.Read())
            {
                _id = sdr["ID"].ToString();
                _payName = sdr["PayName"].ToString();
                _payTypeCode = sdr["PayType"].ToString();
                _payTypeName = sdr["PayTypeName"].ToString();
                _downPayRate = sdr["DownPayRate"].ToString();
                _standardCode = sdr["StandardCode"].ToString();
                _standardName = sdr["StandardName"].ToString();
                _baseCode = sdr["BaseCode"].ToString();
                _baseName = sdr["BaseName"].ToString();
                _memo = sdr["Memo"].ToString();
                _paymentType = (PayType)sdr["PayType"];
            }

        }



    }
}
