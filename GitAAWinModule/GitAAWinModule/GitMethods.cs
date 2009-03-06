using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sage.Platform.Application.UI;
using Sage.Platform.Application;
using Microsoft.Practices.ObjectBuilder;


namespace GitAAWinModule
{
    public class GitMethods : ModuleInit<UIWorkItem>, IModuleConfigurationProvider
    {
        #region Command Handlers
        [CommandHandler(UriConstants.CmdPull)]
        public void PullCommand(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("I want to pull from my Git Repo..");
        }
        #endregion

        protected override void Load()
        {
            base.Load();
        }
        public override string ToString()
        {
            return "My First Module";
        }
        #region ImoduleConfigrationProvider Members
        public ModuleConfiguration GetConfiguration()
        {
            return ModuleConfiguration.LoadFromResource("GitAAWinModule.module.xml", GetType().Assembly);
        }
        #endregion

    }
}
