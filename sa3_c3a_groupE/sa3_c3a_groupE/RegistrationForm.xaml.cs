using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sa3_c3a_groupE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationForm : ContentPage
    {
        private double f_h_result = 0;
        private double f_w_result = 0;
        private double f_s_result = 0;
        public RegistrationForm()
        {
            InitializeComponent();
            height_unit.Items.Add("centimeters");
            height_unit.Items.Add("feet");
            weight_unit.Items.Add("kilograms");
            weight_unit.Items.Add("pounds");
            salary_unit.Items.Add("US dollar");
            salary_unit.Items.Add("UK pound");
            salary_unit.Items.Add("Japanese yen");
            salary_unit.Items.Add("KSA riyal");
            salary_unit.Items.Add("UAE dirham");
        }

        private void hu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_h_unit = "--";
            float entered_height = 0;
            double h_result = 0;
            if (!(height_unit.SelectedIndex == -1))
            {
                selected_h_unit = height_unit.SelectedItem.ToString();
            }
            if (!string.IsNullOrEmpty(user_height.Text))
            {
                entered_height = float.Parse(user_height.Text);
            }

            switch(selected_h_unit)
            {
                case "centimeters":
                    h_result = entered_height / 30.48;
                    converted_h_unit.Text = "ft ";
                    break;
                case "feet":
                    h_result = entered_height * 30.48;
                    converted_h_unit.Text = "cm ";
                    break;
                default:
                    h_result = 0;
                    break;
            }

            f_h_result = h_result;
            converted_h.Text = h_result + "";
        }

        private void wu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_w_unit = "--";
            float entered_weight = 0;
            double w_result = 0;

            if (!(weight_unit.SelectedIndex == -1))
            {
                selected_w_unit = weight_unit.SelectedItem.ToString();
            }
            if (!string.IsNullOrEmpty(user_weight.Text))
            {
                entered_weight = float.Parse(user_weight.Text);
            }

            switch (selected_w_unit)
            {
                case "kilograms":
                    w_result = entered_weight * 2.2;
                    converted_w_unit.Text = "lbs ";
                    break;
                case "pounds":
                    w_result = entered_weight / 2.2046;
                    converted_w_unit.Text = "kg ";
                    break;
                default:
                    w_result = 0;
                    break;
            }

            f_w_result = w_result;
            converted_w.Text = w_result + "";
        }

        private void su_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_s_unit = "--";
            float entered_salary = 0;
            double s_result = 0;

            if (!(salary_unit.SelectedIndex == -1))
            {
                selected_s_unit = salary_unit.SelectedItem.ToString();
            }
            if (!string.IsNullOrEmpty(user_salary.Text))
            {
                entered_salary = float.Parse(user_salary.Text);
            }

            switch(selected_s_unit)
            {
                case "US dollar":
                    s_result = entered_salary * 54.08; // USD conversion rate at the time of coding
                    break;
                case "UK pound":
                    s_result = entered_salary * 66.21; // UK Pound conversion rate at the time of coding
                    break;
                case "Japanese yen":
                    s_result = entered_salary * 0.4; // JP Yen conversion rate at the time of coding
                    break;
                case "KSA riyal":
                    s_result = entered_salary * 14.41; // SR conversion rate at the time of coding
                    break;
                case "UAE dirham":
                    s_result = entered_salary * 14.72; // UAE Dirham conversion rate at the time of coding
                    break;
                default:
                    s_result = 0;
                    break;
            }
            s_result = Math.Round(s_result, 2);

            f_s_result = s_result;
            converted_s.Text = s_result + "";
        }
    }
}