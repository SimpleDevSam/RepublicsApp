using Republics.Domain.Enums;
using Republics.Domain.Entities;
using Republics.Domain.ValueObjects;


namespace Republics.Tests.Entities
{
    [TestClass]
    public class RepublicTests
    {
        private Republic CreateValidRepublic()
        {
            var name = "Valid Republic Name";
            var address = new RepublicAddress("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");

            return new Republic(name, address);
        }

        private Student CreateValidStudent(Guid republicId)
        {
            var address = new StudentAddress("Montes Claros", "MG", "Brasil");

            return new Student(Guid.NewGuid(), address, ECoursesType.Engineering, EStudentType.Veteran);
        }

        private Student CreateInvalidStudent()
        {
            var invalidName = new Name("", "");
            var invalidBirthDate = new BirthDate(DateTime.Now.AddYears(1));
            var address = new StudentAddress("", "", "");

            return new Student(Guid.Empty, address, ECoursesType.Engineering, EStudentType.Veteran);
        }

        [TestMethod]
        public void ShouldAddStudentSuccessfully()
        {
            var republic = CreateValidRepublic();
            var student = CreateValidStudent(republic.Id);

            republic.AddStudent(student);

            Assert.AreEqual(1, republic.Students.Count);
            Assert.AreEqual(student, republic.Students.First());
        }

        [TestMethod]
        public void ShouldNotAddInvalidStudent()
        {
            var republic = CreateValidRepublic();
            var invalidStudent = CreateInvalidStudent();

            republic.AddStudent(invalidStudent);

            Assert.AreEqual(0, republic.Students.Count);
        }
    }
}
