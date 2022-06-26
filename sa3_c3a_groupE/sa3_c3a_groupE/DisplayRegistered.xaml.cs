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
    public partial class DisplayRegistered : ContentPage
    {
        public DisplayRegistered()
        {
            InitializeComponent();
        }

        public void Display_All_Onlclicked(object sender, EventArgs eventArgs)
        {
            List<Person> people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
            
        }

        public void Find_User_Onclicked(object sender, EventArgs eventArgs)
        {
            int retrieved_id = 0;
            if (string.IsNullOrEmpty(entered_id.Text))
            {
                statusMessage.Text = "[Field is empty]";
            }
            else
            {
                retrieved_id = (int)double.Parse(entered_id.Text);
                List<Person> people = App.PersonRepo.GetSpecificPerson(retrieved_id);
                peopleList.ItemsSource = people;
                if(people.Count < 1)
                {
                    statusMessage.Text = "[No Matching User ID]";
                }
                else
                {
                    statusMessage.Text = App.PersonRepo.StatusMessage;
                }
                //statusMessage.Text = App.PersonRepo.StatusMessage;
            }
        }

        public void Delete_User_Onclicked(object sender, EventArgs eventArgs)
        {
            int retrieved_id = 0;
            if(string.IsNullOrEmpty(entered_id.Text))
            {
                statusMessage.Text = "[Field is empty]";
            }
            else
            {
                retrieved_id = (int)double.Parse(entered_id.Text);
                App.PersonRepo.DeleteItem(retrieved_id);
                statusMessage.Text = App.PersonRepo.StatusMessage;
                Display_All_Onlclicked(sender, eventArgs);
            }
        }
    }
}