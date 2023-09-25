using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSSecretManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly ISecretResult _secretResult;
        public SecretsController(ISecretResult secretResult)
        {
            _secretResult = secretResult;
        }

        [HttpGet]
        public async Task<string> GetSecrets()
        {
            return await _secretResult.GetSecret();
        }
    }
}
