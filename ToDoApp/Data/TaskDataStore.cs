using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ToDoApp.ViewModels;

public class TaskDataStore
{
    private readonly string dataFilePath;

    public TaskDataStore(string filePath)
    {
        dataFilePath = filePath;
    }

    public List<TaskViewModel> LoadTasks()
    {
        try
        {
            using (FileStream fs = new FileStream(dataFilePath, FileMode.Open))
            {
                IFormatter formatter = new BinaryFormatter();
                return (List<TaskViewModel>)formatter.Deserialize(fs);
            }
        }
        catch (FileNotFoundException)
        {
            return new List<TaskViewModel>();
        }
    }

    public void SaveTasks(List<TaskViewModel> tasks)
    {
        using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, tasks);
        }
    }
}
