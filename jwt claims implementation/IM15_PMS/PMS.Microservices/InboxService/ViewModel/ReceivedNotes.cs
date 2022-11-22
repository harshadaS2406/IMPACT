using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.ViewModel
{
    public class ReceivedNotes
    {
        public int NoteId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderDesignation { get; set; }
        public string MessageReceived { get; set; }
        public bool IsUrgent { get; set; }
    }
}
