using System;
using System.ComponentModel.DataAnnotations;
using XFSignalRApi.Models.Base;

namespace XFSignalRApi.Models
{
    public class Message : BaseEntity
    {
        public string Autor { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public string Text { get; set; }
    }
}
