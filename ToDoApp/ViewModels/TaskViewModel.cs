using System;
using System.ComponentModel;

namespace ToDoApp.ViewModels
{
    [Serializable]
    public class TaskViewModel : INotifyPropertyChanged
    {
        private string name;
        private bool complete;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public bool Complete
        {
            get { return complete; }
            set
            {
                if (complete != value)
                {
                    complete = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Complete)));
                }
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
