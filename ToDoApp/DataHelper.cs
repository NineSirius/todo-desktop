using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public class DataHelper
    {
        // Метод для сохранения задач в JSON файл
        public static void SaveTasks(List<TaskViewModel> tasks, string filePath)
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // Метод для загрузки задач из JSON файла
        public static List<TaskViewModel> LoadTasks(string filePath)
        {
            List<TaskViewModel> tasks = new List<TaskViewModel>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(json);
            }

            return tasks;
        }
    }
}
