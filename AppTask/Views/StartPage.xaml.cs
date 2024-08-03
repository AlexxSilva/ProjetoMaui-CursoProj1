using AppTask.Models;
using AppTask.Repositories;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{

    private  ITaskModelRepository _repository;
	public StartPage()
	{
		InitializeComponent();
        _repository = new TaskModelRepository();
        LoadData();

	}

    public void LoadData()
    {
        var tasks = _repository.GetAll();
        CollectionViewTasks.ItemsSource = tasks;
        LblEmptyText.IsVisible = tasks.Count <= 0;
    }

    private void OnButtonClickedToAdd(object sender, EventArgs e)
    { 
		Navigation.PushModalAsync(new AddEditTaskPage());	
    }

    private void OnBorderClickedToFocusEntry(object sender, TappedEventArgs e)
    {
        Entry_Search.Focus();
    }

    private async void OnImageClickedToDelete(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        var confirmacao = await DisplayAlert("Confirme a exclusão!",
            $"Tem certeza que deseja excluir essa tarefa: {task.Name}?", "Sim", "Não");

        if (confirmacao)
        {
            _repository.Delete(task);
            LoadData();
        }
    }

    private void OnCheckBoxClickedToComplete(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        task.isCompleted = ((CheckBox)sender).IsChecked;
        _repository.Update(task);

    }

    private void OnTapToEdit(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        Navigation.PushModalAsync(new AddEditTaskPage(_repository.GetById(task.Id)));

    }
}