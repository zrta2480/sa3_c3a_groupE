using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sa3_c3a_groupE
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("people.db3");

        public static PersonRepository PersonRepo { get; private set; }

        public App()
        {
            InitializeComponent();

            PersonRepo = new PersonRepository(dbPath);

            MainPage = new NavigationPage(new MainPage() { Text = dbPath, });
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
