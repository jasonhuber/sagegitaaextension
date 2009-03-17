using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sage.Platform.Application.UI;
using Sage.Platform.Application;
using Microsoft.Practices.ObjectBuilder;
using Sage.Platform.Projects.Interfaces;

namespace GitAAWinModule
{
        
    public class GitMethods : ModuleInit<UIWorkItem>, IModuleConfigurationProvider
    {
        [ServiceDependency]
        public IProjectContextService ProjectContext { get; set; }

        #region Command Handlers
        [CommandHandler(UriConstants.CmdPull)]
        public void PullCommand(object sender, EventArgs e)
        {

            String s = "";
             System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "cmd.exe";
    
    myProcess.StartInfo.UseShellExecute = false;
    myProcess.StartInfo.CreateNoWindow = true;
    myProcess.StartInfo.RedirectStandardInput = true;
    myProcess.StartInfo.RedirectStandardOutput = true;
    myProcess.StartInfo.RedirectStandardError = true;
    myProcess.Start();

    System.IO.StreamWriter sIn  = myProcess.StandardInput;
    System.IO.StreamReader  sOut = myProcess.StandardOutput;
    System.IO.StreamReader sErr  = myProcess.StandardError;
 
    sIn.AutoFlush = true;
    sIn.Write(@"C:\Program Files\Git\bin\git.exe " + string.Format(@"--git-dir ""{0}\.git"" pull origin master", ProjectContext.ActiveProject.Drive.RootDirectory.FullName.Substring(0,ProjectContext.ActiveProject.Drive.RootDirectory.FullName.ToUpper().IndexOf("\\MODEL"))) +  System.Environment.NewLine); 
    sIn.Write("exit" + System.Environment.NewLine);
    s = sOut.ReadToEnd();

    myProcess.WaitForExit();
    if (!myProcess.HasExited)
    {   //     myProcess.Kill();
    }

    System.Windows.Forms.MessageBox.Show(s); 

    sIn.Close() ;
    sOut.Close() ;
    sErr.Close() ;
    myProcess.Close(); 
     


            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.UseShellExecute = false; 
            //proc.EnableRaisingEvents=false;
            //proc.StartInfo.CreateNoWindow = true; 
            //proc.StartInfo.FileName = @"C:\Program Files\Git\bin\git";
            //s = string.Format(@" --git-dir ""{0}\.git"" pull origin master", ProjectContext.ActiveProject.Drive.RootDirectory.FullName.Substring(0,ProjectContext.ActiveProject.Drive.RootDirectory.FullName.ToUpper().IndexOf("\\MODEL"))) ;
            //proc.StartInfo.Arguments = s;//string.Format(@"--git-dir ""{0}\.git"" pull", ProjectContext.ActiveProject.Drive.RootDirectory.FullName.Substring(0,ProjectContext.ActiveProject.Drive.RootDirectory.FullName.IndexOf(@"\model"))) ;
            
            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.Start();
            //System.Windows.Forms.MessageBox.Show(s);
            
            //System.IO.StreamReader SR = proc.StandardOutput;
            //proc.WaitForExit();
            //s = SR.ReadToEnd();
            //System.Windows.Forms.MessageBox.Show(s);
          //  System.Windows.Forms.MessageBox.Show(ProjectContext.ActiveProject.Drive.RootDirectory.FullName);
        
            ProjectContext.ReloadActiveProject();
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
