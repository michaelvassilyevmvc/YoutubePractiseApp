using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppContext context;

        public NoteRepository(AppContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
        {
            note.Created = DateTime.UtcNow;
            await context.Notes.AddAsync(note, cancellationToken);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
        {
            context.Remove(note);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Notes.ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
        {
            note.Updated = DateTime.UtcNow;
            context.Notes.Update(note);
            await context.SaveChangesAsync();
        }


    }
}
