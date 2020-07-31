using System;
using Microsoft.EntityFrameworkCore;
using XFSignalRApi.Models;

namespace XFSignalRApi.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {

        }

        public DbSet<Message> Message { get; set; }

    }
}
