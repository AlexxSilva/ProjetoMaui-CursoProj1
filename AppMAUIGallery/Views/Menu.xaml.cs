
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
		
		var categories = new CategoryRepository().GetCategories();

		foreach (var category in categories)
		{
			var lblCategory = new Label();
			lblCategory.Text = category.Name;
			lblCategory.FontFamily = "OpenSansSemibold";

            MenuContainer.Children.Add(lblCategory);

			foreach (var componenent in category.Components)
			{
				var tap = new TapGestureRecognizer();
				tap.CommandParameter = componenent.Page;
                tap.Tapped += OnTapComponent;


				var lblComponentTitle = new Label();
				lblComponentTitle.Text = componenent.Title;
                lblComponentTitle.FontFamily = "OpenSansSemibold";
				lblComponentTitle.Margin = new Thickness(20, 10, 0, 0);
				lblComponentTitle.GestureRecognizers.Add(tap);

                var lblComponentDescription = new Label();
				lblComponentDescription.Text = componenent.Description;
                lblComponentDescription.Margin  = new Thickness(20, 0, 0, 0);
                MenuContainer.Children.Add(lblComponentTitle);
                MenuContainer.Children.Add(lblComponentDescription);
                lblComponentDescription.GestureRecognizers.Add(tap);
            }
        }
    }

	private void OnTapComponent(object sender, EventArgs e)
	{
		var label = (Label)sender;
		var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
		var page = (Type)tap.CommandParameter;
		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
		((FlyoutPage)App.Current.MainPage).IsPresented = false;//oculta o menu

    }

    private void OnTapInicio(object sender, TappedEventArgs e)
    {
		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;//oculta o menu
    }
}