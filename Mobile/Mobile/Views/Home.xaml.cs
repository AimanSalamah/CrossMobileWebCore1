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
	public partial class Home : ContentPage
	{
		public Home ()
		{
            HttpClient client = new HttpClient();
            var respons = client.GetAsync("http://localhost:50397/api/tasks").Result;
            var data = respons.Content.ReadAsAsync<List<BLL.Tasks>>().Result;
            Tasks = new ObservableCollection<BLL.Tasks>(data);
            AddClass = new BLL.Tasks();
            InitializeComponent();
            this.BindingContext = this;

        }
        public ObservableCollection<BLL.Tasks> Tasks { get; set; }
        public BLL.Tasks AddClass { get; set; }
        private void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var respons = client.PostAsJsonAsync("http://localhost:50397/api/tasks", AddClass).Result;
            if(respons.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var data = respons.Content.ReadAsAsync<BLL.Tasks>().Result;
                Tasks.Add(data);
                DisplayAlert("Info", $"Subject: {AddClass.Subject}, Descripon: {AddClass.Description}, Done: {AddClass.Done.ToString()}.", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Error saving you data please try again later" , "Ok");
            }
        }
    }
}