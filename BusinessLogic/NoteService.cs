﻿using DataAccess;

namespace BusinessLogic
{
    internal class NoteService(INoteRepository noteRepository):INoteService
    {
        public async Task CreateAsync(string text, CancellationToken cancellationToken=default)
        {
            var note = new Note
            {
                Text = text,
            };
            await noteRepository.CreateAsync(note, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken = default);
            if (note is null)
                throw new Exception("Note not found");

            await noteRepository.DeleteAsync(note, cancellationToken);
        }

        public async Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var note =  await noteRepository.GetByIdAsync(id, cancellationToken = default);
            if (note is null) 
                throw new Exception("Note not found");

            return note.Text;
        }

        public async Task UpdateAsync(int id, string text, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken = default);
            if (note is null)
                throw new Exception("Note not found");

            note.Text = text;
            await noteRepository.UpdateAsync(note,cancellationToken);
        }
    }
}
