using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Threading;
using System.Runtime.InteropServices;
using System.Management;
using System.Security.Principal;

namespace ResourceMonitor
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter memCounter;
        //private PerformanceCounter memCounter2;
        private PerformanceCounter diskCounter;
        private List<PerformanceCounter> gpuCounters;
        private int updateTime = 3000;
        public Form1()
        {
            InitializeComponent();

            if (IsAdministrator())
            {

            }
            else
            {
                string message = "Please Run as Admin For Temps!";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //memCounter2 = new PerformanceCounter("Memory", "Committed Bytes"); // initialize new counter for used memory
            memCounter = new PerformanceCounter("Memory", "Available MBytes");
            diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");

            // Delay the start of the timer by 1 second


            StartDelay();
        }
        private async void StartDelay()
        {
            await Task.Delay(updateTime);
            // Start the timer
            timer1.Interval = updateTime;
            timer1.Start();

            gpuCounters = GetGPUCounters();
            UpdateGPUUsage();

            //GetCpuTemperature();
        }
        public float GetCpuTemperature()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\WMI",
                "SELECT * FROM MSAcpi_ThermalZoneTemperature");

            foreach (ManagementObject obj in searcher.Get())
            {
                double temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                temp = (temp - 2732) / 10.0; 
                cpuTemp_label1.Text = temp.ToString();
                return (float)temp;
            }

            return -1; // failed to retrieve temperature
        }
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        public static class PerformanceInfo
        {
            [DllImport("psapi.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

            [StructLayout(LayoutKind.Sequential)]
            public struct PerformanceInformation
            {
                public int Size;
                public IntPtr CommitTotal;
                public IntPtr CommitLimit;
                public IntPtr CommitPeak;
                public IntPtr PhysicalTotal;
                public IntPtr PhysicalAvailable;
                public IntPtr SystemCache;
                public IntPtr KernelTotal;
                public IntPtr KernelPaged;
                public IntPtr KernelNonPaged;
                public IntPtr PageSize;
                public int HandlesCount;
                public int ProcessCount;
                public int ThreadCount;
            }

            public static Int64 GetPhysicalAvailableMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }

            public static Int64 GetTotalMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Itty Bitty Resource Monitor";



        }
        public List<PerformanceCounter> GetGPUCounters()
        {
            var category = new PerformanceCounterCategory("GPU Engine");
            var counterNames = category.GetInstanceNames();

            var gpuCounters = new List<PerformanceCounter>();

            foreach (var counterName in counterNames)
            {
                try
                {
                    if (counterName.EndsWith("engtype_3D"))
                    {
                        var instance = new PerformanceCounterCategory("GPU Engine").GetCounters(counterName)
                                            .FirstOrDefault(counter => counter.CounterName.Equals("Utilization Percentage"));

                        if (instance != null)
                        {
                            gpuCounters.Add(instance);
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    // Handle missing or inaccessible performance counter instance
                    Console.WriteLine($"Failed to retrieve performance counter value: {ex.Message}");
                }
            }

            return gpuCounters;
        }

        public async void UpdateGPUUsage()
        {
            while (true)
            {
                try
                {
                    //causing lag each updateTime!
                    gpuCounters.ForEach(x => x.NextValue());
                    await Task.Delay(updateTime);

                    float result = 0;
                    int validCounters = 0;

                    foreach (var counter in gpuCounters)
                    {
                        try
                        {
                            var value = counter.NextValue();
                            if (!float.IsNaN(value))
                            {
                                result += value;
                                validCounters++;
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Handle missing or inaccessible performance counter instance
                            Console.WriteLine($"Failed to retrieve performance counter value: {ex.Message}");
                        }
                    }

                    if (validCounters > 0)
                    {
                        gpuUsedPercent_label1.Text = "Gpu Usage: " + result.ToString("F2") + "%";
                        gpu_progressBar1.Value = (int)result;
                    }
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine($"An error occurred during GPU usage update: {ex.Message}");
                }
            }
        }
        private static string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffixes.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return $"{dblSByte:0.##} {suffixes[i]}";
        }
        //*******************************Form/Input********************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            Int64 avMem = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 totMem = PerformanceInfo.GetTotalMemoryInMiB();
            decimal usedMem = totMem - avMem;
            decimal percentFree = ((decimal)avMem / (decimal)totMem) * 100;
            decimal percentOccupied = 100 - percentFree;

            float cpuUsage = cpuCounter.NextValue();
            labelCPU.Text = string.Format("CPU Usage: {0:F2}%", cpuUsage);
            progressBarCPU.Value = (int)cpuUsage;


            //float usedMem = memCounter2.NextValue();
            //float usedMemGB = usedMem / (1024 * 1024 * 1024); // convert to GB
            //float usedFinal = usedMemGB;
            decimal usedGB = usedMem / 1024;
            labelMem2.Text = string.Format("Used Memory: {0:F2} GB", usedGB);
        

            float memAvl = memCounter.NextValue();
            decimal finalAvl = (decimal)memAvl / 1024;
            labelMem.Text = string.Format("Available Memory: {0:F2} GB", finalAvl);


            //float totalM = usedMem + finalAvl;
            //decimal totMemGB = totMem / 1024;
            decimal totMemGB = usedGB + finalAvl;
            totalMem.Text = "Total Memory: " + totMemGB.ToString("F2") + " GB";

            ram_memory_progressBar1.Maximum = (int)totMem;
            ram_memory_progressBar1.Value = (int)usedMem;

            mempercentLabel.Text = "Memory Used: " + percentOccupied.ToString("F2") + "%";


            float diskUsage = diskCounter.NextValue();
            labelDisk.Text = string.Format("System Disk Usage: {0:F2}%", diskUsage);

            DriveInfo driveInfo2 = new DriveInfo("C");
            float usedDiskSpace = 100 - (float)(driveInfo2.AvailableFreeSpace / (double)driveInfo2.TotalSize * 100);
            labelUsedDiskSpace.Text = string.Format("Used Disk Space: {0:F2}%", usedDiskSpace);
            usedDisk_progressBar1.Value = (int)usedDiskSpace;

            DriveInfo driveInfo = new DriveInfo("C");
            float availableDiskSpace = (float)(driveInfo.AvailableFreeSpace / (double)driveInfo.TotalSize * 100);
            labelAvailableDiskSpace.Text = string.Format("Available Disk Space: {0:F2}%", availableDiskSpace);
        }

    }
}
