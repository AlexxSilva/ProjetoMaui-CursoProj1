using AppTask.Models;
using AppTask.Repositories;
using System.ComponentModel.DataAnnotations;

namespace AppTask.Views;

public partial class AddEditTaskPage : ContentPage
{
    private ITaskModelRepository _repository;
    private TaskModel _task;
	public AddEditTaskPage()
	{
        _repository = new TaskModelRepository();
        InitializeComponent();
        _task = new TaskModel();

        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);

    }

    public AddEditTaskPage(TaskModel task)
    {
        _repository = new TaskModelRepository();
        InitializeComponent();
        _task = task;
        FillFields();
        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);

    }

    private void FillFields()
    {
        Entry_TaskName.Text = _task.Name;
        Editor_TaskDescription.Text = _task.Description;
        DatePicker_TaskDate.Date = _task.PrevisionDate;
    }

    private void CloseModal(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private async void AddStep(object sender, EventArgs e)
    {
        var stepName =  await DisplayPromptAsync("Etapa(subTarefa)", "Digite  o nome da etapa (subtarefa): ", "Adicionar", "Cancelar");
        
        if (!string.IsNullOrWhiteSpace(stepName)) {
            _task.SubTasks.Add(new SubTaskModel { Name = stepName, isCompleted = false });
        }
    
    }

    private void SaveData(object sender, EventArgs e)
    {
        //obter os dados
        GetDataFromForm();
        //validar os dados
        bool valid = ValidateData();
        //salvar 
        if (valid)
        {
            SaveInDataBase();
            //fechar a tela
            Navigation.PopModalAsync();

            //solicitar a atualizacao da tela anterior
            UpdateListInStartPage();
        }

    }

    private void UpdateListInStartPage()
    {
        var navePage = (NavigationPage)App.Current.MainPage;
        var startPage = (StartPage)navePage.CurrentPage;
        startPage.LoadData();
    }

    private void SaveInDataBase()
    {
        if (_task.Id == 0)
        {
            _repository.Add(_task);
        }
        else
        {
            _repository.Update(_task);  
        }

    }

    private bool ValidateData()
    {
        bool ValidationResult = true;
        Label_TaskName_Required.IsVisible = false;
        Label_TaskDescription_Required.IsVisible = false;

        if (string.IsNullOrWhiteSpace(_task.Name)) 
        {
            Label_TaskName_Required.IsVisible = true;
            ValidationResult = false;
        }

        if (string.IsNullOrWhiteSpace(_task.Name))
        {
            Label_TaskDescription_Required.IsVisible = true;
            ValidationResult = false;
        }


        return ValidationResult;
    }

    private void GetDataFromForm()
    {
        _task.Name = Entry_TaskName.Text;
        _task.Description = Editor_TaskDescription.Text;
        _task.PrevisionDate = DatePicker_TaskDate.Date;
        _task.PrevisionDate = _task.PrevisionDate.AddHours(23);
        _task.PrevisionDate = _task.PrevisionDate.AddMinutes(59);
        _task.PrevisionDate = _task.PrevisionDate.AddSeconds(59);
        _task.Created = DateTime.Now;
        if (_task.Id == 0)
            _task.isCompleted = false;
        
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        DatePicker_TaskDate.WidthRequest = width - 30;

    }

    private void OnTapToDelete(object sender, TappedEventArgs e)
    {
        _task.SubTasks.Remove((SubTaskModel)e.Parameter);
    }
}