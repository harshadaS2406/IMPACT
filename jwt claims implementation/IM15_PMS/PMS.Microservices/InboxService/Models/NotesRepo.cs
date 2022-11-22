using InboxService.EFCoreSetUp;
using InboxService.ViewModel;
using LoginService.EFCoreSetUp;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public class NotesRepo : INotesRepo
    {
        private readonly NotesDbContext _notesDbContext;
        private readonly LoginContext _loginContext;
        public NotesRepo(NotesDbContext notesDbContext, LoginContext loginContext)
        {
            _notesDbContext = notesDbContext;
            _loginContext = loginContext;
        }
        public async Task<int> AddNotes(Notes model)
        {
            if (_notesDbContext != null)
            {
                if (model.ReplyId != null)
                {
                    var notes = await _notesDbContext.Notes.FirstOrDefaultAsync(x => x.NoteId == model.ReplyId);
                    notes.IsResponded = true;
                    _notesDbContext.Notes.Update(notes);
                    model.ReplyId = null;
                }
                model.CreatedDate = DateTime.Now;
                await _notesDbContext.Notes.AddAsync(model);
                return await _notesDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteNotes(int noteId)
        {
            if (_notesDbContext != null)
            {
                var note = await _notesDbContext.Notes.FirstOrDefaultAsync(x => x.NoteId == noteId);
                if (note != null)
                {
                    note.DeleteFlag = true;
                    _notesDbContext.Notes.Update(note);
                    return await _notesDbContext.SaveChangesAsync();
                }
            }
            return 0;
        }

        public Task<Notes> GetNoteById(int noteId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReceivedNotes>> GetReceivedNotes(int userId)
        {

            if (_notesDbContext != null)
            {
                var notes = await _notesDbContext.Notes.Where(c => c.ReceiverId == userId && c.DeleteFlag == false).ToListAsync();
                List<ReceivedNotes> receivedNotesList = new List<ReceivedNotes>();

                foreach (var received in notes)
                {
                    ReceivedNotes model = new ReceivedNotes();
                    model.NoteId = received.NoteId;
                    model.ReceivedDate = received.CreatedDate;
                    model.SenderName = received.SenderName;
                    model.SenderId = received.SenderId;
                    model.SenderDesignation = received.SenderDesignation;
                    model.MessageReceived = received.Message;
                    model.IsUrgent = received.IsUrgent;
                    model.ReceivedDate.ToShortDateString();
                    receivedNotesList.Add(model);
                }
                return receivedNotesList;
            }
            return null;
        }

        public async Task<List<SentNotes>> GetSentNotes(int userid)
        {
            if (_notesDbContext != null)
            {
                var notes = await _notesDbContext.Notes.Where(c => c.SenderId == userid).ToListAsync();
                List<SentNotes> sentNotesList = new List<SentNotes>();

                foreach (var received in notes)
                {
                    SentNotes model = new SentNotes();
                    model.NoteId = received.NoteId;
                    model.SentDate = received.CreatedDate;
                    model.ReceiverId = received.ReceiverId;
                    model.ReceiverDesignation = received.ReceiverDesignation;
                    model.ReceiverName = received.ReceiveName;
                    model.MessageSent = received.Message;
                    model.Response = received.IsResponded == true ? "Responded" : "No Response";
                    model.IsUrgent = received.IsUrgent;
                    sentNotesList.Add(model);
                }
                return sentNotesList;
            }
            return null;
        }

        public async Task<List<UsersList>> GetUsersList(int id)
        {
            if (_loginContext != null)
            {
                var users = await _loginContext.Users.Where(o => o.Id != id).ToListAsync();
                //var users = this._loginContext.Users.Where(r=>r.Id!=id).ToList();
                List<UsersList> usersList = new List<UsersList>();
                if (users != null)
                {
                    foreach (var appuser in users)
                    {
                        UsersList user = new UsersList();
                        user.UserId = appuser.Id;
                        user.Name = appuser.Title + " " + appuser.FirstName + " " + appuser.LastName;
                        user.Email = appuser.Email;
                        user.Role = Convert.ToString(_loginContext.Roles.
                            Where(r => Convert.ToInt32(r.Id) == Convert.ToInt32(appuser.RoleID)).FirstOrDefault().Name);
                        usersList.Add(user);
                    }
                    return usersList;
                }
            }
            return null;
        }
    }
}
