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
    public partial class ValueSimpleVariable : UserControl
    {
        public ValueSimpleVariable()
        {
            InitializeComponent();
        }

        public string varText { get {return textBox1.Text;} }
    }
}
