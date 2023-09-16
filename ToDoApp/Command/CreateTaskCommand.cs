using System;
using System.Windows;
using System.Windows.Input;
using ToDoApp.ViewModels;

namespace ToDoApp.Command
{
    public class CreateTaskCommand : ICommand
    {
        private TaskListViewModel taskList;

        public event EventHandler CanExecuteChanged;

        public CreateTaskCommand(TaskListViewModel taskList)
        {
            this.taskList = taskList;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is TaskListViewModel taskList )
            {
                if (!string.IsNullOrWhiteSpace(taskList.TaskName))
                {
                    taskList.Tasks.Add(new TaskViewModel() { Name = taskList.TaskName, Complete = false });
                    taskList.TaskName = ""; 
                } else
                {
                    MessageBox.Show("Заполните поле");
                }
            }
        }
    }
}
