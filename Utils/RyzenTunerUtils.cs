﻿using System;
using System.Runtime.InteropServices;
using RyzenTuner.Common.Container;

namespace RyzenTuner.Utils
{
    public static class RyzenTunerUtils
    {
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        // https://www.pinvoke.net/default.aspx/user32.GetLastInputInfo
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-lastinputinfo
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)] public int cbSize;
            [MarshalAs(UnmanagedType.U4)] public UInt32 dwTime;
        }

        /**
         * 返回系统空闲时间，单位：秒
         *
         * 参考：
         * https://stackoverflow.com/questions/203384/how-to-tell-when-windows-is-inactive
         */
        public static int GetIdleSecond()
        {
            var idleTime = 0;
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            var envTicks = Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                var lastInputTick = (int)lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : idleTime);
        }


        /**
         * 检查当前是否处于【待机模式】
         */
        public static bool IsSleepMode(float powerLimit)
        {
            return Math.Abs(powerLimit - GetPowerLimitByMode("SleepMode")) < 0.01;
        }

        /**
         * 检查当前是否处于【省电模式】
         */
        public static bool IsPowerSaveModeMode(float powerLimit)
        {
            return Math.Abs(powerLimit - GetPowerLimitByMode("PowerSaveMode")) < 0.01;
        }

        /**
         * 检查当前是否处于【平衡模式】
         */
        public static bool IsBalancedMode(float powerLimit)
        {
            return Math.Abs(powerLimit - GetPowerLimitByMode("BalancedMode")) < 0.01;
        }

        /**
         * 检查当前是否处于【性能模式】
         */
        public static bool IsPerformanceMode(float powerLimit)
        {
            return Math.Abs(powerLimit - GetPowerLimitByMode("PerformanceMode")) < 0.01;
        }

        public static float GetPowerLimitByMode(string mode)
        {
            return float.Parse(Properties.Settings.Default[mode].ToString());
        }

        public static string GetNoticeText()
        {
            var hardwareMonitor = AppContainer.HardwareMonitor();
            var powerLimit = RyzenAdjUtils.GetPowerLimit();

            var powerLimitText = Properties.Strings.TextNoticeText
                .Replace("{power_limit}", $"{powerLimit:0}")
                .Replace("{actual_power_limit}", $"{hardwareMonitor.CpuPackagePower:0.00}");

            var noticeText = $@"{Properties.Settings.Default.CurrentMode}
{powerLimitText}
CPU: {hardwareMonitor.CpuUsage:0}%、{hardwareMonitor.CpuTemperature:0}℃、{hardwareMonitor.CpuFreq:0}MHz，GPU: {hardwareMonitor.VideoCard3DUsage:0}%";
            if (noticeText.Length >= 64)
            {
                noticeText = noticeText.Substring(0, 63);
            }

            return noticeText;
        }

        public static string GetModeDetailText(string mode)
        {
            return $"{Properties.Strings.ResourceManager.GetString(mode)}-{GetPowerLimitByMode(mode)}W";
        }
    }
}