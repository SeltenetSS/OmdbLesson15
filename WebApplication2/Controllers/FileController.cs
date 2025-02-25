using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet("read-words")]
    public ActionResult<string[]> ReadWordsFromFile([FromQuery] string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            return BadRequest("Fayl path daxil edilməyib.");
        }

        var words = _fileService.ReadWordsFromFile(filePath);

        if (words.Length == 0)
        {
            return NotFound("Fayl tapılmadı .");
        }

        return Ok(words);
    }
}
