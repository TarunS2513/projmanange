using Microsoft.Extensions.Configuration;
using projectmanagement.dao;
using projectmanagement.entity;
using System;
using System.IO;

namespace projectmanagement.main
{
    internal class MainModule
    {
        private static IConfigurationRoot configuration;

        public static void Run(string[] args)
        {
            // Load configuration from appsettings.json
            InitializeConfiguration();

            // Retrieve connection string from configuration
            //string connectionString = configuration.GetConnectionString("project_management_db");
            string connectionString = configuration.GetConnectionString("LocalConnectionString");

            // Initialize repository with connection string
            IProjectRepository repository = new ProjectRepositoryImpl(connectionString);

            while (true)
            {
                Console.WriteLine("\n1. Add Employee");
                Console.WriteLine("2. Add Project");
                Console.WriteLine("3. Add Task");
                Console.WriteLine("4. Assign project to employee");
                Console.WriteLine("5. Assign task to employee");
                Console.WriteLine("6. Delete Employee");
                Console.WriteLine("7. Delete Project");
                Console.WriteLine("8. List all tasks in a project");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice: ");

                // Input validation
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee(repository);
                        break;
                    case 2:
                        AddProject(repository);
                        break;
                    case 3:
                        AddTask(repository);
                        break;
                    case 4:
                        AssignProjectToEmployee(repository);
                        break;
                    case 5:
                        AssignTaskToEmployee(repository);
                        break;
                    case 6:
                        DeleteEmployee(repository);
                        break;
                    case 7:
                        DeleteProject(repository);
                        break;
                    case 8:
                        ListTasksInProject(repository);
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        // Method to initialize configuration from appsettings.json
        private static void InitializeConfiguration()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private static void AddEmployee(IProjectRepository repository)
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Designation: ");
            string designation = Console.ReadLine();

            Console.Write("Enter Gender (M/F): ");
            string gender = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary;
            if (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid salary input.");
                return;
            }

            Employee emp = new Employee
            {
                Name = name,
                Designation = designation,
                Gender = gender,
                Salary = (double)salary
            };

            bool result = repository.CreateEmployee(emp);
            Console.WriteLine(result ? "Employee added successfully." : "Error adding employee.");
        }

        private static void AddProject(IProjectRepository repository)
        {
            Console.Write("Enter Project Name: ");
            string projectName = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Start Date (yyyy-mm-dd): ");
            DateTime startDate;
            if (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Invalid date input.");
                return;
            }

            Console.Write("Enter Status (started/dev/build/test/deployed): ");
            string status = Console.ReadLine();

            Project project = new Project
            {
                ProjectName = projectName,
                Description = description,
                StartDate = startDate,
                Status = status
            };

            bool result = repository.CreateProject(project);
            Console.WriteLine(result ? "Project added successfully." : "Error adding project.");
        }

        private static void AddTask(IProjectRepository repository)
        {
            Console.Write("Enter Task Name: ");
            string taskName = Console.ReadLine();

            Console.Write("Enter Project ID: ");
            int projectId;
            if (!int.TryParse(Console.ReadLine(), out projectId))
            {
                Console.WriteLine("Invalid project ID input.");
                return;
            }
            projectmanagement.entity.Task task = new projectmanagement.entity.Task
            {
                TaskName = taskName,
                ProjectId = projectId,
                Status = "Started"  // Set initial status to 'started'
                                   
            };

            bool result = repository.CreateTask(task);
            Console.WriteLine(result ? "Task added successfully." : "Error adding task.");
        }

        private static void AssignProjectToEmployee(IProjectRepository repository)
        {
            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Console.Write("Enter Project ID: ");
            int projectId = int.Parse(Console.ReadLine());

            bool result = repository.AssignProjectToEmployee(employeeId, projectId);

            if (result)
            {
                Console.WriteLine("Project assigned successfully.");
            }
            else
            {
                Console.WriteLine("Error assigning project.");
            }
        }
        private static void AssignTaskToEmployee(IProjectRepository repository)
        {
            Console.Write("Enter Task ID: ");
            int taskId;
            if (!int.TryParse(Console.ReadLine(), out taskId))
            {
                Console.WriteLine("Invalid task ID input.");
                return;
            }

            Console.Write("Enter Project ID: ");
            int projectId;
            if (!int.TryParse(Console.ReadLine(), out projectId))
            {
                Console.WriteLine("Invalid project ID input.");
                return;
            }

            Console.Write("Enter Employee ID: ");
            int employeeId;
            if (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid employee ID input.");
                return;
            }

            bool result = repository.AssignTaskInProjectToEmployee(taskId, projectId, employeeId);
            Console.WriteLine(result ? "Task assigned to employee successfully." : "Error assigning task.");
        }

        private static void DeleteEmployee(IProjectRepository repository)
        {
            Console.Write("Enter Employee ID: ");
            int employeeId;
            if (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid employee ID input.");
                return;
            }

            bool result = repository.DeleteEmployee(employeeId);
            Console.WriteLine(result ? "Employee deleted successfully." : "Error deleting employee.");
        }

        private static void DeleteProject(IProjectRepository repository)
        {
            Console.Write("Enter Project ID: ");
            int projectId;
            if (!int.TryParse(Console.ReadLine(), out projectId))
            {
                Console.WriteLine("Invalid project ID input.");
                return;
            }

            bool result = repository.DeleteProject(projectId);
            Console.WriteLine(result ? "Project deleted successfully." : "Error deleting project.");
        }

        private static void ListTasksInProject(IProjectRepository repository)
        {
            Console.Write("Enter Employee ID: ");
            int employeeId;
            if (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid employee ID input.");
                return;
            }

            Console.Write("Enter Project ID: ");
            int projectId;
            if (!int.TryParse(Console.ReadLine(), out projectId))
            {
                Console.WriteLine("Invalid project ID input.");
                return;
            }

            var tasks = repository.GetAllTasksForEmployeeInProject(employeeId, projectId);
            if (tasks.Count > 0)
            {
                Console.WriteLine("Tasks assigned to the employee in this project:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Task ID: {task.TaskId}, Task Name: {task.TaskName}, Status: {task.Status}");
                }
            }
            else
            {
                Console.WriteLine("No tasks found for this employee in the specified project.");
            }
        }
    }
}
