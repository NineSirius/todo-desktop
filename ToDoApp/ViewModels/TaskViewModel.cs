using System.ComponentModel;

namespace ToDoApp.ViewModels
{
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
                    OnPropertyChanged(nameof(Name));
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
                    OnPropertyChanged(nameof(Complete));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
