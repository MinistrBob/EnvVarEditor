using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvVarEditor
{
    public partial class ValueComplexVariable : UserControl
    {
        public ValueComplexVariable()
        {
            InitializeComponent();
        }

        public string varText
        { 
            get 
            {
                string varText=null;

                foreach (ListViewItem item in listView1.Items)
                {
                    varText=varText+item.SubItems[0].Text+";";
                }
                return varText; 
            } 
        }
    }
}
