// See https://aka.ms/new-console-template for more information
using Lab4;

TaskManagementLibrary taskManagementLibrary = new TaskManagementLibrary();

taskManagementLibrary.AddProject("projectName 1");
taskManagementLibrary.AddProject("projectName 2");

taskManagementLibrary.AddTask("title 1", "desription 1", "projectName 1");
taskManagementLibrary.AddTask("title 2", "desription 2", "projectName 1");
taskManagementLibrary.AddTask("title 3", "desription 3", "projectName 2");
taskManagementLibrary.AddTask("title 4", "desription 4", "projectName 2");

taskManagementLibrary.GetSortedTasksForProject("projectName 1").ForEach(task => {Console.WriteLine(task.ToString());});