using DataAccess;

namespace BusinessLogic
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }
        public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
        {
            var note = new Note
            {
                Text = text
            };
            await noteRepository.CreateAsync(note, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
            {
                throw new Exception("Note not found");
            }

            await noteRepository.DeleteAsync(note, cancellationToken);
        }

        public async Task<IEnumerable<string>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var list = await noteRepository.GetAllAsync(cancellationToken);
            return list.Select(x => x.Text).ToList();
        }

        public async Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null) {
                throw new Exception("Note not found");
            }

            return note.Text;
        }

        public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if(note == null)
            {
                throw new Exception("Note not found");
            }
            note.Text = newText;
            await noteRepository.UpdateAsync(note,cancellationToken);
        }
    }
}
