using System.Windows.Forms;

namespace EnvVarEditor
{
    public partial class ValueSimpleVariable : UserControl
    {
        public ValueSimpleVariable()
        {
            InitializeComponent();
        }

        public string varText 
        { 
            get 
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text=value;
            }
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (textBox1.Text.Length > 2048)
                {
                    toolStripStatusLabel1.Text = textBox1.Text.Length.ToString() + " - Рекомендуемая длина переменной 2048 символов";
                }
                else
                {
                    toolStripStatusLabel1.Text = textBox1.Text.Length.ToString();
                } 
            }
        }
    }
}
