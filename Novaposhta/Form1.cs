using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novaposhta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0; comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 0; comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.SelectedIndex = 0; comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            ce.Add(new ceis(numericUpDown1, maskedTextBox1, maskedTextBox2));
            radioButton1.Checked = true;
        }
        int count = 0;
        List<ceis> ce = new List<ceis>();
        private void label9_Click(object sender, EventArgs e)
        {
            if (count <= 6)
            {
                count++;
                MaskedTextBox txo = new MaskedTextBox();
                txo.Location = new Point(105, 58 + count * 33);
                txo.Size = new Size(100, 31);
                txo.Mask = "00000";
                txo.Name = $"txo{count}";
                txo.ValidatingType = typeof(int);
                groupBox1.Controls.Add(txo);
                MaskedTextBox txd = new MaskedTextBox();
                txd.Location = new Point(237, 58 + count * 33);
                txd.Size = new Size(100, 31);
                txd.Mask = "00000";
                txd.Name = $"txd{count}";
                txd.ValidatingType = typeof(int);
                groupBox1.Controls.Add(txd);
                NumericUpDown nu = new NumericUpDown();
                nu.Location = new Point(17, 58 + count * 33);
                nu.Maximum = 99;
                nu.Minimum = 1;
                nu.Name = $"nu{count}";
                nu.Size = new Size(54, 31);
                nu.TabIndex = 0;
                groupBox1.Controls.Add(nu);
                ce.Add(new ceis(nu, txo, txd));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                comboBox3.Items.Clear();
                string[] st = { "№1", "№2", "№3", "№4" };
                comboBox3.Items.AddRange(st);
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                comboBox3.Items.Clear();
                string[] st = { "№1", "№2", "№3", "№4" };
                comboBox3.Items.AddRange(st);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                comboBox3.Items.Clear();
                string[] st = { "№1", "№2", "№3", "№4" };
                comboBox3.Items.AddRange(st);
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                comboBox3.Items.Clear();
                string[] st = { "№1", "№2", "№4" };
                comboBox3.Items.AddRange(st);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cen = 0, p = 0, pg = 1;
            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex) { pg = 2; }
            if (radioButton2.Checked) { cen += 25; }
            if (checkBox1.Checked) { cen += 60; }
            for (int i = 0; i < ce.Count; i++)
            {
                if (ce[i].txo.Text != "" && ce[i].txd.Text != "")
                {
                    if (ce[i].nu.Value < 25 && int.Parse(ce[i].txd.Text) < 50) { cen += 30 / pg; }
                    else { cen += 70 / pg; }
                    p++;
                }
                else { break; }
            }
            if (p == ce.Count)
            {
                textBox1.Text = cen.ToString();
                ce.Clear();
                groupBox1.Controls.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                groupBox1.Controls.Add(numericUpDown1); numericUpDown1.Value = 1;
                groupBox1.Controls.Add(maskedTextBox1); maskedTextBox1.Text = "";
                groupBox1.Controls.Add(maskedTextBox2); maskedTextBox2.Text = "";
                groupBox1.Controls.Add(label6);
                groupBox1.Controls.Add(label7);
                groupBox1.Controls.Add(label8);
                groupBox1.Controls.Add(label9);
                ce.Add(new ceis(numericUpDown1, maskedTextBox1, maskedTextBox2));
                count = 0;
            }
        }
    }
}
