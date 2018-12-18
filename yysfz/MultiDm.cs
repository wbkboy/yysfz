using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace yysfz
{
    class MultiDm
    {
        protected dmsoft dm;
        public string game;
        protected Action<string, string> gameMsg;
        List<Pic> UsualPics;
        List<Pic> SkipPics;
        private static bool memberStart = false;
        private static bool captainStart = false;
        private readonly string mainPath = @"e:\pic\";
        public MultiDm(string game, Action<string, string> gameMsg)
        {
            dm = new dmsoft();
            dm.SetPath(mainPath);
            this.game = game;
            this.gameMsg = gameMsg;
        }

        public void startYuhunMenber()
        {
            MultiAction(YuhunMenber);
        }

        public void startYuhunCaptain()
        {
            MultiAction(YuhunCaptain);
        }


        #region 任务类

        // 御魂队员任务
        void YuhunMenber()
        {
            memberStart = true;
            while (!captainStart)
            {
                Thread.Sleep(1000);
                GameMsg("等待队长开始任务");
            }
            GameMsg("就绪,开始任务");
            //开启御魂BUFF
            YuhunBuff(true);
            //等待接收邀请
            GotoClick(UPic("组队邀请"));
            //开始战斗
            MemberBattle();
            //战斗完毕后关掉buff
            YuhunBuff(false);
        }

        // 御魂队长任务
        void YuhunCaptain()
        {
            //开启监视线程
            captainStart = true;
            //等待队员就绪
            while (!memberStart)
            {
                Thread.Sleep(1000);
                GameMsg("等待队员开始任务");
            }
            GameMsg("就绪,开始任务");
            //开启御魂BUFF
            YuhunBuff(true);
            //到达庭院最右
            GotoMianPageRight();
            //执行组队
            GotoClick(UPic("御魂图标"));
            GotoClick(UPic("御魂界面"));
            GotoClick(UPic("点击十层"));
            GotoClick(UPic("验证十层"));
            GotoClick(UPic("队伍选项"));
            GotoClick(UPic("调整选项"));
            GotoClick(UPic("验证选项"));
            GotoClick(UPic("开始邀请"));
            GotoClick(UPic("队友图片"));
            GotoClick(UPic("确认邀请"));
            //开始战斗
            CaptainBattle();
            //战斗完毕后关掉buff
            YuhunBuff(false);
        }
        #endregion



        #region 战斗类

        //开始战斗（队长）
        void CaptainBattle()
        {
            while (captainStart)
            {
                FindPic_Click(UPic("开始战斗"), 1000);
                FindPic_Click(UPic("准备战斗"), 2000);
                FindPic_Click(UPic("战斗胜利"), 1000);
                FindPic_Click(UPic("打开达摩"), 1000);
                if (FindPic_Click(UPic("默认邀请"), 1000))
                {
                    GotoClick(UPic("默认选中"));
                }
                if (FindPic_Click(UPic("体力不足"), 1000))
                {
                    captainStart = false;
                    GameMsg("体力不足，停止任务");
                }
                if (!memberStart)
                {
                    GameMsg("队友离开任务，停止战斗");
                    captainStart = false;
                }
            }
        }

        //开始战斗（队员）
        void MemberBattle()
        {
            while (memberStart)
            {
                FindPic_Click(UPic("组队邀请"), 3000);
                FindPic_Click(UPic("准备战斗"), 2000);
                FindPic_Click(UPic("战斗胜利"), 1000);
                FindPic_Click(UPic("打开达摩"), 1000);
                if (FindPic_Click(UPic("体力不足"), 1000))
                {
                    memberStart = false;
                }
                if (!captainStart)
                {
                    GameMsg("队友离开任务，停止战斗");
                    memberStart = false;
                }
            }
        }

        #endregion

        #region 加成类

        //御魂加成开关
        void YuhunBuff(bool sw)
        {
            List<Buff> buffs = new List<Buff>();
            if (sw)
            {
                buffs.Add(new Buff("御魂加成", true));
            }
            else
            {
                buffs.Add(new Buff("御魂加成", false));
            }
            ChangeBuff(buffs);
        }

        //更改加成
        void ChangeBuff(List<Buff> buffs)
        {
            GotoClick(UPic("加成开关1"), UPic("加成开关2"));
            GotoWait(UPic("加成界面"));
            foreach (Buff buff in buffs)
            {
                BuffSwitch(buff.Name, buff.Sw);
                Thread.Sleep(200);
            }

            Move_Click(100, 100);
        }

        //加成开关
        void BuffSwitch(string buffName, bool sw)
        {
            //检查加成是否存在
            if (!FindPicByTime(UPic(buffName), 2))
            {
                GameMsg(buffName + "已用完");
                return;
            }
            if (sw)
            {
                if (!FindPic(UPic(buffName + "开")))
                {
                    GotoClick(UPic(buffName + "关"));
                }
                GameMsg(buffName + "已开启");
            }

            if (!sw)
            {
                if (!FindPic(UPic(buffName + "关")))
                {
                    GotoClick(UPic(buffName + "开"));
                }
                GameMsg(buffName + "已关闭");
            }

        }

        #endregion


        #region 图色类

        //找到图片+点击
        void GotoClick(params Pic[] pics)
        {

            while (true)
            {
                foreach (Pic pic in pics)
                {
                    if (FindPic_Click(pic, 1000))
                    {
                        return;
                    }
                }
                Thread.Sleep(100);
            }
        }

        //找到图片+等待
        void GotoWait(params Pic[] pics)
        {

            while (true)
            {
                foreach (Pic pic in pics)
                {
                    if (FindPic(pic, 1000))
                    {
                        return;
                    }
                }
                Thread.Sleep(100);
            }
        }

        //查找图片(按时间执行)
        bool FindPicByTime(Pic pic, int sec)
        {
            bool finded = false;
            for (int i = 0; i < 5 * sec; i++)
            {
                if (finded = FindPic(pic, 1000))
                {
                    break;
                }
                Thread.Sleep(200);
            }
            return finded;
        }



        //查找图片+点击
        bool FindPic_Click(Pic pic)
        {
            bool finded = false;
            dm.FindPic(0, 0, 960, 540, pic.Path, "000000", 0.9, 0, out int x, out int y);
            if (x > 0 && y > 0)
            {
                finded = true;
                //GameMsg(String.Format("找到{0},坐标为{1},{2}", pic.Name, x, y));
                GameMsg(pic.Name);
                if (pic.X == 0) { pic.X = x; }
                if (pic.Y == 0) { pic.Y = y; }
                Move_Click(pic.X, pic.Y);
                Thread.Sleep(1000);
            }
            return finded;
        }

        //查找图片+点击
        bool FindPic_Click(Pic pic, int delay)
        {
            bool finded = false;
            dm.FindPic(0, 0, 960, 540, pic.Path, "000000", 0.9, 0, out int x, out int y);
            if (x > 0 && y > 0)
            {
                finded = true;
                //GameMsg(String.Format("找到{0},坐标为{1},{2}", pic.Name, x, y));
                GameMsg(pic.Name);
                if (pic.X == 0) { pic.X = x; }
                if (pic.Y == 0) { pic.Y = y; }
                Move_Click(pic.X, pic.Y);
                Thread.Sleep(delay);
            }
            return finded;
        }

     
        //查找图片
        bool FindPic(Pic pic)
        {
            bool finded = false;
            dm.FindPic(0, 0, 960, 540, pic.Path, "000000", 0.9, 0, out int x, out int y);
            if (x > 0 && y > 0)
            {
                finded = true;
                GameMsg(pic.Name);
                Thread.Sleep(1000);//表示找到图片后的延迟，没找到没有延迟
            }
            return finded;
        }

        //查找图片
        bool FindPic(Pic pic, int delay)
        {
            bool finded = false;
            dm.FindPic(0, 0, 960, 540, pic.Path, "000000", 0.9, 0, out int x, out int y);
            if (x > 0 && y > 0)
            {
                finded = true;
                GameMsg(pic.Name);
                Thread.Sleep(delay);//表示找到图片后的延迟，没找到没有延迟
            }
            return finded;
        }

        #endregion



        #region 模拟操作类

        // 移动并点击左键
        void Move_Click(int x, int y)
        {
            dm.MoveTo(x + Cmd.RandomInt(10), y + Cmd.RandomInt(10));
            Thread.Sleep(200);
            dm.LeftClick();
        }

        // 滑动到主界面最右边
        void GotoMianPageRight()
        {
            bool arrRight = false;
            while (!arrRight)
            {
                SwipeScreen(480, 500, -100, 0);
                arrRight = FindPic_Click(UPic("庭院最右"), 1000);
                Thread.Sleep(500);
            }
        }

        // 滑动屏幕       
        void SwipeScreen(int fx, int fy, int rx, int ry)
        {
            dm.MoveTo(fx, fy);
            Thread.Sleep(100);
            dm.LeftDown();
            for (int i = 0; i < 3; i++)
            {
                dm.MoveR(rx, ry);
                Thread.Sleep(100);
            }
            dm.LeftUp();
        }

        #endregion



        #region 工具类

        //根据名字取得图片对象
        Pic UPic(string name)
        {
            if (UsualPics == null)
            {
                UsualPics = Cmd.DeserPics(mainPath + "upic.json");
            }
            return UsualPics.Find(S => S.Name == name);
        }

        // 多线程封装1
        void MultiAction(Action action)
        {
            Action ac = action;
            ac.BeginInvoke(null, null);
        }

        // 多线程封装2
        void MultiAction(Action<string> action, string str)
        {
            Action<string> ac = action;
            ac.BeginInvoke(str, null, null);
        }

        // 绑定模拟器
        public void BindEmu()
        {
            int top_Hwnd = dm.FindWindow("", game);
            GameMsg("顶层句柄为:" + top_Hwnd.ToString());
            string child_Hwnd = dm.EnumWindow(top_Hwnd, "", "", 4);
            GameMsg("子句柄为:" + child_Hwnd);
            int dm_ret = dm.BindWindowEx(int.Parse(child_Hwnd), "dx.graphic.opengl", "windows", "windows", "", 0);
            if (dm_ret == 1)
            {
                GameMsg("绑定成功");
            }
            else
            {
                GameMsg("绑定失败" + "错误代码:" + dm_ret.ToString());

            }
        }

        //信息输出封装
        void GameMsg(string content)
        {
            gameMsg(game, content);
        }
        #endregion




        #region 待处理类

        //需要跳过的步骤
        void SkipStep()
        {
            if (SkipPics == null)
            {
                SkipPics = Cmd.DeserPics(mainPath + "spic.json");
            }
            while (true)
            {
                foreach (Pic pic in SkipPics)
                {
                    FindPic_Click(pic);

                }
                Thread.Sleep(1000);
            }
        }

        #endregion
        //从任何地方到达庭院
       public void ArrPatio()
        {
            while (!FindPic(UPic("加成开关1")))
            {
                SkipStep();
            }
        }

     
    }
}
