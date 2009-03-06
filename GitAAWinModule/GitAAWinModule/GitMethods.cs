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
