﻿using System;
using System.Web.Http;
using CollageRestAPI.Models;
using CollageRestAPI.ViewModels;
using MongoDB.Bson;

namespace CollageRestAPI.Controllers.Interfaces
{
    interface ICourseController
    {
        //=== GET METHODS ===//
        IHttpActionResult GetCourses(CoursesRequestViewModel coursesRequest);
        //IHttpActionResult GetCourses(string id = null, string courseName = null, string tutor = null);
        //IHttpActionResult GetCourseByName(string courseName);
        //IHttpActionResult GetCourseById(ObjectId id);
        IHttpActionResult GetCourseStudents(string courseName, int id = 0);
        IHttpActionResult GetCourseGrades(string courseName, string id = null);

        //=== POST METHODS ===//
        IHttpActionResult CreateCourse(CourseModel courseToCreate);
        IHttpActionResult CreateGradeForStudent(int id, string courseName, GradeModel gradeToCreate);

        //=== PUT METHODS ===//
        IHttpActionResult UpdateCourse(CourseModel courseToUpdate);
        //IHttpActionResult UpdateCourse(string courseName, CourseModel courseToUpdate);
        IHttpActionResult UpdateGradeForStudent(GradeModel gradeToUpdate);
        //IHttpActionResult UpdateGradeForStudent(int id, GradeModel gradeToUpdate);
        IHttpActionResult RegisterStudentForCourse(int id, string courseName, bool unregister = false);
        //IHttpActionResult UnregisterStudentFromCourse(int id, string courseName);

        //=== DELETE METHODS ===//
        IHttpActionResult DeleteCourse(string courseId);
        IHttpActionResult DeleteGradeForStudentByDateOfIssue(int id, DateTime dateOfIssue);
        IHttpActionResult DeleteGradeForStudent(string gradeId);
    }
}
