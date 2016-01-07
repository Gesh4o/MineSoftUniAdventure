namespace _03.CompanyHierarchy
{
    using System;
    using Interfaces;
    using System.Collections.Generic;

    public class Developer : RegularEmployee,IDeveloper
    {
        private List<Project> projects;

        public Developer(string id, string firstName, string lastName,decimal salary, DepartmentType department) 
            : base(id, firstName, lastName, salary, department)
        {
            this.projects = new List<Project>();
        }

        public IEnumerable<Project> Project
        {
            get { return this.projects; }
        }

        public override string ToString()
        {
            string projectInfo = GetProjectsInfo(this.projects);
            string result = string.Format("Name: {0} {1} \nID: {2} \nSalary: {3} \nDepartment: {4}\nSales information: \n{5}"
                , this.FirstName, this.LastName, this.ID, this.Salary, this.Department, projectInfo);
            return result;
        }

        private string GetProjectsInfo(List<Project> projects)
        {
            string projectsinfo = string.Empty;
            foreach (var project in projects)
            {
                Project tempProject = project;
                projectsinfo += string.Format("Project name: {0} \nStarted on: {1}\nProjects detils: {2}\nProject's state: {3}\n"
                    , project.ProjectName, project.StartDate, project.Details, project.State.ToUpper());
            }
            return projectsinfo;
        }

        public void AddProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentException("Project can't be null !");
            }
            this.projects.Add(project);
        }

        public void CloseProject(Project project)
        {
            if (this.projects.Contains(project))
            {
                if (project.State == "open")
                {
                    project.State = "closed";
                }
                else
                {
                    if (project.State == "closed")
                    {
                        throw new InvalidOperationException("You cannot close a closed project!");
                    }
                    throw new InvalidOperationException("Project's state was neither closed or open!");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot close a project which is not yours! ");
            }
        }
    }
}
