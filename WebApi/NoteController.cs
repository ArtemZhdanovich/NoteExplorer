using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNoteAsync(int id)
        {
           var result =  await noteService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNoteAsync(int id, string text) 
        {
            await noteService.UpdateAsync(id, text);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNoteAsync(int id, string text)
        {
            await noteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
