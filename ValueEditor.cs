using System;
using System.Windows.Forms;

namespace EnvVarEditor
{
    public partial class ValueEditor : Form
    {


        // Тип переменной User или Machine
        public string VariableType {get; set;}
        // Имя переменной 
        public string VariableName { get; set; }
        // Значение переменной
        public string VariableValue { get; set; }

        public ValueEditor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Controls[0].Dispose();
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
            // (Если контрол ValueComplexVariable то это преобразование вернет null)
            var c = groupBox2.Controls[0] as ValueSimpleVariable;
            // Если ValueSimpleVariable
            if (c != null)
                varText = c.varText;
            var d = groupBox2.Controls[0] as ValueComplexVariable;
            // Если ValueComplexVariable
            if (d != null)
                varText = d.varText.TrimEnd(';');
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
            
            groupBox2.Controls[0].Dispose();
            this.Close();
            
        }

        private void ValueEditor_Load(object sender, EventArgs e)
        {
            this.tbVarName.Text = VariableName;

            // (Если контрол ValueComplexVariable то это преобразование вернет null)
            var c = groupBox2.Controls[0] as ValueSimpleVariable;
            // Если ValueSimpleVariable
            if (c != null)
                c.varText = VariableValue;
            // Если ValueComplexVariable
            var d = groupBox2.Controls[0] as ValueComplexVariable;
            if (d != null)
                d.varText = VariableValue;
        }

    }
}
