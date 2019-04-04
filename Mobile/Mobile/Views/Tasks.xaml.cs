using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tasks : ContentPage
	{
		public Tasks()
		{
            tasks = new ObservableCollection<BLL.Tasks>(new Service.DataStore<BLL.Tasks>().Get());
            AddClass = new BLL.Tasks();
            InitializeComponent();
            this.BindingContext = this;
        }
        public ObservableCollection<BLL.Tasks> tasks { get; set; }
        public BLL.Tasks AddClass { get; set; }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var data = new Service.DataStore<BLL.Tasks>().Post(AddClass);
            if(data!=null)
            {
                tasks.Add(data);
                DisplayAlert("Info", $"Subject: {AddClass.Subject}, Descripon: {AddClass.Description}, Done: {AddClass.Done.ToString()}.", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Error saving you data please try again later" , "Ok");
            }
        }
    }
}