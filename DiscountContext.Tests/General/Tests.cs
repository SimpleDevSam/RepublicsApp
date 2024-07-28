//using DiscountContext.Domain.Entities;
//using DiscountContext.Domain.Enums;
//using DiscountContext.Domain.ValueObjects;
//using DiscountContext.Infrastructure.Data;

//namespace DiscountContext.Test.General
//{
//    [TestClass]
//    public class GeneralTests
//    {
//        [TestMethod]
//        public async Task TestingDbContexts()
//        {
//            using (var context = new DiscountDbContext())
//            {
//                //var student = new Student(new Name("John", "Doe"), new BirthDate(new DateTime(2000, 1, 1)), "samuca123", "samuekl@gmail.com", "samuelufop12");
//                //await context.Students.AddAsync(student);

//                //var company = new Company("Test Company",new Address("Street", "123", "Neighborhood", "City", "State", "Country", "ZipCode"),EBusinessType.Food);
//                //await context.Companies.AddAsync(company);

//                //var discount = new Discount (student, company, DateTime.Now.AddDays(30),0.10,10);
//                //await context.Discounts.AddAsync(discount);

//                var name = "Valid Republic Name";
//                var address = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");

//                var republic = new Republic(name, address);

//                await context.Republics.AddAsync(republic);

//                var result = await context.SaveChangesAsync();

//                Assert.IsTrue(result > 0);
//            }


//        }

//    }
//}