﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using MongoDB.Bson;
using UrlHelper = System.Web.Http.Routing.UrlHelper;

namespace CollageRestAPI.Hypermedia
{
    public static class LinkTemplates
    {
        public static class Students
        {
            public static Link GetStudentsCollectionLink(UrlHelper urlHelper) => new Link("GetStudentsCollection", urlHelper.Content(WebApiConfig.RoutesTemplates.Students), "GET");

            public static Link GetStudentByIdLink(UrlHelper urlHelper, int studentId)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("id", studentId.ToString());               
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Students) + "?" + query;
                return new Link("GetStudentById", url, "GET");
            }
            public static Link GetStudentsByNameLink(UrlHelper urlHelper, string firstName, string lastName)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("firstName", firstName);
                query.Add("lastName", lastName);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Students) + "?" + query;
                return new Link("GetStudentsByName", url, "GET");
            }
            public static Link GetStudentGradesLink(UrlHelper urlHelper, int studentId)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("id", studentId.ToString());               
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.StudentGrades) + "?" + query;
                return new Link("GetStudentGrades", url, "GET");
            }           
            public static Link GetStudentCoursesLink(UrlHelper urlHelper, int studentId)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("id", studentId.ToString());
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.StudentCourses) + "?" + query;
                return new Link("GetStudentCourses", url, "GET");
            }

            public static Link CreateStudentLink(UrlHelper urlHelper) => new Link("CreateStudent", urlHelper.Content(WebApiConfig.RoutesTemplates.Students), "POST");

            public static Link UpdateStudentByIdLink(UrlHelper urlHelper, int studentId)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("id", studentId.ToString());
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Students) + "?" + query;
                return new Link("UpdateStudentById", url, "PUT");
            }

            public static Link DeleteStudentByIdLink(UrlHelper urlHelper, int studentId)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("id", studentId.ToString());
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Students) + "?" + query;
                return new Link("DeleteStudentById", url, "DELETE");
            }
        }

        public static class Courses
        {
            public static Link GetCoursesCollectionLink(UrlHelper urlHelper) => new Link("GetCoursesCollection", urlHelper.Content(WebApiConfig.RoutesTemplates.Courses), "GET");

            public static Link GetCourseByIdLink(UrlHelper urlHelper, string id)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("id", id);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Courses) + "?" + query;
                return new Link("GetCourseById", url, "GET");
            }
            public static Link GetCourseByNameLink(UrlHelper urlHelper, string name)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("courseName", name);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Courses) + "?" + query;
                return new Link("GetCourseByName", url, "GET");
            }
            public static Link GetCourseGradesLink(UrlHelper urlHelper, string name)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("courseName", name);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.CourseGrades) + "?" + query;
                return new Link("GetCourseGrades", url, "GET");
            }
            public static Link GetCourseStudentsLink(UrlHelper urlHelper, string name)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("courseName", name);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.CourseStudents) + "?" + query;
                return new Link("GetCourseStudents", url, "GET");
            }
            public static Link GetCourseGradeByIdLink(UrlHelper urlHelper, string name, string gradeId)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("courseName", name);
                query.Add("gradeId", gradeId);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.CourseGrades) + "?" + query;
                return new Link("GetCourseGradeById", url, "GET");
            }
            public static Link CreateCourseLink(UrlHelper urlHelper, string name) => new Link("CreateCourse", urlHelper.Content(WebApiConfig.RoutesTemplates.Courses), "POST");
            public static Link UpdateCourseByNameLink(UrlHelper urlHelper, string name)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("courseName", name);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Courses) + "?" + query;
                return new Link("UpdateCourseByName", url, "PUT");
            }     
            public static Link DeleteCourseByNameLink(UrlHelper urlHelper, string name)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("courseName", name);
                var url = urlHelper.Content(WebApiConfig.RoutesTemplates.Courses) + "?" + query;
                return new Link("DeleteCourseByName", url, "DELETE");
            }
        }

        public static class Grades
        {
            //public static Link GetGradesCollectionLink(UrlHelper urlHelper) => new Link("GetGradesCollection", urlHelper.Content("~/api/grades"), "GET");
        }

        //public static class Students
        //{
        //    public static Link GetStudentsCollectionLink() => new Link("GetStudentsCollection", new UrlHelper().Content("~/api/students"), "GET");

        //    public static Link GetStudentByIdLink(UrlHelper urlHelper, int studentId)
        //        => new Link("GetStudentById", urlHelper.Link("GetStudentById", new { id = studentId }), "GET");
        //    public static Link GetStudentGradesLink(UrlHelper urlHelper, int studentId)
        //        => new Link("GetStudentGrades", urlHelper.Link("GetStudentGrades", new { id = studentId }), "GET");
        //    public static Link GetStudentCoursesLink(UrlHelper urlHelper, int studentId)
        //        => new Link("GetStudentCourses", urlHelper.Link("GetStudentCourses", new { id = studentId }), "GET");

        //    public static Link CreateStudentLink(UrlHelper urlHelper, int studentId)
        //        => new Link("CreateStudent", urlHelper.Link("CreateStudent", new { id = studentId }), "POST");

        //    public static Link UpdateStudentByIdLink(UrlHelper urlHelper, int studentId)
        //        => new Link("UpdateStudentById", urlHelper.Link("UpdateStudentById", new { id = studentId }), "PUT");

        //    public static Link DeleteStudentByIdLink(UrlHelper urlHelper, int studentId)
        //        => new Link("DeleteStudentById", urlHelper.Link("DeleteStudentById", new { id = studentId }), "DELETE");
        //}

        //public static class Courses
        //{
        //    public static Link GetCoursesCollectionLink() => new Link("GetCoursesCollection", new UrlHelper().Content("~/api/courses"), "GET");

        //    public static Link GetCourseByNameLink(UrlHelper urlHelper, string name)
        //        => new Link("GetCourseByName", urlHelper.Link("GetCourseByName", new { courseName = name }), "GET");
        //    public static Link GetCourseGradesLink(UrlHelper urlHelper, string name)
        //        => new Link("GetCourseGrades", urlHelper.Link("GetCourseGrades", new { courseName = name }), "GET");
        //    public static Link GetCourseStudentsLink(UrlHelper urlHelper, string name)
        //        => new Link("GetCourseStudents", urlHelper.Link("GetCourseStudents", new { courseName = name }), "GET");
        //    public static Link CreateCourseLink(UrlHelper urlHelper, string name)
        //        => new Link("CreateCourse", urlHelper.Link("CreateCourse", new { courseName = name }), "POST");
        //    public static Link UpdateCourseByNameLink(UrlHelper urlHelper, string name)
        //        => new Link("UpdateCourseByName", urlHelper.Link("UpdateCourseByName", new { courseName = name }), "PUT");
        //    public static Link DeleteCourseByNameLink(UrlHelper urlHelper, string name)
        //        => new Link("DeleteCourseByName", urlHelper.Link("DeleteCourseByName", new { courseName = name }), "DELETE");
        //}

        //public static class Grades
        //{
        //    public static Link GetGradesCollectionLink() => new Link("GetGradesCollection", new UrlHelper().Content("~/api/grades"), "GET");
        //}
    }
}