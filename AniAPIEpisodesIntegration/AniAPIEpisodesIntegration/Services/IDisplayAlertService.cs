using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIEpisodesIntegration.Services
{
    public interface IDisplayAlertService
    {
        Task DisplayInfoAlert(string title, string message);
        Task<bool> DisplayOptionAlert(string title, string message);
    }
}
