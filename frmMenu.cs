using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderProject
{
    public partial class frmMenu: Form
    {
        private frmSummary summaryForm = new frmSummary();
        public frmMenu()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            updateFormForDefault();
        }
        private void updateFormForDefault()
        {
            rdEatIn.Checked = true;
            rdMeduim.Checked = true;
            rdThinCrust.Checked = true;

            updateCrustType();
            updateSize();
            updateToppings();
           
        }
        private void resetForm()
        {
            bxSize.Enabled = true;
            bxCrustType.Enabled = true;
            bxToppings.Enabled = true;
            bxWereEat.Enabled = true;
            btnGoCheckout.Enabled = true;

            rdMeduim.Checked = true;
            rdThinCrust.Checked = true;
            rdEatIn.Checked = true;

            chkExtraChees.Checked = false;
            chkGreenPappers.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkTomatoes.Checked = false;

        }
        private void disableFormControls()
        {
            bxWereEat.Enabled = false;
            bxToppings.Enabled = false;
            bxSize.Enabled = false;
            bxCrustType.Enabled = false;
            btnGoCheckout.Enabled = false;
        }
        private float calculateSizePrice()
        {
            float Price = 0f;

            if (rdSmall.Checked)
            {
                Price = Convert.ToSingle(rdSmall.Tag);
            }
            else if (rdMeduim.Checked)
            {
                Price = Convert.ToSingle(rdMeduim.Tag);
            }
            else if (rdLarge.Checked)
            {
                Price = Convert.ToSingle(rdLarge.Tag);
            }
            return Price;

        }
        private float calculateToppingsPrice()
        {
            float Price = 0f;
            if (chkExtraChees.Checked)
                Price += Convert.ToSingle(chkExtraChees.Tag);

            if (chkMushrooms.Checked)
                Price += Convert.ToSingle(chkMushrooms.Tag);

            if (chkTomatoes.Checked)
                Price += Convert.ToSingle(chkTomatoes.Tag);

            if (chkOlives.Checked)
                Price += Convert.ToSingle(chkOlives.Tag);

            if (chkOnion.Checked)
                Price += Convert.ToSingle(chkOnion.Tag);

            if (chkGreenPappers.Checked)
                Price += Convert.ToSingle(chkGreenPappers.Tag);

            return Price;

        }
        private float calculateCrustTypePrice()
        {
            float Price = 0f;

            if (rdThinCrust.Checked)
                Price = Convert.ToSingle(rdThinCrust.Tag);

            else
                Price = Convert.ToSingle(rdThinkCrust.Tag);

            return Price;
        }
        private void calculateTotalPrice()
        {
            lblTotPrice.Text = (calculateCrustTypePrice() + calculateSizePrice() + calculateToppingsPrice()).ToString();
        }
        private void updateWhereToEatInSummary(string WhereToEat)
        {
            summaryForm.lblWereToEat.Text = WhereToEat;
        }
        private void updateWhereToEat()
        {
            if (rdEatIn.Checked)
                updateWhereToEatInSummary(rdEatIn.Text);

            else if (rdTakeOut.Checked)
                updateWhereToEatInSummary(rdTakeOut.Text);
        }
        private void updateCurstTypeInSummary(string CrustType)
        {
            summaryForm.lblCrustType.Text = CrustType;
        }
        private void updateCrustType()
        {
            calculateTotalPrice();
            if (rdThinCrust.Checked)
                updateCurstTypeInSummary(rdThinCrust.Text);

            else
                updateCurstTypeInSummary( rdThinkCrust.Text);
        }
        private void updateSizeInSummary(string Size)
        {
            summaryForm.lblSize.Text = Size;
        }
        private void updateSize()
        {
            calculateTotalPrice();

            if (rdSmall.Checked)
                updateSizeInSummary(rdSmall.Text);

            else if (rdMeduim.Checked)
                updateSizeInSummary(rdMeduim.Text);

            else if (rdLarge.Checked)
                updateSizeInSummary(rdLarge.Text);


        }
        private void updateToppingsInSummary(string Toppings)
        {
            summaryForm.lblToppings.Text = Toppings;
        }
        private void updateToppings()
        {
            calculateTotalPrice();
            string txtToppings = "";

            if (chkExtraChees.Checked)
                txtToppings += chkExtraChees.Text;

            if (chkMushrooms.Checked)
                txtToppings += "," + chkMushrooms.Text;

            if (chkTomatoes.Checked)
                txtToppings += "," + chkTomatoes.Text;

            if (chkOlives.Checked)
                txtToppings += "," + chkOlives.Text;

            if (chkOnion.Checked)
                txtToppings += "," + chkOnion.Text;

            if (chkGreenPappers.Checked)
                txtToppings += "," + chkGreenPappers.Text;

            if (txtToppings.StartsWith(","))
                txtToppings = txtToppings.Remove(0, 1);

            if (txtToppings.Equals(""))
                updateToppingsInSummary("No Toppings");
            else
                updateToppingsInSummary(txtToppings);

        }

        private void rdSmall_CheckedChanged(object sender, EventArgs e)
        {
            updateSize();
        }
        private void rdMeduim_CheckedChanged(object sender, EventArgs e)
        {
            updateSize();
        }
        private void rdLarge_CheckedChanged(object sender, EventArgs e)
        {
            updateSize();
        }
        private void btnGoCheckout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go to Checkout? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lblTotPrice.Text == "0")
                {
                    MessageBox.Show("Nothing to Checkout", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    disableFormControls();
                    summaryForm.lblTotPrice.Text = lblTotPrice.Text;
                    summaryForm.ShowDialog();

                }
            }
        }
        private void rdThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            updateCrustType();
        }
        private void rdThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            updateCrustType();;
        }
        private void rdEatIn_CheckedChanged(object sender, EventArgs e)
        {
            updateWhereToEat();
        }
        private void rdTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            updateWhereToEat();
        }
        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
        }
        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
        }
        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
        }
        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
        }
        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
        }
        private void chkGreenPappers_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
