using System;

namespace projectmanagement.exception
{
    public class EmployeeNotFoundException : Exception
    {
        // Default constructor
        public EmployeeNotFoundException() : base("Employee not found.")
        {
        }

        // Parameterized constructor to allow custom error messages
        public EmployeeNotFoundException(string message) : base(message)
        {
        }

        // Parameterized constructor to pass custom message and inner exception
        public EmployeeNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
