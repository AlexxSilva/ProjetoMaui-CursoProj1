using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class PickerListPage : ContentPage
{
	public PickerListPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		PickerControl.ItemsSource = MovieList.GetList();
		var index = PickerControl.SelectedIndex;

		//receber valor
		PickerControl.SelectedItem = MovieList.GetList()[0];
		//pegar o valor
	    var nomeFilme =	((Movie)PickerControl.SelectedItem).Name;
    }
}