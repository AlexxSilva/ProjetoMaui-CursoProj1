using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppTask.Models
{
    public class SubTaskModel : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public bool _isCompleted;
        public bool isCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(isCompleted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // public DateTimeOffset Deleted { get; set; }

    }
}
