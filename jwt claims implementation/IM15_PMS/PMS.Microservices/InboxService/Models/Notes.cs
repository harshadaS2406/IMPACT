using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public class Notes
    {
        [Key]
        public int NoteId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderDesignation { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiveName { get; set; }
        public string ReceiverDesignation { get; set; }
        public string Message { get; set; }
        public int? ReplyId { get; set; }
        public bool IsResponded { get; set; }
        public bool IsUrgent { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
