using System;
using System.ComponentModel.DataAnnotations;

namespace XFSignalRApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Autor { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public string Text { get; set; }
    }
}
