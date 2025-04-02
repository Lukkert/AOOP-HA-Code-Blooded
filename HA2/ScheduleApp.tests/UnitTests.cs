using System.Text.Json;
using Xunit;

using ScheduleApp.Models;
using ScheduleApp.Services;
using Avalonia.Metadata;

namespace ScheduleApp.Tests;
public class UnitTests
{
    const string originalFile = "UserData.json";
    const string testingFile = "UserData.test.json";

    [Fact]
    public void AuthService_Can_Validate_Existing_Users_And_Reject_Invalid_Ones()
    {
            // Change the default storage path to a newly created testingFile path
            File.Copy(originalFile, testingFile, overwrite: true);
            DataStoreService.FilePath = testingFile;

        try
        {
            DataStoreService.Load();

            // Test login for Student
            var student = AuthService.ValidateCredentials("Klaus", "2222");

            // Test login for Teacher
            var teacher = AuthService.ValidateCredentials("John", "1111");

            // Test invalid login
            var invalidUser = AuthService.ValidateCredentials("EvilNorthKoreanHacker", "@U!DH!@9u2u21`&9u");

            // Assert
            Assert.NotNull(student); // Ensure the student login is successful
            Assert.Equal(1, student.Id);

            Assert.NotNull(teacher); // Ensure the teacher login is successful
            Assert.Equal(1, teacher.Id);

            Assert.Null(invalidUser); // Ensure invalid login fails
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }

    }

    [Fact]
    public void Teacher_Can_Create_A_New_Subject()
    {

        // Change the default storage path to a newly created testingFile path
        File.Copy(originalFile, testingFile, overwrite: true);
        DataStoreService.FilePath = testingFile;

        try
        {
            DataStoreService.Load();

            // Authenticate a teacher user.
            var teacher = AuthService.ValidateCredentials("John", "1111") as Teacher;

            // Create a Subject
            teacher!.CreateSubject("Test Subject", "Test Subject Description");

            // Assert that the subject was created successfully
            var createdSubject = DataStoreService.Subjects.FirstOrDefault(s => s.Name == "Test Subject");

            if (createdSubject == null)
            {
                throw new Exception("Subject creation failed.");
            }

            Assert.Equal("Test Subject Description", createdSubject.Description);

        }
        finally
        {
            // Cleanup
            File.Delete(testingFile);
        }
    }

    [Fact]
    public void Student_Can_Enroll_In_A_Subject()
    {
        // Change the default storage path to a newly created testingFile path
        File.Copy(originalFile, testingFile, overwrite: true);
        DataStoreService.FilePath = testingFile;

        try
        {
            DataStoreService.Load();

            // Authenticate a student user.
            var student = AuthService.ValidateCredentials("Klaus", "2222") as Student;

            // Look for an available subject
            var availableSubject = DataStoreService.Subjects.FirstOrDefault(s => s.Name == "Flying");

            if (availableSubject == null)
            {
                throw new Exception("Could not find the specified subject");
            }

            student!.EnrollSubject(availableSubject.Id);

            // Assert that the subject was enrolled successfully
            var enrolledSubject = student!.Subjects!.FirstOrDefault(s => s == availableSubject.Id);

            Assert.Equal(availableSubject.Id, enrolledSubject);

        }
        finally
        {
            // Cleanup
            File.Delete(testingFile);
        }
    }
}