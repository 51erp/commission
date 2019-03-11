using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    //partial
    public  partial class BaseFrmAdd : Form
    {
        public BaseFrmAdd()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual  void toolStripButton_Save_Click(object sender, EventArgs e)
        {

        }
    }
}
