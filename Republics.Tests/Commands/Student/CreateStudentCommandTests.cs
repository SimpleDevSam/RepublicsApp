using Republics.Application.UseCases;

namespace Republics.Tests.Commands;

[TestClass]
public class CreateStudentCommandTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenUserIdIsEmpty()
    {
        var command = new CreateStudentCommand(
            Guid.Empty,
            Guid.NewGuid(),
            "City",
            "State",
            "Country",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when user id is empty.");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCityIsNullOrEmpty()
    {
        var command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            null,
            "State",
            "Country",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when city is null.");

        command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "",
            "State",
            "Country",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when city is empty.");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenStateIsNullOrEmpty()
    {
        var command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            null,
            "Country",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when state is null.");

        command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "",
            "Country",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when state is empty.");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCountryIsNullOrEmpty()
    {
        var command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            null,
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when country is null.");

        command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            "",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when country is empty.");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCourseTypeIsNullOrEmpty()
    {
        var command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            "Country",
            null,
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when course type is null.");

        command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            "Country",
            "",
            "Regular"
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when course type is empty.");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenStudentTypeIsNullOrEmpty()
    {
        var command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            "Country",
            "Freshman",
            null
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when student type is null.");

        command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            "Country",
            "Freshman",
            ""
        );
        command.Validate();
        Assert.IsFalse(command.IsValid, "Command should be invalid when student type is empty.");
    }

    [TestMethod]
    public void ShouldBeValidWhenAllPropertiesAreValid()
    {
        var command = new CreateStudentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "City",
            "State",
            "Country",
            "Freshman",
            "Regular"
        );
        command.Validate();
        Assert.IsTrue(command.IsValid, "Command should be valid when all properties are provided correctly.");
    }
}
