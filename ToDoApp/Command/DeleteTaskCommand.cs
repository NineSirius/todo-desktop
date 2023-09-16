using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.ViewModels;

namespace ToDoApp.Command
{
    public class DeleteTaskCommand : ICommand
    {
        private TaskListViewModel taskList;

        public event EventHandler? CanExecuteChanged;

        public DeleteTaskCommand(TaskListViewModel taskList)
        {
            this.taskList = taskList;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Debug.WriteLine("Вызван метод Execute для удаления задачи");
            if (parameter is TaskViewModel task)
            {
                if (taskList.Tasks.Contains(task))
                {
                    Debug.WriteLine("Задача найдена и удалена");
                    taskList.Tasks.Remove(task);
                }
            }
        }
    }

}
