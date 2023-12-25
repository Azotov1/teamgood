// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

 TaskManagementLibrary TaskLibrary = new();
TaskLibrary.AddProject("Some project name");
TaskLibrary.AddProject("hello world");
TaskLibrary.AddTask("Some title", "Some description", "Some project name");
TaskLibrary.AddToFavorites(1);
foreach (var task in TaskLibrary.GetSortedFavorites())
Console.WriteLine(task);
