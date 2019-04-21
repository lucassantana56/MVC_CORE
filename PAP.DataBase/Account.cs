using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAP.DataBase
{
    public class Account : IdentityUser
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcountId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDay { get; set; }
        public string  PhotoUrl { get; set; }
        public int Stars { get; set; }
        public string ProgrammingLanguages { get; set; }
        public string Country { get; set; }     
     
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [InverseProperty(nameof(AccountOnEvent.Account))]
        public virtual ICollection<AccountOnEvent> AccountOnEvents { get; set; }
        [InverseProperty(nameof(AccountPublish.Account))]
        public virtual ICollection<AccountPublish> AccountPublishes  { get; set; }
        [InverseProperty(nameof(AccountRelationship.Account))]
        public  virtual ICollection<AccountRelationship> AccountRelationships { get; set; }
        [InverseProperty(nameof(EventAccount.Account))]
        public virtual ICollection<EventAccount> EventAccounts { get; set; }
        [InverseProperty(nameof(FeedBackContentAccount.Account))]
        public virtual  ICollection<FeedBackContentAccount> FeedBackContentAccounts { get; set; }
        [InverseProperty(nameof(FeedBackContentEvent.Account))]
        public virtual ICollection<FeedBackContentEvent> FeedBackContentEvents { get; set; }
        [InverseProperty(nameof(AccountLogin.AccountId))]
        public virtual  ICollection<AccountLogin> AccountLogins { get; set; }
    }
}
