//using Moq;
//using Microsoft.AspNetCore.Mvc;
//using WebApi.Controllers;
//using WebApi.Models.Requests.Auth;
//using WebApi.Models.Responses.Auth;
//using Application.Interface;
//using Infrastructure.Identity;
//using Microsoft.AspNetCore.Identity;
//using WebApi.shared;

//public class AuthControllerTests
//{
//    private readonly Mock<UserManager<AppUser>> _mockUserManager;
//    private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
//    private readonly Mock<IAuthService> _mockAuthService;
//    private readonly AuthController _controller;

//    public AuthControllerTests()
//    {
//        var userStoreMock = new Mock<IUserStore<AppUser>>();
//        _mockUserManager = new Mock<UserManager<AppUser>>(
//            userStoreMock.Object, null, null, null, null, null, null, null, null);

//        var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
//        _mockRoleManager = new Mock<RoleManager<IdentityRole>>(
//            roleStoreMock.Object, null, null, null, null);

//        _mockAuthService = new Mock<IAuthService>();

//        _controller = new AuthController(_mockUserManager.Object, _mockAuthService.Object, _mockRoleManager.Object);
//    }

//    [Fact]
//    public async Task Login_ReturnsOk_WhenCredentialsAreValid()
//    {
//        // Arrange
//        var email = "usuario@dominio.com";
//        var password = "Password123!";
//        var user = new AppUser { Id = "1", Email = email };

//        _mockUserManager.Setup(m => m.FindByEmailAsync(email)).ReturnsAsync(user);
//        _mockUserManager.Setup(m => m.CheckPasswordAsync(user, password)).ReturnsAsync(true);
//        _mockUserManager.Setup(m => m.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Admin" });

//        _mockAuthService
//            .Setup(a => a.GenerateToken(user.Id))
//            .ReturnsAsync(("mocked-token", 3600));

//        var request = new LoginRequest
//        {
//            Email = email,
//            Password = password
//        };

//        // Act
//        var result = await _controller.Login(request);

//        // Assert
//        var okResult = Assert.IsType<OkObjectResult>(result);
//        var apiResponse = Assert.IsType<ApiResponse<LoginResponse>>(okResult.Value);

//        Assert.True(apiResponse.Success);
//        Assert.Equal(200, apiResponse.StatusCode);
//        Assert.Equal("Inicio de sesión exitoso", apiResponse.Message);
//        Assert.Equal("mocked-token", apiResponse.Data.Token);
//    }
//}