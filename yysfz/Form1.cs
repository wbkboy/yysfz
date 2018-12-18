using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace yysfz
{
  
    
    public partial class Form1 : Form
    {
        //雷电模拟器操作类
        private LeiDian ld;
        //雷电模拟器路径
        private string emupath;
        // 定义一个全局dm对象保持
        private dmsoft dm;
        //定义一个全局任务标志
        private string taskType = "队员";
        public Form1()
        {
            InitializeComponent();
            dm = new dmsoft();
            RegDM();
        }

        //获取雷电模拟器路径
        bool GetEmuPath()
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey dnplayer = key.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\dnplayer", true);
            emupath = dnplayer.GetValue("DisplayIcon").ToString();
            if (emupath != null)
            {
                GameRMsg1("模拟器", emupath);
                return true;
            }
            else
            {
                GameRMsg1("模拟器", "没有找到雷电模拟器");
            }
            key.Close();
            return false;
        }

        //判断模拟器是否开启
        bool FindEmu(string game)
        {
            for (int i = 0; i < 4; i++)
            {
                if (dm.FindWindow("", game) != 0)
                {
                    return true;
                }
                dm.delay(500);
            }
            return false;
        }


        private void btnGame1Start_Click(object sender, EventArgs e)
        {
            string game = GetGame(sender);
            MultiDm mdm = new MultiDm(game, GameRMsg1);
            mdm.BindEmu();
            mdm.startYuhunMenber();

        }

        void GameStart(MultiDm mdm)
        {
            //获取雷电模拟器路径
            if (GetEmuPath())
            {
                //模拟器是否启动
                if (FindEmu(mdm.game))
                {
                    mdm.BindEmu();
                    mdm.ArrPatio();

                }
                else
                {
                    LeiDian ld = new LeiDian(emupath);
                    ld.RunEmu(mdm.game);
                }
            }
            else
            {
                Msg("没有安装雷电模拟器，请安装后使用");
            }

        }


        private void btnGame2Start_Click(object sender, EventArgs e)
        {
            MultiDm mdm = new MultiDm(GetGame(sender), GameRMsg2);
            mdm.BindEmu();
            mdm.startYuhunCaptain();
        }

       
        //获取模拟器名称
        string GetGame(object sender)
        {
            Button btn = (Button)sender;
            Panel panel = (Panel)btn.Parent;
            return panel.Tag.ToString();
        }







        #region 信息框

        void RMsg(string content)
        {
            OutMsg(rtbLog1, "主线程", content, Color.Red);
        }

        void GameRMsg1(string game, string content)
        {
            OutMsg(rtbLog1, game, content, Color.Green);
        }
        void GameRMsg2(string game, string content)
        {
            OutMsg(rtbLog1, game, content, Color.Green);
        }

        void OutMsg(RichTextBox rtb, string game, string msg, Color color)
        {
            rtb.BeginInvoke(new EventHandler(delegate
            {
                rtb.SelectionStart = rtb.Text.Length;//设置插入符位置为文本框
                rtb.SelectionColor = color;//设置文本颜色
                rtb.AppendText(game + "：" + msg + "\r\n");//输出文本，换行
                rtb.ScrollToCaret();//滚动条滚到到最新插入行
            }));
        }

        void Msg(string str)
        {
            rtbLog1.AppendText(str + "\n");
        } 

        #endregion


        #region UI事件    

        private void radioBtn_captain_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                taskType = "队长";
                Msg("选中御魂十队长");
            }
            
        }

        private void radioBtn_Member_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                taskType = "队员";
                Msg("选中御魂十队员");
            }

        }

        private void btnBindEmu_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        //注册大漠插件
        void RegDM()
        {
            int dm_ret = dm.Reg("szyht003adac8d5feb361aab6d4cde72a9623983", "");
            if (dm_ret == 1)
            {
                lblReg.Text = "注册成功，" + "插件版本为:" + dm.Ver();             
            }
            else
            {
                Msg("注册失败，" + "错误代码:" + dm_ret.ToString());
            }
        }

        //测试按钮
        private void btnTest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                RMsg(Cmd.RandomInt(10).ToString());
                dm.delay(1000);
            }
            
        }





        //private void linkLabel_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    LinkLabel lbl = (LinkLabel)sender;
        //    listBox1.Items.Add(lbl.Text);
        //}

    }
}
