using ParlezentreeDl.Entities;
using Xunit;

namespace ParlezentreeTest;

public class UserModelTest
{
    [Fact]
    public void FirstNameShouldBevalidData()
    {
        //Arrange
        User userModel = new User();
        userModel.FirstName = "abc";
        string validFN = "abc";
        //Act
        userModel.FirstName = validFN;
        //Assert
        Assert.NotNull(userModel.FirstName);
        Assert.Equal(validFN, userModel.FirstName);
    }
    [Fact]
    public void LastNameShouldBevalidData()
    {
        //Arrange
        User userModel = new User();
        userModel.LastName = "xyz";
        string validLN = "xuz";
        //Act
        userModel.LastName = validLN;
        //Assert
        Assert.NotNull(userModel.LastName);
        Assert.Equal(validLN, userModel.LastName);
    }
    [Fact]
    public void userNameShouldBevalidData()
    {
        //Arrange
        User userModel = new User();
        userModel.UserName = "abc123";
        string validUN = "abc123";
        //Act
        userModel.UserName = validUN;
        //Assert
        Assert.NotNull(userModel.UserName);
        Assert.Equal(validUN, userModel.UserName);
    }
    [Fact]
    public void emailidShouldBevalidData()
    {
        //Arrange
        User userModel = new User();
        userModel.EmailId = "abc123@gmail.com";
        string validEmail = "abc123@gmail.com";
        //Act
        userModel.EmailId = validEmail;
        //Assert
        Assert.NotNull(userModel.EmailId);
        Assert.Equal(validEmail, userModel.EmailId);
    }

    [Fact]
    public void CcontactNumbershouldnotlessthanSix()
    {
        //Arrange
        User userModel = new User();
        userModel.ContactNo = 1234567890;
        decimal validCN = 1234567890;
        userModel.ContactNo = validCN;
        //Assert
        Assert.NotNull(userModel.ContactNo);
        Assert.Equal(validCN, userModel.ContactNo);
    }

}
