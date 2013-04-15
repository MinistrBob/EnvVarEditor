using System;
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
            set
            {
                string[] SplitedVarValue = value.Split(';');
                listView1.Items.Clear();
                foreach (string item in SplitedVarValue)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { item });
                    listView1.Items.Add(lvi);
                }
                listView1.Columns[0].Width = -1;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listView1.Items.Remove(listView1.SelectedItems[i]);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Выберите переменную для перемещения");
            }    
            else if (listView1.SelectedItems.Count == 1)
            {
                if (listView1.SelectedItems[0].Index == 0)
                    return;
                ListViewItem selected = listView1.SelectedItems[0];
                int indx = selected.Index;
                int totl = listView1.Items.Count;

                if (indx == 0)
                {
                    listView1.Items.Remove(selected);
                    listView1.Items.Insert(totl - 1, selected);
                }
                else
                {
                    listView1.Items.Remove(selected);
                    listView1.Items.Insert(indx - 1, selected);
                }
            }
            else
            {
                MessageBox.Show("Вы можете перемещать только одну строку. Выберите строку еще раз.",
                    "Выбрано много строк", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Выберите переменную для перемещения");
            }
            else if (listView1.SelectedItems.Count == 1)
            {
                if (listView1.SelectedItems[0].Index == listView1.Items.Count - 1)
                    return;    
                ListViewItem selected = listView1.SelectedItems[0];
                int indx = selected.Index;
                int totl = listView1.Items.Count;

                if (indx == totl - 1)
                {
                    listView1.Items.Remove(selected);
                    listView1.Items.Insert(0, selected);
                }
                else
                {
                    listView1.Items.Remove(selected);
                    listView1.Items.Insert(indx + 1, selected);
                }
            }
            else
            {
                MessageBox.Show("Вы можете перемещать только одну строку. Выберите строку еще раз.",
                    "Выбрано много строк", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ListViewItem listItem = new ListViewItem("Новая строка");
            listView1.Items.Add(listItem);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckVarLength();
        }

        private void ValueComplexVariable_Load(object sender, EventArgs e)
        {
            CheckVarLength();
        }

        private void CheckVarLength()
        {
            if (!string.IsNullOrEmpty(varText))
            {
                if (varText.Length > 2048)
                {
                    toolStripStatusLabel1.Text = varText.Length.ToString() + " - Рекомендуемая длина переменной 2048 символов";
                }
                else
                {
                    toolStripStatusLabel1.Text = varText.Length.ToString();
                } 
            }
        }

    }
}
