using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PAP.Business.ViewModels.Event
{
    public class EventFeedIndexViewModel
    {
        [DataType(DataType.MultilineText)]
        public string TextOnPublish { get; set; }
        public string PhotoPath { get; set; }


        public string UserNick { get; set; }
        public string UserPublishPhoto { get; set; }
    }
}
