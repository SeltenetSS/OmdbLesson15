using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class WordController : ControllerBase
{
    private readonly IRandomWordService _randomWordService;

    public WordController(IRandomWordService randomWordService)
    {
        _randomWordService = randomWordService;
    }

    [HttpPost("random-word")]
    public ActionResult<string> GetRandomWord([FromBody] string[] words)
    {
        if (words == null || words.Length == 0)
        {
            return BadRequest("Bos ola bilmez.");
        }

        var randomWord = _randomWordService.GetRandomWord(words);

        if (randomWord == null)
        {
            return NotFound("Söz tapılmadı.");
        }

        return Ok(randomWord);
    }
}
