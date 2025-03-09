using DiscountContext.Application.UseCases;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Extensions;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.UpdateStudent
{
    public class UpdateStudentCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateStudentCommand, ICommandResult<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ICommandResult<Student>> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid data");
            }

            var student = await _studentRepository.GetAsync(command.StudentId);

            if (student == null)
            {
                return new CommandResult<Student>(null, (int)StatusCodes.NotFound, "Student not found");
            }

            var teste = command.CourseType.ToEnum<ECoursesType>();

            StudentMapper.MapUpdateStudentCommandToStudent(command, student);

            if (!student.IsValid)
            {
                return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid student data after update");
            }

            await _studentRepository.UpdateAsync(student);

            return new CommandResult<Student>(student, (int)StatusCodes.OK, "Student updated successfully");
        }

    }
}