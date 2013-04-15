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
            toolTip1.SetToolTip(this.checkBox1, "Все запущенные приложения не замечают сделаных изменений переменных. Если включить рассылку оповещений, то вновь запускаемые приложения будут видеть изменения переменных. Но при этом все действия с переменными будут происходить долго. Если рассылку не включать то чтобы прилдожения могли увидеть изменения, нужно будет перезагрузить компьютер. При этом все действия с переменными будут происходить очень быстро.");
            groupBox1.Text = "Переменные среды пользователя - " + Environment.UserName.ToUpper();
            groupBox2.Text = "Системные переменные - " + Environment.MachineName.ToUpper();
            UserEnvListRefresh();
            MachineEnvListRefresh();

        }

        private void UserEnvListRefresh()
        {
            // Переменные User из HKEY_CURRENT_USER\Environment
            ListRefresh(listView1, EnvironmentVariableTarget.User);
        }

        private void MachineEnvListRefresh()
        {
            // Переменные Machine из HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment
            ListRefresh(listView2, EnvironmentVariableTarget.Machine);
        }

        private void ListRefresh(ListView lv, EnvironmentVariableTarget target)
        {
            lv.Items.Clear();
            IDictionary environmentVariables;
            if (target==EnvironmentVariableTarget.User)
            {
                environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);    
            }
            else
            {
                environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            }
            foreach (DictionaryEntry de in environmentVariables)
            {
                ListViewItem lvi = new ListViewItem(new string[] { de.Key.ToString(), de.Value.ToString() });
                lv.Items.Add(lvi);
            }
            lv.Columns[0].Width = -1;
            lv.Columns[1].Width = -1;
        }

        private void btLocalCreate_Click(object sender, EventArgs e)
        {
            ValueEditor.Text = "Создание новой переменной пользователя " + Environment.UserName.ToUpper();
            ValueEditor.VariableType = EnvironmentVariableTarget.User;
            CreateSimpleControl();
            ValueEditor.ShowDialog();
            UserEnvListRefresh();
        }

        private void btGlobalCreate_Click(object sender, EventArgs e)
        {
            ValueEditor.Text = "Создание системной переменной " + Environment.MachineName.ToUpper();
            ValueEditor.VariableType = EnvironmentVariableTarget.Machine;
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
            DeleteEnv(listView1, EnvironmentVariableTarget.User);
        }

        private void btGlobalDelete_Click(object sender, EventArgs e)
        {
            DeleteEnv(listView2, EnvironmentVariableTarget.Machine);
        }

        private void DeleteEnv(ListView lv, EnvironmentVariableTarget target)
        {
            if (lv.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить переменную " + lv.SelectedItems[0].Text + "?", "Удалить переменную?",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Environment.SetEnvironmentVariable(lv.SelectedItems[0].Text, null, target);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    if (target == EnvironmentVariableTarget.User)
                    {
                        UserEnvListRefresh();
                    }
                    else
                    {
                        MachineEnvListRefresh();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Выберите переменную для удаления");
            }
        }

        private void btLocalChange_Click(object sender, EventArgs e)
        {
            EditEnv(listView1, EnvironmentVariableTarget.User);
        }

        private void btGlobalChange_Click(object sender, EventArgs e)
        {
            EditEnv(listView2, EnvironmentVariableTarget.Machine);
        }

        private void EditEnv(ListView lv, EnvironmentVariableTarget target)
        {
            if (lv.SelectedItems[0].Text.Length > 0)
            {
                ValueEditor.Text = "Редактирование переменной " + lv.SelectedItems[0].Text;
                ValueEditor.VariableType = target;
                ValueEditor.VariableName = lv.SelectedItems[0].Text;
                ValueEditor.VariableValue = lv.SelectedItems[0].SubItems[1].Text;
                if (lv.SelectedItems[0].SubItems[1].Text.Contains(";"))
                {
                    CreateComplexControl();
                }
                else
                {
                    CreateSimpleControl();
                }
                ValueEditor.ShowDialog();
                if (target == EnvironmentVariableTarget.User)
                {
                    UserEnvListRefresh();
                }
                else
                {
                    MachineEnvListRefresh();
                }
                
            }
            else
            {
                MessageBox.Show("Выберите переменную для редактирования");
            }
        }
    }
}
