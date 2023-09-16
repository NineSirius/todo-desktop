using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public partial class MainWindow : Window
    {
        private TaskListViewModel taskList;

        public MainWindow()
        {
            InitializeComponent();
            taskList = new TaskListViewModel();
            if (File.Exists("tasks.json"))
            {
                taskList.Tasks = new ObservableCollection<TaskViewModel>(DataHelper.LoadTasks("tasks.json"));
            }
            else
            {
                taskList.Tasks = new ObservableCollection<TaskViewModel>();
            }

            this.DataContext = taskList;

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataHelper.SaveTasks(new List<TaskViewModel>(taskList.Tasks), "tasks.json");
        }

        private void MinimizedButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
