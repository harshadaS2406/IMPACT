using InboxService.ViewModel;
using LoginService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public interface INotesRepo
    {
        Task<List<SentNotes>> GetSentNotes(int userid);
        Task<List<ReceivedNotes>> GetReceivedNotes(int userId);
        Task<int> AddNotes(Notes model);
        Task<int> DeleteNotes(int noteId);
        Task<Notes> GetNoteById(int noteId);

        Task<List<UsersList>> GetUsersList(int id);
    }
}
