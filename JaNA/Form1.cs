﻿using JaNA.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaNA
{
    public partial class Form1 : Form
    {
        #region singleton
        static Form1 app = null;
        public static Form1 Application
        {
            get
            {
                return app;
            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            app = this;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.Refresh();
            var timePeriod = DateTime.Now.Subtract(dateTimePicker1.Value);
            ParsingLogic.RunParseTask(timePeriod.Days);
        }

        private void Button2_Click(object sender, EventArgs e)
        {            
            Document doc = new Document();

            for (int i = 0; i < ParsingLogic.data.Rows.Count; i++)
            {
                ParsingLogic.data.Rows[i].SetField("Include", checkedListBox1.GetItemChecked(i));
            }
            doc.CreateReportDocument(ParsingLogic.data);
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Document d = new Document();
            d.CreateNumberdList();
        }
    }
}
