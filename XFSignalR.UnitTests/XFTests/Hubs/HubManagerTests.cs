using System;
using System.Threading.Tasks;
using XFSignalR.Interfaces;
using XFSignalR.Services;
using Xunit;
using Moq;

namespace XFSignalR.UnitTests.XFTests.Hubs
{
    public class HubManagerTests
    {
        HubManager _hubManager;

        public HubManagerTests()
        {
            
        }

        [Fact]
        public async Task SendMessage_WhenMessageRecieved_InvokeOnMessageReceivedEvent()
        {
            
        }

    }
}
