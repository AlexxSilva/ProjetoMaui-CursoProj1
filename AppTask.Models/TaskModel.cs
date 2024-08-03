using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppTask.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime PrevisionDate { get; set; }

        public bool _isCompleted;

        public bool isCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value;
                OnPropertyChanged(nameof(isCompleted));
            }
        }

        public DateTime Created { get; set;}
        public DateTime Updated { get; set;}

        public ObservableCollection<SubTaskModel> SubTasks { get; set; } = new ObservableCollection<SubTaskModel>();

        
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    
}
