using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvVarEditor
{
    public partial class ValueEditor : Form
    {

        // Тип переменной User или Machine
        public string VariableType {get; set;}

        public ValueEditor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            EnvironmentVariableTarget target;
            if (VariableType=="User")
            {
                target=EnvironmentVariableTarget.User;
            }
            else
            {
                target=EnvironmentVariableTarget.Machine;
            }
            //
            string varText = null;
            // Если контрол ValueComplexVariable то это преобразование вернет null
            var c = groupBox2.Controls[0] as ValueSimpleVariable;
            // Если ValueSimpleVariable
            if (c != null)
                varText = c.varText;
            var d = groupBox2.Controls[0] as ValueComplexVariable;
            // Если ValueSimpleVariable
            if (d != null)
                varText = d.varText;
            //MessageBox.Show(c.varText);
            // Имя переменной должно быть
            if (string.IsNullOrEmpty(varText))
            {
                MessageBox.Show("Задайте имя переменной");
                return;
            }            
            // Значение переменной должно быть
            if (string.IsNullOrEmpty(varText))
            {
                MessageBox.Show("Задайте значение переменной");
                return;
            }

            try
            {
                Environment.SetEnvironmentVariable(tbVarName.Text, varText, target);
            }
            catch (Exception)
            {
                    
                throw;
            }
            
        }

    }
}
