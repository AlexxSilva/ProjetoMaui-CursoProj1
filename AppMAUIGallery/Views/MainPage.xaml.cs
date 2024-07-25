using AppMAUIGallery.Libraries.Fix;
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;
using System.Collections.ObjectModel;

namespace AppMAUIGallery.Views;

public partial class MainPage : ContentPage
{
    private IGroupComponentRepository _repository;
    private List<Component> _fullList;
    private ObservableCollection<Component> _filtedList;
	public MainPage()
	{
		InitializeComponent();

        _repository = new GroupComponentRepository();
        _fullList = _repository.GetComponents();
        _filtedList = new ObservableCollection<Component>(_fullList);

        ComponentCollection.ItemsSource = _filtedList;
    }

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        KeyboardFix.HideKeyboard();

        var page = (Type)e.Parameter;
        //var label = (Label)sender;
        //var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
        //var page = (Type)tap.CommandParameter;
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;//oculta o menu
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var word = e.NewTextValue;
        Clear();

        Search(word);

    }

    private void Search(string word)
    {
        var filtedList = _fullList.Where(a => a.Title.ToUpper().Contains(word.ToUpper())).ToList();
        foreach (var component in filtedList)
        {
            _filtedList.Add(component);
        }
    }

    private void Clear()
    {
        var limit = _filtedList.Count;
        for(int i = 0; i < limit;i++) 
        {
            _filtedList.RemoveAt(0);
        }
    }
}