using System;

namespace projectmanagement.entity
{
    public class Project
    {
        // Fields (private)
        private int id;               // Project ID (Primary Key)
        private string projectName;    // Name of the project
        private string description;    // Optional description of the project
        private DateTime startDate;    // Start date of the project
        private string status;         // Project status (started, dev, build, test, deployed)

        // Default constructor
        public Project() { }

        // Parameterized constructor
        public Project(int id, string projectName, string description, DateTime startDate, string status)
        {
            this.id = id;
            this.projectName = projectName;
            this.description = description;
            this.startDate = startDate;
            this.status = status;
        }

        // Getters and Setters (Properties in C#)
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        // ToString() method to easily display project details
        public override string ToString()
        {
            return $"ID: {id}, Project Name: {projectName}, Description: {description}, Start Date: {startDate.ToShortDateString()}, Status: {status}";
        }
    }
}

