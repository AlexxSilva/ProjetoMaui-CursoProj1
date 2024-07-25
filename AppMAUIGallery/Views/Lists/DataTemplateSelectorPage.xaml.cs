namespace AppMAUIGallery.Views.Lists.Models;

public partial class DataTemplateSelectorPage : ContentPage
{
	public DataTemplateSelectorPage()
	{
		InitializeComponent();
		CollectionViewControl.ItemsSource = MovieList.GetList();
		
	}
}