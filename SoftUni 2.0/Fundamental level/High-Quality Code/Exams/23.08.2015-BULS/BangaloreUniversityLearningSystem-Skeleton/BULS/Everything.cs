using buls.utilities;
using System;
using System.Collections.Generic;

public class User
{
    private string username;
    private string passwordHash;

    public User(string username, string password, Role role)
    {
        this.usr = username;
        if (username == null || username == string.Empty)
        {
            string message = string.Format("The username must be at least 5 symbols long.");
            throw new ArgumentException(message);
        }
        if (username.Length < 5)
        {
            string message = string.Format("The username must be at least 5 symbols long.");
            throw new ArgumentException(message);
        }
        this.usr = username;
        if (password == null || password == string.Empty)
        {
            string message = string.Format("The password must be at least 5 symbols long.");
            throw new ArgumentException(message);
        }
        if (password.Length < 5)
        {
            string message = string.Format("The username must be at least 5 symbols long.");
            throw new ArgumentException(message);
        }
        string passwordHash = HashUtilities.HashPassword(password);
        this.pwd = passwordHash;
        this.Role = role;
        this.Courses = new List<Course>();
    }
    public string usr { get; set; }
    public string pwd { get; set; }

    public Role Role { get; private set; }

    public IList<Course> Courses { get; private set; }
}
public enum Role
{
    Student,
    Lecturer
}
public class Course
{
    private string name;

    public Course(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 5)
        {
            string message = string.Format("The course name must be at least 5 symbols long.");
            throw new ArgumentException(message);
        }

        this.Name = name;
        this.Lectures = new List<Lecture>();
    }

    public string Name { get; set; }

    public IList<Lecture> Lectures { get; set; }

    public IList<User> Students { get; set; }

    public void AddLecture(Lecture lecture)
    {
        this.Lectures.Add(lecture);
    }

    public void AddStudent(User student)
    {
        this.Students.Add(student);
        student.Courses.Add(this);
    }
}
public class Lecture
{
    public string name;

    public Lecture(string name)
    {
        this.Name = Name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value == null || value.Length < 3)
                throw new ArgumentException(string.Format("The lecture name must be at least 3 symbols long."));
            this.name = value;
        }
    }
}