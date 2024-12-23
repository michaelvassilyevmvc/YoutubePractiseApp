using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace YoutubePractise.SimpleCrud
{
    [ApiController]
    [Route("Note")]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string text)
        {
            await noteService.CreateAsync(text);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
        {
            var result = await noteService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetNotesAsync()
        {
            var result = await noteService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] string newText)
        {
            await noteService.UpdateAsync(id, newText);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await noteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
