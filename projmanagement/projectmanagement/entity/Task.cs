using System;

namespace projectmanagement.entity
{
    public class Task
    {
        // Fields (private)
        private int taskId;            // Task ID (Primary Key)
        private string taskName;       // Name of the task
        private int projectId;         // Foreign key referencing the Project table
        private int employeeId;        // Foreign key referencing the Employee table
        private string status;         // Status of the task (Assigned, Started, Completed)

        // Default constructor
        public Task() { }

        // Parameterized constructor
        public Task(int taskId, string taskName, int projectId, int employeeId, string status)
        {
            this.taskId = taskId;
            this.taskName = taskName;
            this.projectId = projectId;
            this.employeeId = employeeId;
            this.status = status;
        }

        // Getters and Setters (Properties in C#)
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        // ToString() method to easily display task details
        public override string ToString()
        {
            return $"Task ID: {taskId}, Task Name: {taskName}, Project ID: {projectId}, Employee ID: {employeeId}, Status: {status}";
        }
    }
}

