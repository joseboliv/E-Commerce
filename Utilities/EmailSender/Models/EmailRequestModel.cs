namespace Utilities.EmailSender.Models
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EmailRequestModel
    {
        [Required]
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
