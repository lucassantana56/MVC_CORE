using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.ViewModels
{
    public class AccountViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public string Country { get; set; }
        public string ProgramminglLanguages { get; set; }
        public int Stars { get; set; }
    }
}
