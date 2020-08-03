using System;
namespace XFSignalR.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
    }
}
