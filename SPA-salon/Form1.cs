using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_salon
{
    public partial class Form1 : Form
    {
        Model1Container m = new Model1Container();

        public Form1()
        {
            InitializeComponent();

            groupBox1.Visible = false;

            comboBox3.DataSource = m.CategorySet.ToList();
            comboBox3.DisplayMember = "Name_cat";
            comboBox3.ValueMember = "Id";

            comboBox2.Items.Add("User");
            comboBox2.Items.Add("Admin");

            textBox2.Text = "28.10.2018";
            textBox8.Text = "00:00:00";

            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            groupBox2.Visible = false;

            textBox7.Visible = false;
            button5.Visible = false;

            dataGridView1.DataSource = m.ServicesSet.ToList();
            dataGridView2.DataSource = m.PurchaseSet.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Admin")
            {
                if (textBox1.TextLength == 0)
                    textBox1.Visible = true;
                else
                if (textBox1.Text == "admin")
                    WorkWithAdmin();
            }
            else
                groupBox1.Visible = true;
        }
        
        private void WorkWithAdmin()
        {
            
            groupBox1.Visible = false;
            button3.Visible = true;
            button4.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Visible = true;
            button5.Visible = true; ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Name_cat = textBox7.Text;

            ValidationContext context = new ValidationContext(cat, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(cat, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                m.CategorySet.Add(cat);
                m.SaveChanges();
            }

            textBox7.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            Services ser = new Services();
            ser.Name_ser = textBox5.Text;
            ser.Price = Int32.Parse(textBox6.Text);
            ser.Time = TimeSpan.Parse(textBox8.Text);
            ser.Id_cat = comboBox3.SelectedIndex+1;

            ValidationContext context = new ValidationContext(ser, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(ser, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                m.ServicesSet.Add(ser);
                m.SaveChanges();
                dataGridView1.DataSource = m.ServicesSet.ToList();
            }

            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Purchase p = new Purchase();
            p.Person = textBox3.Text;
            p.Phone = textBox4.Text;
            p.Date = DateTime.Parse(textBox2.Text);
            p.Id_ser = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;


            ValidationContext context = new ValidationContext(p, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(p, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                m.PurchaseSet.Add(p);
                m.SaveChanges();
                dataGridView2.DataSource = m.PurchaseSet.ToList();
            }

            textBox3.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }
    }
}
