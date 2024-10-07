using System;

namespace projectmanagement.exception
{
    public class ProjectNotFoundException : Exception
    {
        // Default constructor
        public ProjectNotFoundException() : base("Project not found.")
        {
        }

       
        public ProjectNotFoundException(string message) : base(message)
        {
        }

        public ProjectNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
