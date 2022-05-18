using PaintSharp.Core.Services.Interfaces;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.WPF.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IMessageBoxService _messageBoxService;

        #region Constructor / Setup

        public UpdateService(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        } 

        #endregion

        public async Task CheckForUpdates()
        {
            using (var manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/Iwaneq/PaintSharp"))
            {
                try
                {
                    //Get info about Updates
                    var updateInfo = await manager.CheckForUpdate();

                    if (updateInfo.ReleasesToApply.Count > 0)
                    {
                        await manager.UpdateApp();

                        UpdateManager.RestartApp();
                    }
                }
                catch (Exception ex)
                {
                    _messageBoxService.ShowError("Update error!", ex.Message);
                }
            }
        }
    }
}
