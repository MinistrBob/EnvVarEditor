using System;
using System.Windows.Forms;
using System.Security;

namespace EnvVarEditor
{
    public partial class ValueEditor : Form
    {


        // Тип переменной User или Machine
        public EnvironmentVariableTarget VariableType { get; set; }
        // Имя переменной 
        public string VariableName { get; set; }
        // Значение переменной
        public string VariableValue { get; set; }
        //
        public string VariableLength { get; set; }

        public ValueEditor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExitValueEditor();
        }

        /// <summary>
        /// Выход из процедуры с Dispose control, чтобы при следующем открытии формы был нужный контрол
        /// </summary>
        private void ExitValueEditor()
        {
            groupBox2.Controls[0].Dispose();
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            EnvironmentVariableTarget target = VariableType;
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
            if (string.IsNullOrEmpty(tbVarName.Text))
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

            if (varText.Length>32767)
            {
                MessageBox.Show("Переменная не может быть длинее 32767 символов");
                return;
            }

            try
            {
                Environment.SetEnvironmentVariable(tbVarName.Text, varText, target);
            }
            catch (SecurityException)
            {
                MessageBox.Show("У вас нет прав на выполение данной операции");
                // Остаёмся в этом же окне, чтобы дать пользователю возможность исправить переменную
                return;
            }
            catch (Exception)
            {

                throw;
            }

            ExitValueEditor();
            
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
