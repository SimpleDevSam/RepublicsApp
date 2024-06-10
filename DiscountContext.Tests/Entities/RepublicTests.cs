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
            var students = new List<Student>();

            return new Republic(name, address, students);
        }
        private Address CreateValidAddress()
        {
            return new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
        }

        private Student CreateValidStudent()
        {
            var name = new Name("John", "Doe");
            var birthDate = new BirthDate(new DateTime(2000, 1, 1));

            return new Student(name, birthDate);
        }

        private IList<Student> CreateValidStudents()
        {
            return new List<Student>
            {

                new Student(new Name ("John", "Doe"), new BirthDate(DateTime.Now.AddYears(-30))),
                new Student(new Name ("John", "Doe"), new BirthDate(DateTime.Now.AddYears(-30))),
            };
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNameIsNullOrEmpty()
        {
            var address = CreateValidAddress();
            var students = CreateValidStudents();

            var republic = new Republic("", address, students);
            Assert.IsFalse(republic.IsValid);

            republic = new Republic(null, address, students);
            Assert.IsFalse(republic.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAddressIsInvalid()
        {
            var invalidAddress = new Address("", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
            var students = CreateValidStudents();

            var republic = new Republic("Valid Republic Name", invalidAddress, students);
            Assert.IsFalse(republic.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAllFieldsAreValid()
        {
            var address = CreateValidAddress();
            var students = CreateValidStudents();

            var republic = new Republic("Valid Republic Name", address, students);
            Assert.IsTrue(republic.IsValid);
        }

        [TestMethod]
        public void ShouldInitializeStudentsCorrectly()
        {
            var address = CreateValidAddress();
            var students = CreateValidStudents();

            var republic = new Republic("Valid Republic Name", address, students);
            Assert.IsNotNull(republic.Students);
            Assert.AreEqual(2, republic.Students.Count);
        }

        [TestMethod]
        public void ShouldAddStudentSuccessfully()
        {
            var republic = CreateValidRepublic();
            var student = CreateValidStudent();

            republic.AddStudent(student);

            Assert.IsTrue(republic.IsValid);
            Assert.AreEqual(1, republic.Students.Count); 
            Assert.AreEqual(student, republic.Students.First()); 
        }

        [TestMethod]
        public void ShouldFailToAddStudentWhenStudentIsInvalid()
        {
            var republic = CreateValidRepublic();
            var invalidName = new Name("", "");
            var invalidBirthDate = new BirthDate(DateTime.Now.AddYears(1));
            var invalidStudent = new Student(invalidName, invalidBirthDate);

            republic.AddStudent(invalidStudent);

            Assert.IsTrue(republic.IsValid);
            Assert.AreEqual(0, republic.Students.Count);
        }
    }
}
