using projectmanagement.entity;
using System.Collections.Generic;
using EntityTask = projectmanagement.entity.Task;



namespace projectmanagement.dao
{
    internal interface IProjectRepository
    {
        // Employee-related operations
        bool CreateEmployee(Employee emp);  // Method to create a new employee
        bool DeleteEmployee(int employeeId);  // Method to delete an employee by their ID

        // Project-related operations
        bool CreateProject(Project project);  // Method to create a new project
        bool DeleteProject(int projectId);  // Method to delete a project by its ID

        // Task-related operations
        bool CreateTask(projectmanagement.entity.Task task);  // Method to create a new task
        bool DeleteTask(int taskId);  // Method to delete a task by its ID

        // Assignment-related operations
        bool AssignProjectToEmployee(int projectId, int employeeId);  // Assign project to an employee
        bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId);  // Assign task within a project to an employee

        // Reporting and fetching
        List<EntityTask> GetAllTasksForEmployeeInProject(int employeeId, int projectId);  // List all tasks assigned to an employee in a specific project 
    }
}

