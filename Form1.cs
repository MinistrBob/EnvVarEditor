using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections; 

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
            string varText = null;

            foreach (ListViewItem item in listView1.Items)
            {
                varText = varText + item.SubItems[0].Text + ";";
            } 
        }
    }
}
