using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HakobuNotifikado.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/send-message")]
public class SendMessageController : Controller
{
    [HttpPost]
    public Task<string> SendAsync(string m) =>
        Task.FromResult($"{DateTimeOffset.Now}: {m}");
}