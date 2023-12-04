using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SpeakerModel : PageModel
{
    private readonly IApiClient _apiClient;
    public SpeakerResponse Speaker { get; set; }

    public SpeakerModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        Speaker = await _apiClient.GetSpeakerAsync(id);

        if (Speaker == null)
        {
            return NotFound();
        }

        return Page();
    }
}