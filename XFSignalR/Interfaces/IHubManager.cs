using System;
using System.Threading.Tasks;

namespace XFSignalR.Interfaces
{
    public interface IHubManager
    {
        abstract Task Send(object[] message);
    }
}
