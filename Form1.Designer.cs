﻿namespace EnvVarEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.LocalENVName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocalENVValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.GlobalENVName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GlobalENVValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btLocalCreate = new System.Windows.Forms.Button();
            this.btLocalChange = new System.Windows.Forms.Button();
            this.btLocalDelete = new System.Windows.Forms.Button();
            this.btGlobalCreate = new System.Windows.Forms.Button();
            this.btGlobalChange = new System.Windows.Forms.Button();
            this.btGlobalDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Переменные среды пользователя - ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LocalENVName,
            this.LocalENVValue});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(753, 147);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // LocalENVName
            // 
            this.LocalENVName.Text = "Переменная";
            this.LocalENVName.Width = 25;
            // 
            // LocalENVValue
            // 
            this.LocalENVValue.Text = "Значение";
            this.LocalENVValue.Width = 620;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(13, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 379);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Системные переменные";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GlobalENVName,
            this.GlobalENVValue});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.Location = new System.Drawing.Point(3, 16);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(753, 360);
            this.listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // GlobalENVName
            // 
            this.GlobalENVName.Text = "Переменная";
            this.GlobalENVName.Width = 25;
            // 
            // GlobalENVValue
            // 
            this.GlobalENVValue.Text = "Значение";
            this.GlobalENVValue.Width = 620;
            // 
            // btLocalCreate
            // 
            this.btLocalCreate.Location = new System.Drawing.Point(13, 198);
            this.btLocalCreate.Name = "btLocalCreate";
            this.btLocalCreate.Size = new System.Drawing.Size(75, 23);
            this.btLocalCreate.TabIndex = 2;
            this.btLocalCreate.Text = "Создать";
            this.btLocalCreate.UseVisualStyleBackColor = true;
            this.btLocalCreate.Click += new System.EventHandler(this.btLocalCreate_Click);
            // 
            // btLocalChange
            // 
            this.btLocalChange.Location = new System.Drawing.Point(102, 198);
            this.btLocalChange.Name = "btLocalChange";
            this.btLocalChange.Size = new System.Drawing.Size(75, 23);
            this.btLocalChange.TabIndex = 3;
            this.btLocalChange.Text = "Изменить";
            this.btLocalChange.UseVisualStyleBackColor = true;
            // 
            // btLocalDelete
            // 
            this.btLocalDelete.Location = new System.Drawing.Point(255, 198);
            this.btLocalDelete.Name = "btLocalDelete";
            this.btLocalDelete.Size = new System.Drawing.Size(75, 23);
            this.btLocalDelete.TabIndex = 4;
            this.btLocalDelete.Text = "Удалить";
            this.btLocalDelete.UseVisualStyleBackColor = true;
            this.btLocalDelete.Click += new System.EventHandler(this.btLocalDelete_Click);
            // 
            // btGlobalCreate
            // 
            this.btGlobalCreate.Location = new System.Drawing.Point(13, 633);
            this.btGlobalCreate.Name = "btGlobalCreate";
            this.btGlobalCreate.Size = new System.Drawing.Size(75, 23);
            this.btGlobalCreate.TabIndex = 5;
            this.btGlobalCreate.Text = "Создать";
            this.btGlobalCreate.UseVisualStyleBackColor = true;
            this.btGlobalCreate.Click += new System.EventHandler(this.btGlobalCreate_Click);
            // 
            // btGlobalChange
            // 
            this.btGlobalChange.Location = new System.Drawing.Point(102, 633);
            this.btGlobalChange.Name = "btGlobalChange";
            this.btGlobalChange.Size = new System.Drawing.Size(75, 23);
            this.btGlobalChange.TabIndex = 6;
            this.btGlobalChange.Text = "Изменить";
            this.btGlobalChange.UseVisualStyleBackColor = true;
            // 
            // btGlobalDelete
            // 
            this.btGlobalDelete.Location = new System.Drawing.Point(255, 633);
            this.btGlobalDelete.Name = "btGlobalDelete";
            this.btGlobalDelete.Size = new System.Drawing.Size(75, 23);
            this.btGlobalDelete.TabIndex = 7;
            this.btGlobalDelete.Text = "Удалить";
            this.btGlobalDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 668);
            this.Controls.Add(this.btGlobalDelete);
            this.Controls.Add(this.btGlobalChange);
            this.Controls.Add(this.btGlobalCreate);
            this.Controls.Add(this.btLocalDelete);
            this.Controls.Add(this.btLocalChange);
            this.Controls.Add(this.btLocalCreate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Environment Variables Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader LocalENVName;
        private System.Windows.Forms.ColumnHeader LocalENVValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader GlobalENVName;
        private System.Windows.Forms.ColumnHeader GlobalENVValue;
        private System.Windows.Forms.Button btLocalCreate;
        private System.Windows.Forms.Button btLocalChange;
        private System.Windows.Forms.Button btLocalDelete;
        private System.Windows.Forms.Button btGlobalCreate;
        private System.Windows.Forms.Button btGlobalChange;
        private System.Windows.Forms.Button btGlobalDelete;
    }
}

