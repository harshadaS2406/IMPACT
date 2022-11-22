using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.ViewModel
{
    public class SentNotes
    {
        public int NoteId { get; set; }
        public DateTime SentDate { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverDesignation { get; set; }
        public string MessageSent { get; set; }
        public bool IsUrgent { get; set; }
        public string Response { get; set; }
    }
}
