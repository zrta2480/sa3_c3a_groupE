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

        public void display_all_onlclicked(object sender, EventArgs eventArgs)
        {
            List<Person> people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
                
        }

        
    }
}