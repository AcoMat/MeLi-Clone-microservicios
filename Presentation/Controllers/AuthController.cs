using System;
using MeLi_Clone_users_ms.Application.Interfaces;
using MeLi_Clone_users_ms.Domain.DTOs;
using MeLi_Clone_users_ms.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Clone_users_ms.Application.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterNewUser([FromBody] RegisterDTO registerDTO)
    {
        try
        {
            var createdUser = await _authService.RegisterUser(registerDTO);
            return Created($"/user" + createdUser.Id, createdUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost( "login")]
    public async Task<ActionResult> LoginUser([FromBody] LoginDTO loginReq)
    {   
        return BadRequest("Not implemented");
    }
}
