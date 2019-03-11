using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commission.Business
{
    class Parameter
    {
        private string _fmtArea;

        public string FmtArea
        {
            get { return _fmtArea; }
            set { _fmtArea = value; }
        }

        private string _fmtPrice;

        public string FmtPrice
        {
            get { return _fmtPrice; }
            set { _fmtPrice = value; }
        }

        private string  _fmtAmount;

        public string FmtAmount
        {
            get { return _fmtAmount; }
            set { _fmtAmount = value; }
        }

        private int _precisionArea;

        public int PrecisionArea
        {
            get { return _precisionArea; }
            set { _precisionArea = value; }
        }

        private int _precisionPrice;

        public int PrecisionPrice
        {
            get { return _precisionPrice; }
            set { _precisionPrice = value; }
        }

        private int _precisionAmount;

        public int PrecisionAmount
        {
            get { return _precisionAmount; }
            set { _precisionAmount = value; }
        }

    }
}
