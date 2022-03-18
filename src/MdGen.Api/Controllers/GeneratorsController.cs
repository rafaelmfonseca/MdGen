using MdGen.Api.Models;
using MdGen.Api.Generators.Twitter;
using MdGen.Api.Generators.Twitter.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MdGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneratorsController : ControllerBase
{
    private readonly ITwitterThreadMdGenerator _twitterThreadMdGenerator;

    public GeneratorsController(ITwitterThreadMdGenerator twitterThreadMdGenerator)
    {
        _twitterThreadMdGenerator = twitterThreadMdGenerator;
    }

    [HttpPost("twitterThread")]
    public async Task<IActionResult> TwitterThread([FromBody] TwitterThreadRequestModel twitterThreadRequestModel)
    {
        string mdContent = await _twitterThreadMdGenerator.Generate(twitterThreadRequestModel.TweetUrl);

        return Ok(mdContent);
    }
}
