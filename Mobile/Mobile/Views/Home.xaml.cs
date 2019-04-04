using System;
using System.Collections.Generic;
using System.Linq;
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
			InitializeComponent ();
		}

        private void TasksButtonClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Views.Tasks());
        }

        private void PhoneBookButtonClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Views.PhoneBook());
        }
    }
}