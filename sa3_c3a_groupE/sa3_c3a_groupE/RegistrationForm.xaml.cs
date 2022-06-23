using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using sa3_c3a_groupE.Models;

namespace sa3_c3a_groupE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationForm : ContentPage
    {
        private int person_iD;
        private string person_firstName;
        private string person_lastName;
        private int person_age;
        private string person_gender;
        private string person_inital_height;
        private string person_converted_height;
        private string person_initial_weight;
        private string person_converted_weight;
        private string person_inital_salary;
        private string person_converted_salary;

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
            string initial_h_unit = "--";
            string converted_h_unit = "--";
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
            

            switch (selected_h_unit)
            {
                case "centimeters":
                    h_result = entered_height / 30.48;
                    converted_h_unit = "ft ";
                    initial_h_unit = "cm ";
                    break;
                case "feet":
                    h_result = entered_height * 30.48;
                    converted_h_unit = "cm ";
                    initial_h_unit = "ft ";
                    break;
                default:
                    h_result = 0;
                    break;
            }
            
            person_inital_height = entered_height + initial_h_unit;
            person_converted_height = h_result + converted_h_unit;
            converted_h.Text = person_converted_height;
        }

        private void wu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string initial_h_unit = "--";
            string converted_w_unit = "--";
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
                    converted_w_unit = "lbs ";
                    initial_h_unit = "kg ";
                    break;
                case "pounds":
                    w_result = entered_weight / 2.2046;
                    converted_w_unit = "kg ";
                    initial_h_unit = "lbs ";
                    break;
                default:
                    w_result = 0;
                    break;
            }
            
            person_initial_weight = entered_weight + initial_h_unit;
            converted_w.Text = w_result + converted_w_unit;
            person_converted_weight = converted_w.Text;
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
            

            switch (selected_s_unit)
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

            person_inital_salary = entered_salary + " " + selected_s_unit;
            converted_s.Text = "Php " + s_result;
            person_converted_salary = converted_s.Text;
        }

        private void Gender_RadioBtn(object sender, CheckedChangedEventArgs eventArgs)
        {
            string selected_g = "";
            if(gender_male.IsChecked)
            {
                selected_g = gender_male.Value.ToString();
                
            }
            else if(gender_female.IsChecked)
            {
                selected_g = gender_female.Value.ToString();
                
            }
            else if(gender_other.IsChecked)
            {
                selected_g = gender_other.Value.ToString();
                
            }
            
            chosen_gender.Text = selected_g + "";
            person_gender = selected_g + "";
        }

        private bool validate_info()
        {
            if (string.IsNullOrEmpty(user_firstName.Text) || string.IsNullOrEmpty(user_lastName.Text) || string.IsNullOrEmpty(user_age.Text) || string.IsNullOrEmpty(user_iD.Text))
            {
                return false;
            }
            if (!gender_male.IsChecked && !gender_female.IsChecked && !gender_other.IsChecked)
            {
                return false;
            }
            if (height_unit.SelectedIndex == -1 || string.IsNullOrEmpty(user_height.Text))
            {
                return false;
            }
            if (weight_unit.SelectedIndex == -1 || string.IsNullOrEmpty(user_weight.Text))
            {
                return false;
            }
            if (salary_unit.SelectedIndex == -1 || string.IsNullOrEmpty(user_salary.Text))
            {
                return false;
            }

            return true;
        }

        private void submitButton_Onclicked(object sender, EventArgs e)
        {
            
            if (validate_info())
            {
                statusMessage.Text = "";
                person_iD = (int)double.Parse(user_iD.Text);
                person_firstName = user_firstName.Text;
                person_lastName = user_lastName.Text;
                person_age = (int)double.Parse(user_age.Text);
                App.PersonRepo.basicInfo(person_iD, person_lastName, person_firstName, person_age, person_gender);
                App.PersonRepo.getHeight(person_inital_height, person_converted_height);
                App.PersonRepo.getWeight(person_initial_weight, person_converted_weight);
                App.PersonRepo.getSalary(person_inital_salary, person_converted_salary);
                App.PersonRepo.AddNewPerson();
                statusMessage.Text = App.PersonRepo.StatusMessage;
                DisplayAlert("Alert", App.PersonRepo.StatusMessage, "Ok");
                
            }
            else
            {
                DisplayAlert("Warning!", "Please fill up all fields", "Ok");
            }
        }
    }
}