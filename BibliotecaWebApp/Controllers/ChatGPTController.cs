using Forge.OpenAI;
using Forge.OpenAI.Interfaces.Services;
using Forge.OpenAI.Models.Common;
using Forge.OpenAI.Models.TextCompletions;
using Forge.OpenAI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BibliotecaWebApp.Controllers
{
    public class ChatGPTController : Controller
    {
        private readonly IOpenAIService _openAI;
        public ChatGPTController(IOpenAIService openAI)
        {
            _openAI = openAI;
        }
        public async Task<IActionResult> Index()
        {
            TextCompletionRequest request = new TextCompletionRequest();
            request.Prompt = "Qual'e' la capitale d'Italia?";
            request.User = "INSERISCI IL TUO USER";

            HttpOperationResult<TextCompletionResponse> response =
                await _openAI.TextCompletionService
                    .GetAsync(request, CancellationToken.None)
                        .ConfigureAwait(false);

            if (response.IsSuccess)
            {
                Console.WriteLine();
                response.Result!.Completions.ForEach(c => Console.WriteLine(c.Text));
            }
            else
            {
                Console.WriteLine(response);
            }

            return View(response);
        }
    }
}
