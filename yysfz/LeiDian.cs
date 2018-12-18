using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace yysfz
{
   
    public class LeiDian
    {
        private string path;
        public string ret;

        public LeiDian(string str)
        {
            this.path = str;
        }

      
                    
    
        public void Action(int index, string value)
        {
            this.ret = this.Cmd("dnconsole.exe action --index " + index.ToString() + " --key call.keyboard --value  " + value);
        }
      

       
        public void RunApp(int index, string package)
        {
            this.ret = this.Cmd("dnconsole.exe runapp --index " + index.ToString() + " --packagename " + package);
        }

      
        

       
        public void RunEmu(string name)
        {
            this.ret = this.Cmd("dnconsole.exe launch --name " + name);
        }

   
        public string Cmd(string c)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            process.StandardInput.WriteLine(this.path + c);
            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine("exit");
            StreamReader standardOutput = process.StandardOutput;
            string result = standardOutput.ReadLine();
            while (!standardOutput.EndOfStream)
            {
                result = standardOutput.ReadToEnd();
            }
            process.WaitForExit();
            return result;
        }

      
    }
}
