using System;
using System.Collections;
using System.Windows.Forms;
using System.Security;
using Microsoft.Win32; 

namespace EnvVarEditor
{
    public partial class Form1 : Form
    {
        // Окно редактора переменных
        ValueEditor ValueEditor = new ValueEditor();

        public Form1()
        {
            InitializeComponent();
            DC.IsSendMessages = checkBox1.Checked;
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
                    // Если галочка рассылать сообщения стоит, сообщения рассылаются, но удаление медленное, 
                    // иначе делаем все через реестр - быстро.
                    if (DC.IsSendMessages)
                    {
                        try
                        {
                            Environment.SetEnvironmentVariable(lv.SelectedItems[0].Text, null, target);
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
                    }
                    else
                    {
                        RegistryKey regKey;
                        if (target == EnvironmentVariableTarget.User)
                        {
                            regKey = Registry.CurrentUser.OpenSubKey(@"Environment", true);
                        }
                        else
                        {
                            regKey = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Session Manager\Environment", true);
                        }
                        using (regKey)
                        {
                            regKey.DeleteValue(lv.SelectedItems[0].Text);

                        }
                    }
                    
                    // Просто обновление экрана
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
            if (lv.SelectedItems.Count == 1)
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
                MessageBox.Show("Выберите одну переменную для редактирования");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DC.IsSendMessages = checkBox1.Checked;
        }

    }
}
