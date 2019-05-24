using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PAP.Business.ViewModels
{
    public class FeedIndexViewModel
    {
        [DataType(DataType.MultilineText)]
        public string TextOnPublish { get; set; }
        public string PhotoPath { get; set; }

    }
}
