using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.ViewModels.Event
{
    public class EventPostViewModel
    {
        
        public string TextOnPublish { get; set; }
        public string Path { get; set; }
        public byte[] PhotoBytes { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }

        public Guid UserId { get; set; }
        public int EventId { get; set; }
    }
}
