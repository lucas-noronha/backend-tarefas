using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tarefas.Api.Dtos.Requisicao;
using Tarefas.Domain.Servicos;

namespace Tarefas.Api.Controllers
{
    [Route("api/login")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public UsuarioServico UsuarioServico { get; }
        public IConfiguration Configuration { get; }

        public LoginController(UsuarioServico usuarioServico, IConfiguration configuration)
        {
            UsuarioServico = usuarioServico;
            Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(summary: "Login com credenciais", description: "Obtém um token JWT para acessar demais rotas da API")]
        [SwaggerResponse(200, "Login efetuado com sucesso")]
        [SwaggerResponse(400, "Login e/ou senha inválidos")]
        public IActionResult Login(LoginDto dto)
        {
            var usuarioDto = UsuarioServico.Login(dto.Login, dto.Senha);

            if (usuarioDto != null)
            {
                var configChave = Configuration["Jwt:Key"];
                var issuer = Configuration["Jwt:Issuer"];
                var audience = Configuration["Jwt:Audience"];

                var chaveBytes = Encoding.ASCII.GetBytes(configChave);
                var chave = new SymmetricSecurityKey(chaveBytes);
                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256Signature);
                var validade = DateTime.Now.AddMinutes(120);

                var claimsToken = new[]
                {
                    new Claim("Usuario", usuarioDto.Nome)
                };

                var tokenInfos = new JwtSecurityToken(
                    claims: claimsToken,
                    signingCredentials: credenciais,
                    expires: validade,
                    issuer: issuer,
                    audience: audience

                );

                var tokenGen = new JwtSecurityTokenHandler();
                var token = tokenGen.WriteToken(tokenInfos);

                return Ok(token);
            }

            return BadRequest("Login e/ou senha inválidos");
        }

        [AllowAnonymous]
        [HttpPost("alterar_senha")]
        public IActionResult AlterarSenha(AlterarSenhaDto dto)
        {
            var sucesso = UsuarioServico.AlterarSenha(dto.Login, dto.Senha, dto.NovaSenha);

            if (sucesso)
            {
                return Ok("Senha alterada com sucesso");
            }

            return BadRequest("Não foi possível alterar a senha");
        }
    }
}
