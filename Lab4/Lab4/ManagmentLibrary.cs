﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class TaskManagementLibrary
    {
        public Dictionary<string, HashSet<int>> projects = new Dictionary<string, HashSet<int>>();
        public Dictionary<int, Task> tasks = new Dictionary<int, Task>();
        public HashSet<int> favorites = new HashSet<int>();

        public void AddProject(string projectName)
        {
            projects.Add(projectName, new HashSet<int>());
        }

        public void RemoveProject(string projectName)
        {
            if (projects.ContainsKey(projectName))
            {
                var projectTasks = projects[projectName].ToList();
                foreach (var taskId in projectTasks)
                {
                    tasks.Remove(taskId);
                }
                projects.Remove(projectName);
            }
        }

        public void AddTask(string title, string description, string projectName)
        {
            int taskId = tasks.Count + 1;
            tasks.Add(taskId, new Task(title, description, projectName));
            projects[projectName].Add(taskId);
        }

        public void RemoveTask(int taskId)
        {
            if (tasks.ContainsKey(taskId))
            {
                string projectName = tasks[taskId].ProjectName;
                projects[projectName].Remove(taskId);
                tasks.Remove(taskId);
            }
        }

        public void AddToFavorites(int taskId)
        {
            favorites.Add(taskId);
        }

        public void RemoveFromFavorites(int taskId)
        {
            favorites.Remove(taskId);
        }

        public List<int> GetSortedFavorites()
        {
            return favorites.OrderByDescending(taskId => tasks[taskId].Title).ToList();
        }

        public List<Task> GetSortedTasksForProject(string projectName)
        {
            List<Task> result = new List<Task>();
            foreach (Task t in tasks.Values)
            {
                if(t.ProjectName == projectName)
                {
                    result.Add(t);
                }
            }    

            return result;
        }
    }

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }

        public Task(string title, string description, string projectName)
        {
            Title = title;
            Description = description;
            ProjectName = projectName;
        }
        public string ToString()
        {
            string result = "task :" + Title + "\n \t desription :" + Description + "\n \t projectName :" + ProjectName;
            return result;
        }
    }
}
