﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Streamberry.Application.DTO.UsuarioDTO;
using Streamberry.Application.Services;
using Streamberry.Domain.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Streamberry.WebAPI.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService userService)
        {
            _usuarioService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UsuarioLoginRequestDTO loginRequest)
        {
            var token = await _usuarioService.Authenticate(loginRequest.Email, loginRequest.Senha);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register([FromBody] UsuarioRegisterRequestDTO registerRequest)
        {
            var token = await _usuarioService.Register(registerRequest.Nome,registerRequest.Email, registerRequest.Senha);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] UsuarioLoginRequestDTO deleteRequest)
        {
            if (!await _usuarioService.Exists(deleteRequest.Email))
                return NotFound();

            await _usuarioService.Delete(deleteRequest.Email, deleteRequest.Senha);
            return Ok();
        }
    }
}
