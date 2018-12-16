using COREAPP2.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COREAPP2.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
