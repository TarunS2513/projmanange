-- Use the database
USE project_management_db;

-- Create the Project table first as Employee and Task tables reference it
CREATE TABLE Project (
    id INT PRIMARY KEY IDENTITY(1,1),              
    project_name NVARCHAR(100) NOT NULL,           
    description NVARCHAR(255),                     
    start_date DATE NOT NULL,                     
    status NVARCHAR(20) CHECK (status IN ('started', 'dev', 'build', 'test', 'deployed'))  


CREATE TABLE Employee (
    id INT PRIMARY KEY IDENTITY(1,1),              -- Auto-incrementing primary key for Employee
    name NVARCHAR(100) NOT NULL,                   -- Employee's name (required)
    designation NVARCHAR(50),                      -- Employee's designation
    gender NVARCHAR(10),                           -- Employee's gender (M/F/O)
    salary DECIMAL(10, 2) CHECK (salary >= 0),     -- Employee's salary with a constraint for non-negative value
    project_id INT,                                -- Optional project assigned to the employee
    FOREIGN KEY (project_id) REFERENCES Project(id) ON DELETE SET NULL -- If the project is deleted, set project_id to NULL
)

-- Create the Task table
CREATE TABLE Task (
    task_id INT PRIMARY KEY IDENTITY(1,1),         
    task_name NVARCHAR(100) NOT NULL,              
    project_id INT NOT NULL,                       
    employee_id INT,                              
    status NVARCHAR(20) CHECK (status IN ('Assigned', 'Started', 'Completed')),  
    FOREIGN KEY (project_id) REFERENCES Project(id) ON DELETE CASCADE,  
    FOREIGN KEY (employee_id) REFERENCES Employee(id) ON DELETE SET NULL 
);


