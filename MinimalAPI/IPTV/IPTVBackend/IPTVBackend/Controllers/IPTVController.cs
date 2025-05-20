using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class IPTVController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public IPTVController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("playlist")]
    public async Task<IActionResult> GetPlaylist([FromQuery] string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return BadRequest("URL parameter is required");
        }

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var playlistContent = await response.Content.ReadAsStringAsync();
            return Content(playlistContent, MediaTypeNames.Text.Plain);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest($"Error fetching playlist: {ex.Message}");
        }
    }
}
