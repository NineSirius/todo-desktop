﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Command;

namespace ToDoApp.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskViewModel> tasks = new ObservableCollection<TaskViewModel>();

        public ObservableCollection<TaskViewModel> Tasks { 
            get { return tasks; } 
            set { 
                if (tasks != value)
                {
                    tasks = value;
                    NotifyProperyChanged(nameof(Tasks)); }
                }
            
        }
        public string TaskName { get; set; }
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand { }; } }
        public ICommand DeleteTaskCommand { get { return new DeleteTaskCommand(this); } }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyProperyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
