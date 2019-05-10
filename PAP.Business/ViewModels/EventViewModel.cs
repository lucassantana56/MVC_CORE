using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string  EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string  TypeOfEvent { get; set; }
        public string Location { get; set; }
        public string  PhotoUrl { get; set; }
        public int Stars { get; set; }
        public string  Description { get; set; }
    }
}
