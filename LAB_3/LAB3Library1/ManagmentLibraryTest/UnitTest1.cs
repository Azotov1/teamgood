using System.Collections.Generic;
using Xunit;

public class TaskManagementLibraryTests
{
    private TaskManagementLibrary taskManager;

    public TaskManagementLibraryTests()
    {
        taskManager = new TaskManagementLibrary();
        taskManager.AddProject("Project 1");
        taskManager.AddProject("Project 2");
        taskManager.AddTask("Task 1", "Description 1", "Project 1");
        taskManager.AddTask("Task 2", "Description 2", "Project 1");
        taskManager.AddTask("Task 3", "Description 3", "Project 2");
    }

    [Fact]
    public void AddRemoveProject()
    {
        taskManager.AddProject("Project 3");
        Assert.True(taskManager.GetSortedTasksForProject("Project 3").Count == 0);

        taskManager.RemoveProject("Project 3");
        Assert.False(taskManager.projects.ContainsKey("Project 3"));
    }

    [Fact]
    public void AddRemoveTask()
    {
        int taskId = 4;
        taskManager.AddTask("Task 4", "Description 4", "Project 2");
        Assert.True(taskManager.tasks.ContainsKey(taskId));
        Assert.True(taskManager.projects["Project 2"].Contains(taskId));

        taskManager.RemoveTask(taskId);
        Assert.False(taskManager.tasks.ContainsKey(taskId));
        Assert.False(taskManager.projects["Project 2"].Contains(taskId));
    }

    [Fact]
    public void AddRemoveFavorite()
    {
        int taskId = 1;
        taskManager.AddToFavorites(taskId);
        Assert.True(taskManager.favorites.Contains(taskId));

        taskManager.RemoveFromFavorites(taskId);
        Assert.False(taskManager.favorites.Contains(taskId));
    }

    [Fact]
    public void SortedFavorites()
    {
        taskManager.AddToFavorites(1);
        taskManager.AddToFavorites(2);
        taskManager.AddToFavorites(3);
        var sortedFavorites = taskManager.GetSortedFavorites();
        Assert.Equal(new List<int> { 3, 2, 1 }, sortedFavorites);
    }

    [Fact]
    public void SortedTasksForProject()
    {
        var sortedTasks = taskManager.GetSortedTasksForProject("Project 1");
        Assert.Equal(new List<int> { 2, 1 }, sortedTasks);
    }
}
