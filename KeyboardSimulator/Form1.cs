using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Timers;

namespace KeyboardSimulator
{
    public partial class Form1 : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static bool recording = false, repeating = false, outputting = false;
        private static int hotkey = -1, delay = 100, counter = 0;
        private static string output = "", exceptionKeys;
        private static System.Timers.Timer outputTimer;
        private static Button _hotkeyButton;

        public Form1()
        {
            InitializeComponent();

            outputTimer = new System.Timers.Timer();
            outputTimer.AutoReset = true;
            outputTimer.Elapsed += new ElapsedEventHandler(TimerTick);

            _hotkeyButton = hotkeyButton;

            exceptionKeys = "(){}";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (hotkey < 0)
            {
                MessageBox.Show("Hotkey not recorded.");
            }
            else if (outputBox.Text == "")
            {
                MessageBox.Show("No output found.");
            }
            else
            {
                if (Int32.TryParse(delayBox.Text, out delay))
                {
                    output = outputBox.Text;
                    repeating = repeatCheck.Checked;

                    DisableInput(true);

                    _hookID = SetHook(_proc);
                }
                else
                {
                    MessageBox.Show("Delay must be a numeric value.");
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            DisableInput(false);
            outputting = false;
            counter = 0;

            UnhookWindowsHookEx(_hookID);
        }

        private void DisableInput(bool disable)
        {
            startButton.Enabled = !disable;
            stopButton.Enabled = disable;
            hotkeyButton.Enabled = !disable;

            delayBox.Enabled = !disable;
            outputBox.Enabled = !disable;

            repeatCheck.Enabled = !disable;
        }

        private void hotkeyButton_Click(object sender, EventArgs e)
        {
            hotkeyButton.Text = "Recording hotkey...";
            _hookID = SetHook(_proc);
            recording = true;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine((Keys)vkCode + " (" + vkCode + ")");

                if (recording)
                {
                    hotkey = vkCode;
                    _hotkeyButton.Text = (Keys)vkCode + " selected as hotkey";

                    recording = false;
                    UnhookWindowsHookEx(_hookID);
                } else if (vkCode == hotkey)
                {
                    outputting = !outputting;
                    counter = 0;
                    SendOutput();
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static void SendOutput()
        {
            outputTimer.Interval = delay;
            outputTimer.Start();
        }
        
        private static void TimerTick(object sender, ElapsedEventArgs e)
        {
            if (outputting)
            {
                if (counter < output.Length)
                {
                    //<enter>
                    if (counter + 1 < output.Length && output.Substring(counter, 2) == "<<")
                    {
                        SendKeys.SendWait(output.Substring(counter, 1));
                        counter += 2;
                    }
                    else if (counter + 6 < output.Length && output.Substring(counter, 7) == "<enter>")
                    {
                        SendKeys.SendWait("{ENTER}");
                        counter += 7;
                    } 
                    else
                    {
                        //SendKeys.Send(output.Substring(counter, 1));
                        if (exceptionKeys.Contains(output.Substring(counter, 1)))
                        {
                            SendKeys.SendWait("{" + output.Substring(counter, 1) + "}");
                        }
                        else
                        {
                            SendKeys.SendWait(output.Substring(counter, 1));
                        }
                        
                        counter++;
                    }

                    if (counter < output.Length && output.Substring(counter, 1) == "<")
                    {
                        string sub = output.Substring(counter + 1);
                        int endSub = sub.IndexOf(">");
                        if (endSub > 0)
                        {
                            sub = sub.Substring(0, sub.IndexOf(">"));
                            int newDelay = delay;
                            if (int.TryParse(sub, out newDelay))
                            {
                                outputTimer.Interval = newDelay;
                                counter = output.IndexOf(">", counter) + 1;
                            }
                        }
                    }
                    else if (outputTimer.Interval != delay)
                    {
                        outputTimer.Interval = delay;
                    }
                }
                else if (repeating)
                {
                    counter = 0;
                }
                else
                {
                    outputting = false;
                    outputTimer.Stop();
                    counter = 0;
                }
            }
            else
            {
                outputTimer.Stop();
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private void helpLabel_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.Show();
        }
    }
}
