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
	public partial class PhoneBook : ContentPage
	{
		public PhoneBook()
		{
            var datas = new Service.DataStore<BLL.PhoneBooks>().Get();
            if(datas!=null)
            {
                Tasks = new ObservableCollection<BLL.PhoneBooks>(datas);
            }
            else
            {
                Tasks = new ObservableCollection<BLL.PhoneBooks>();
            }
            AddPhoenBook = new BLL.PhoneBooks();
            InitializeComponent();
            this.BindingContext = this;
        }
        public ObservableCollection<BLL.PhoneBooks> Tasks { get; set; }
        public BLL.PhoneBooks AddPhoenBook { get; set; }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var data = new Service.DataStore<BLL.PhoneBooks>().Post(AddPhoenBook);
            if(data!=null)
            {
                Tasks.Add(data);
                DisplayAlert("Info", $"Subject: {AddPhoenBook.Name}, Descripon: {AddPhoenBook.PhoneNumber}, Done: {AddPhoenBook.EmailAddress.ToString()}.", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Error saving you data please try again later" , "Ok");
            }
        }
    }
}