using System.Text.Json;
using MeLi_Clone_users_ms.Application.Interfaces;
using MeLi_Clone_users_ms.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Clone_users_ms.Application.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly ITokenService _tokenService;

    public UsersController(IUsersService usersService, ITokenService tokenService)
    {
        _usersService = usersService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterNewUser([FromBody] RegisterDto registerDto)
    {
        var createdUser = await _usersService.RegisterUser(registerDto);
        var newToken = _tokenService.GenerateToken(createdUser);
        Response.Headers.Authorization = newToken;
        var userDto = new UserDto(createdUser);
            
        return Created("/user/" + createdUser.Id,JsonSerializer.Serialize(userDto));
    }

    [HttpPost( "login")]
    public async Task<ActionResult> LoginUser([FromBody] LoginDto loginReq)
    {
        var loggedUser = await _usersService.Login(loginReq);
        var newToken = _tokenService.GenerateToken(loggedUser);

        Response.Headers.Authorization = newToken;
        return Ok(JsonSerializer.Serialize(new UserDto(loggedUser)));
    }
    
    [HttpGet]
    [Route("users/me")]
    public async Task<IActionResult> GetUserData()
    {
        Request.Headers.TryGetValue("Authorization", out var token);
        _tokenService.ValidateToken(token);
        var userId = _tokenService.GetUserIdFromToken(token!);
        var user = await _usersService.GetUser(userId);
        return Ok(JsonSerializer.Serialize(new UserDto(user)));
    }

    [HttpGet]
    [Route("/users/{id:int}")]
    public async Task<IActionResult> GetUserDataById(int id)
    {
        var user = await _usersService.GetUser(id);
        return Ok(new SimpleUserDto
        {
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            ImageUrl = user.ImageURL
        });
    }
    
    [HttpPut]
    [Route("users/me/like")]
    public async Task<IActionResult> LikeProduct([FromBody] LikeDto likeDto)
    {
        Request.Headers.TryGetValue("Authorization", out var token);
        _tokenService.ValidateToken(token);
        var userId = _tokenService.GetUserIdFromToken(token!);
        var user = await _usersService.AddLikedProduct(userId,likeDto.ProductId);
        return Ok(JsonSerializer.Serialize(new UserDto(user)));
    }
    
    [HttpPut]
    [Route("users/me/purchases")]
    public async Task<IActionResult> AddPurchase([FromBody] PurchaseDto purchaseDto)
    {
        throw new NotImplementedException();
        /*
        Request.Headers.TryGetValue("Authorization", out var token);
        _tokenService.ValidateCartToken(token!);
    
        var user = await _usersService.AddPurchase(purchaseDto);
        
        return Ok(JsonSerializer.Serialize(new UserDto(user)));
        */
    }
}
