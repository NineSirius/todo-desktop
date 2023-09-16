using System;
using System.Windows.Input;
using ToDoApp.ViewModels;

namespace ToDoApp.Command
{
    public class DeleteTaskCommand : ICommand
    {
        private TaskListViewModel taskList;

        public event EventHandler CanExecuteChanged;

        public DeleteTaskCommand(TaskListViewModel taskList)
        {
            this.taskList = taskList;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is TaskViewModel task)
            {
                if (taskList.Tasks.Contains(task))
                {
                    taskList.Tasks.Remove(task);
                }
            }
        }
    }
}
