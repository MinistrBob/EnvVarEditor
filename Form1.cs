using System;
using System.Collections;
using System.Windows.Forms; 

namespace EnvVarEditor
{
    public partial class Form1 : Form
    {
        // Окно редактора переменных
        ValueEditor ValueEditor = new ValueEditor();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            groupBox1.Text = "Переменные среды пользователя - " + Environment.UserName.ToUpper();
            groupBox2.Text = "Системные переменные - " + Environment.MachineName.ToUpper();
            UserEnvListRefresh();
            MachineEnvListRefresh();

        }

        private void UserEnvListRefresh()
        {
            listView1.Items.Clear();
            // Переменные User из HKEY_CURRENT_USER\Environment
            IDictionary environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
            foreach (DictionaryEntry de in environmentVariables)
            {
                ListViewItem lvi = new ListViewItem(new string[] { de.Key.ToString(), de.Value.ToString() });
                listView1.Items.Add(lvi);
            }
            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -1;
        }

        private void MachineEnvListRefresh()
        {
            listView2.Items.Clear();
            // Переменные Machine из HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment
            IDictionary environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            foreach (DictionaryEntry de in environmentVariables)
            {
                ListViewItem lvi = new ListViewItem(new string[] { de.Key.ToString(), de.Value.ToString() });
                listView2.Items.Add(lvi);
            }
            listView2.Columns[0].Width = -1;
            listView2.Columns[1].Width = -1;
        }

        private void btLocalCreate_Click(object sender, EventArgs e)
        {
            ValueEditor.Text = "Создание новой переменной пользователя " + Environment.UserName.ToUpper();
            ValueEditor.VariableType = "User";
            CreateSimpleControl();
            ValueEditor.ShowDialog();
            UserEnvListRefresh();
        }

        private void btGlobalCreate_Click(object sender, EventArgs e)
        {
            ValueEditor.Text = "Создание системной переменной " + Environment.MachineName.ToUpper();
            ValueEditor.VariableType = "Machine";
            CreateSimpleControl();
            ValueEditor.ShowDialog();
            MachineEnvListRefresh();
        }

        private void CreateSimpleControl()
        {
            EnvVarEditor.ValueSimpleVariable ctrEditor = new EnvVarEditor.ValueSimpleVariable();
            ctrEditor.Dock = DockStyle.Fill;
            ValueEditor.groupBox2.Controls.Add(ctrEditor);
        }

        private void CreateComplexControl()
        {
            EnvVarEditor.ValueComplexVariable ctrEditor = new EnvVarEditor.ValueComplexVariable();
            ctrEditor.Dock = DockStyle.Fill;
            ValueEditor.groupBox2.Controls.Add(ctrEditor);
        }

        private void btLocalDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить переменную " + listView1.SelectedItems[0].Text + "?", "Удалить переменную?",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Environment.SetEnvironmentVariable(listView1.SelectedItems[0].Text, null, EnvironmentVariableTarget.User);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    UserEnvListRefresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите переменную для удаления");
            }

        }

        private void btGlobalDelete_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить переменную " + listView2.SelectedItems[0].Text + "?", "Удалить переменную?",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Environment.SetEnvironmentVariable(listView2.SelectedItems[0].Text, null, EnvironmentVariableTarget.Machine);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    MachineEnvListRefresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите переменную для удаления");
            }
        }

        private void btLocalChange_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ValueEditor.Text = "Редактирование переменной пользователя " + listView1.SelectedItems[0].Text;
                ValueEditor.VariableType = "User";
                ValueEditor.VariableName = listView1.SelectedItems[0].Text;
                ValueEditor.VariableValue = listView1.SelectedItems[0].SubItems[1].Text;
                if (listView1.SelectedItems[0].SubItems[1].Text.Contains(";"))
                {
                    CreateComplexControl();
                }
                else
                {
                    CreateSimpleControl();
                }
                ValueEditor.ShowDialog();
                UserEnvListRefresh();
            }
            else
            {
                MessageBox.Show("Выберите переменную для редактирования");
            }
        }

        private void btGlobalChange_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ValueEditor.Text = "Редактирование системной переменной " + listView2.SelectedItems[0].Text;
                ValueEditor.VariableType = "Machine";
                ValueEditor.VariableName = listView2.SelectedItems[0].Text;
                ValueEditor.VariableValue = listView2.SelectedItems[0].SubItems[1].Text;
                if (listView2.SelectedItems[0].SubItems[1].Text.Contains(";"))
                {
                    CreateComplexControl();
                }
                else
                {
                    CreateSimpleControl();
                }
                ValueEditor.ShowDialog();
                MachineEnvListRefresh();
            }
            else
            {
                MessageBox.Show("Выберите переменную для редактирования");
            }
        }
    }
}
