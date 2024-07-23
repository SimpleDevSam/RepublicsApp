using DiscountContext.Domain.Entities;
using DiscountContext.Domain.ValueObjects;


namespace DiscountContext.Test.Entities
{
    [TestClass]
    public class RepublicTests
    {
        private Republic CreateValidRepublic()
        {
            var name = "Valid Republic Name";
            var address = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");

            return new Republic(name, address);
        }

        private Student CreateValidStudent()
        {
            var name = new Name("John", "Doe");
            var birthDate = new BirthDate(new DateTime(2000, 1, 1));

            return new Student(name, birthDate, "samuca123", "samuekl@gmail.com", "samuelufop12");
        }

        private Student CreateInvalidStudent()
        {
            var invalidName = new Name("", ""); 
            var invalidBirthDate = new BirthDate(DateTime.Now.AddYears(1)); 

            return new Student(invalidName, invalidBirthDate, "samuca123", "samuekl@gmail.com", "samuelufop12");
        }

        [TestMethod]
        public void ShouldAddStudentSuccessfully()
        {
            var republic = CreateValidRepublic();
            var student = CreateValidStudent();

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
