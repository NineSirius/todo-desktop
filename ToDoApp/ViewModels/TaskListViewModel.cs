using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ToDoApp.Command;

namespace ToDoApp.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskViewModel> tasks = new ObservableCollection<TaskViewModel>();

        public ObservableCollection<TaskViewModel> Tasks
        {
            get { return tasks; }
            set
            {
                if (tasks != value)
                {
                    tasks = value;
                    NotifyPropertyChanged(nameof(Tasks));
                }
            }
        }

        public string TaskName { get; set; }

        public ICommand CreateTaskCommand
        {
            get { return new CreateTaskCommand(this); }
        }

        public ICommand DeleteTaskCommand
        {
            get { return new DeleteTaskCommand(this); }
        }

        public TaskListViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
