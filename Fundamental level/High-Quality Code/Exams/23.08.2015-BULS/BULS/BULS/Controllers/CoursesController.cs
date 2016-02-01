﻿namespace UniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;

    using UniversityLearningSystem.Contracts;
    using UniversityLearningSystem.Exceptions;
    using UniversityLearningSystem.Infrastructure;
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            // Performance: Useless foreach was found.
            if (!this.CurrentUser.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            Course course = this.GetCourseById(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count()));
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.CurrentUser.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.GetCourseById(courseId);
            if (!this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException($"There is no course with ID {courseId}.");
            }

            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.CurrentUser);
            return this.View(course);
        }

        private Course GetCourseById(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException($"There is no course with ID {courseId}.");
            }

            return course;
        }
    }
}