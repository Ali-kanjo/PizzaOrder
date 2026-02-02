using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderProject
{
    public partial class frmSummary: Form
    {
        public frmSummary()
        {
            InitializeComponent();
        }

        private void lblToppings_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (lblToppings.Right >=groupBox2.ClientSize.Width - 2)
            {
               lblToppings.Font = new Font(lblToppings.Font.FontFamily, 7);
            }
            else
            {
               lblToppings.Font = new Font(lblToppings.Font.FontFamily, 12);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to order this? ", "Final confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show("The order was placed successfully.", "Successful operation", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("The process was not completed successfully.", "Failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
            this.Close();
        }
    }
}
