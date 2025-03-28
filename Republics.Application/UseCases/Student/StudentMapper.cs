﻿using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Domain.ValueObjects;
using Republics.Shared.Extensions;

namespace Republics.Application.UseCases;

public static class StudentMapper
{
    public static void MapUpdateStudentCommandToStudent(UpdateStudentCommand command, Student student)
    {
        if (command.StudentId != Guid.Empty)
            student.GetType().GetProperty("UserId").SetValue(student, command.StudentId);

        if (!string.IsNullOrEmpty(command.City) || !string.IsNullOrEmpty(command.State) || !string.IsNullOrEmpty(command.Country))
        {
            var currentAddress = student.Address;
            var newAddress = new StudentAddress(
                command.City ?? currentAddress?.City,
                command.State ?? currentAddress?.State,
                command.Country ?? currentAddress?.Country);
            student.ChangeAddress(newAddress);
        }
        if (!(command.CourseType.ToEnum<ECoursesType>() == null))
            student.ChangeCourse(command.CourseType.ToEnum<ECoursesType>()!.Value);

        if (!(command.StudentType.ToEnum<EStudentType>() == null))
            student.ChangeStudent(command.StudentType.ToEnum<EStudentType>()!.Value);

        if (command.RepublicId != Guid.Empty)
            student.GetType().GetProperty("RepublicId").SetValue(student, command.RepublicId);
    }
}