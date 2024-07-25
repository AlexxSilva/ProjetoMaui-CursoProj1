
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{

	private IGroupComponentRepository _repository;
    public Menu()
	{
		InitializeComponent();
		//TODO
		_repository = new GroupComponentRepository();
		MenuCollection.ItemsSource = _repository.GetGroupComponents();
    }

	private void OnTapComponent(object sender, TappedEventArgs e)
	{
		var page = (Type)e.Parameter;
		//var label = (Label)sender;
		//var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
		//var page = (Type)tap.CommandParameter;
		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
		((FlyoutPage)App.Current.MainPage).IsPresented = false;//oculta o menu

	}

    private void OnTapInicio(object sender, TappedEventArgs e)
    {
		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;//oculta o menu
    }

}