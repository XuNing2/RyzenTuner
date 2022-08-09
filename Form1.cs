﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace RyzenTuner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.EnergyStar;
            checkBox3.Checked = Properties.Settings.Default.CloseToTray;
            textBox1.Text = Properties.Settings.Default.CustomMode;
            SyncEnergyModeSelection();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnergyStar = checkBox1.Checked;
            Properties.Settings.Default.Save();
            timer1_Tick(sender, e);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CloseToTray = checkBox3.Checked;
            Properties.Settings.Default.Save();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Properties.Settings.Default.CloseToTray)
            {
                if (radioButton6.Checked)
                {
                    ChangeEnergyMode(radioButton6, e);
                }

                e.Cancel = true;
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // check energystar.exe is running, if not, start it
            if (checkBox1.Checked)
            {
                if (CommonUtils.IsSupportEnergyStar())
                {
                    StartEnergyStar();
                }
            }
            else
            {
                StopEnergyStar();
            }

            ApplyEnergyMode();
        }

        private static void StartEnergyStar()
        {
            if (!Process.GetProcessesByName("energystar").Any())
            {
                Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) +
                              "\\energystar\\EnergyStar.exe");
            }
        }

        public static void StopEnergyStar()
        {
            foreach (Process p in Process.GetProcessesByName("energystar"))
            {
                p.Kill();
            }
        }

        private void ChangeEnergyMode(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                string checkedMode = ((RadioButton)sender).Tag.ToString();
                Properties.Settings.Default.CurrentMode = checkedMode;
                Properties.Settings.Default.Save();
                SyncEnergyModeSelection();

                ApplyEnergyMode();
            }
        }

        private void ApplyEnergyMode()
        {
            try
            {
                var powerLimit = this.GetPowerLimitByMode(Properties.Settings.Default.CurrentMode);

                // 自动模式下，根据系统状态自动调整
                if (Properties.Settings.Default.CurrentMode == "AutoMode")
                {
                    powerLimit = this.AutoModePowerLimit();
                }

                // 数值修正
                if (powerLimit < 0)
                {
                    powerLimit = 1;
                }

                var noticeText = string.Format(@"[{0}]
限制功率：{1:0}W，实际功率：{2:0}W
CPU: {3:0}%, GPU: {4:0}%",
                    Properties.Settings.Default.CurrentMode,
                    powerLimit,
                    _hardwareMonitor.CpuPackagePower,
                    _hardwareMonitor.CpuUsage,
                    _hardwareMonitor.VideoCard3DUsage
                );
                if (noticeText.Length > 64)
                {
                    noticeText = noticeText.Substring(0, 64);
                }

                notifyIcon1.Text = noticeText;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                // TODO：与上次参数一致的情况下，不调用 ryzenadj.exe

                // --stapm-limit：持续功率限制
                // --fast-limit：实际功率限制
                // --slow-limit：平均功率限制
                startInfo.FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) +
                                     "\\ryzenadj\\ryzenadj.exe";
                startInfo.Arguments = "--stapm-limit " + powerLimit * 1000 + " --fast-limit " + powerLimit * 1000 +
                                      " --slow-limit " +
                                      powerLimit * 1000;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                radioButton5.Checked = true;
                ChangeEnergyMode(radioButton5, EventArgs.Empty);
            }
        }

        /**
         * 计算自动模式下的限制功率（单位：瓦）
         *
         * 改进：
         * 1、适配不同型号 CPU
         */
        private int AutoModePowerLimit()
        {
            _hardwareMonitor.Monitor();

            var cpuUsage = _hardwareMonitor.CpuUsage;
            var videoCard3DUsage = _hardwareMonitor.VideoCard3DUsage;

            var isNight = CommonUtils.IsNight(DateTime.Now);

            // 三个档位：low（待机）、medium（平衡）、high（高性能）
            // 插电模式下
            var low = 1;
            var medium = 20;
            var high = 30;

            // 电池模式下
            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
            {
                low = 1;
                medium = 16;
                high = 25;
            }

            // 夜晚
            if (isNight)
            {
                low = 1;
                medium = 8;
                high = 16;
            }

            // 默认使用 medium（平衡）
            var powerLimit = medium;

            // 符合下面条件之一的情况下，使用 low（待机）
            var idleSecond = CommonUtils.GetIdleSecond();
            if (
                // 条件1：白天 && 非活跃时间超过16分钟 && CPU 占用小于 10% && 显卡占用小于 10%
                (!isNight && idleSecond >= 16 * 60 && cpuUsage < 10 && videoCard3DUsage < 10) ||
                // 条件2：夜晚 && 非活跃时间超过4分钟 && CPU 占用小于 20% && 显卡占用小于 20%
                (isNight && idleSecond >= 4 * 60 && cpuUsage < 20 && videoCard3DUsage < 20)
            )
            {
                powerLimit = low;
            }

            // CPU 超过 60% 占用后，使用 high（高性能）
            if (cpuUsage >= 60)
            {
                powerLimit = high;
            }

            return powerLimit;
        }

        private void SyncEnergyModeSelection()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == Properties.Settings.Default.CurrentMode)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Checked = true;
                }
            }

            foreach (ToolStripItem tsmi in contextMenuStrip1.Items)
            {
                if (tsmi.Tag != null && tsmi.Tag.ToString() == Properties.Settings.Default.CurrentMode)
                {
                    ToolStripMenuItem tsmi2 = (ToolStripMenuItem)tsmi;
                    tsmi2.Checked = true;
                }
                else if (tsmi is ToolStripMenuItem)
                {
                    ToolStripMenuItem tsmi2 = (ToolStripMenuItem)tsmi;
                    tsmi2.Checked = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked) radioButton5.Checked = true;
            Properties.Settings.Default.CustomMode = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void ToolStripMenuItems_Clicked(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == ((ToolStripMenuItem)sender).Tag.ToString())
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Checked = true;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Length > 1 && Environment.GetCommandLineArgs()[1] == "-hide")
            {
                this.Hide();
            }
        }

        private float GetPowerLimitByMode(string mode)
        {
            return float.Parse(Properties.Settings.Default[mode].ToString());
        }

        private string GetModeDetailText(string mode)
        {
            return String.Format("{0}-{1}W",
                Properties.Strings.ResourceManager.GetString(mode),
                GetPowerLimitByMode(mode)
            );
        }
    }
}