using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Watch
{
    public partial class �ð� : Form
    {
        enum ToolMode { Timer, StopWatch, Alarm, None };
        ToolMode toolMode;
        bool IsKorean = true;
        public �ð�()
        {
            InitializeComponent();
            toolMode = ToolMode.None;
            // Form�� �ε�� �� Timer ����
            // �⺻�� �ð�
            NowTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            System.Windows.Forms.Timer NowTime = new System.Windows.Forms.Timer();
            NowTime.Interval = 1000; // 1�� ����
            NowTime.Tick += NowTime_Tick;
            NowTime.Start();

            #region ���� �� ���� ��� ����
            string AlarmName = "", Time = "", RepeatDays = "", Rename = "", Delete = "";

            if (IsKorean)
            {
                AlarmName = StringLib_ko.AlarmName;
                Time = StringLib_ko.Time;
                RepeatDays = StringLib_ko.RepeatDays;
                Rename = StringLib_ko.Rename;
                Delete = StringLib_ko.Delete;
            }
            else
            {
                AlarmName = StringLib_en.AlarmName;
                Time = StringLib_en.Time;
                RepeatDays = StringLib_en.RepeatDays;
                Rename = StringLib_en.Rename;
                Delete = StringLib_en.Delete;
            }
            #endregion

            // ContextMenuStrip �ʱ�ȭ
            contextMenu = new ContextMenuStrip();
            var renameMenuItem = new ToolStripMenuItem(Rename); // �̸� ����
            renameMenuItem.Click += RenameMenuItem_Click;
            contextMenu.Items.Add(renameMenuItem);

            var deleteMenuItem = new ToolStripMenuItem(Delete); // �����ϱ�
            deleteMenuItem.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteMenuItem);

            AlarmListView.FullRowSelect = true;
            Week.Add(MonBtn);
            Week.Add(TueBtn);
            Week.Add(WedBtn);
            Week.Add(ThuBtn);
            Week.Add(FriBtn);
            Week.Add(SatBtn);
            Week.Add(SunBtn);
            AlarmListView.Columns.Add(AlarmName, AlarmListView.Width * 1 / 4, HorizontalAlignment.Center);
            AlarmListView.Columns.Add(Time, AlarmListView.Width * 2 / 4, HorizontalAlignment.Center);
            AlarmListView.Columns.Add(RepeatDays, AlarmListView.Width * 1 / 4, HorizontalAlignment.Center);

            alarmTimer = new System.Windows.Forms.Timer();
            alarmTimer.Interval = 1000; // 1000ms = 1��
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();

            Init();
        }

        /// <summary>
        /// ���� �������� �ִٸ� �ش� ������ ������
        /// </summary>
        private void Init()
        {
            if (Properties.Settings.Default.TimerTime != "")
                ShowTimerTime.Text = Properties.Settings.Default.TimerTime;
            else
                ShowTimerTime.Text = "00:00:00";

            if (Properties.Settings.Default.StopWatchTimerTime != "")
                ShowStopWatchTime.Text = Properties.Settings.Default.StopWatchTimerTime;
            else
                ShowStopWatchTime.Text = "00:00:00.00";

            // Ÿ�̸� ������ ��������
            for (int i = 0; i < StopWatchListview.Items.Count; i++)
            {
                Properties.Settings.Default.StopWatchTimes.Add(StopWatchListview.Items[i].SubItems[1].Text);
                Properties.Settings.Default.StopWatchTimeDiffs.Add(StopWatchListview.Items[i].SubItems[2].Text);
            }

            // �����ġ ������ ��������
            for (int i = 0; i < Properties.Settings.Default?.StopWatchTimes?.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem($"{i + 1}");
                listViewItem.SubItems.Add(Properties.Settings.Default?.StopWatchTimes[i]?.ToString());
                listViewItem.SubItems.Add(Properties.Settings.Default?.StopWatchTimeDiffs[i]?.ToString());
                StopWatchListview.Items.Add(listViewItem);
            }

            // �˶� ������ ��������
            for (int i = 0; i < Properties.Settings.Default?.AlaramNames?.Count; i++)
            {
                AlarmInfo AI = new AlarmInfo();
                AI.Name = Properties.Settings.Default.AlaramNames[i];
                AI.IsRepeat = (Properties.Settings.Default.AlarmRepeatDays[i] != "-");
                AI.Days = Properties.Settings.Default?.AlarmRepeatDays[i]?.Trim().Split(',').Select(x => x.Trim()).ToList();
                AI.DateTime = DateTime.Parse(Properties.Settings.Default.AlaramTimes[i]);

                AI.DateTime = GetNextAlarmTime(AI);
                AlaramInfos.Add(AI);
            }
            TimerListViewUpdate();
        }

        private void NowTime_Tick(object? sender, EventArgs e)
        {
            // ���� �ð��� Label�� ǥ��
            NowTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// ��� ���� ��
        /// </summary>
        /// <param name="mode"></param>
        private void ChangeButtonColor(int mode)
        {
            toolMode = (ToolMode)mode;
            switch (mode)
            {
                case 0: // Ÿ�̸�
                    Timer.BackColor = Color.Yellow;
                    Alarm.BackColor = Color.Transparent;
                    StopWatch.BackColor = Color.Transparent;
                    TimerToolSetting(true);
                    StopWatchToolSetting(false);
                    AlarmToolSetting(false);
                    NowTimeLabel.Visible = false;
                    break;

                case 1: // ��ž��ġ
                    Timer.BackColor = Color.Transparent;
                    StopWatch.BackColor = Color.Yellow;
                    Alarm.BackColor = Color.Transparent;
                    TimerToolSetting(false);
                    StopWatchToolSetting(true);
                    AlarmToolSetting(false);
                    NowTimeLabel.Visible = false;
                    break;
                case 2: // �˶�
                    Timer.BackColor = Color.Transparent;
                    StopWatch.BackColor = Color.Transparent;
                    Alarm.BackColor = Color.Yellow;
                    TimerToolSetting(false);
                    StopWatchToolSetting(false);
                    AlarmToolSetting(true);
                    NowTimeLabel.Visible = false;
                    break;
                case 3: // �⺻ �ð�
                    Timer.BackColor = Color.Transparent;
                    Alarm.BackColor = Color.Transparent;
                    StopWatch.BackColor = Color.Transparent;
                    NowTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
                    NowTimeLabel.Visible = true;
                    TimerToolSetting(false);
                    StopWatchToolSetting(false);
                    AlarmToolSetting(false);
                    break;
                default:
                    break;
            }
        }

        #region �� ���� �̺�Ʈ
        /// <summary>
        /// Ÿ�̸� �� ����
        /// </summary>
        /// <param name="isTimerTool"></param>
        private void TimerToolSetting(bool isTimerTool)
        {
            ShowTimerTime.Visible = isTimerTool;
            StartTimerButton.Visible = isTimerTool;
            ResetButton.Visible = isTimerTool;
        }
        /// <summary>
        /// ��ž��ġ �� ����
        /// </summary>
        /// <param name="IsStopWatchTool"></param>
        private void StopWatchToolSetting(bool IsStopWatchTool)
        {
            StartStopWatchButton.Visible = IsStopWatchTool;
            StopWatchListview.Visible = IsStopWatchTool;
            CheckButton.Visible = IsStopWatchTool;
            StopWatchReset.Visible = IsStopWatchTool;
            ShowStopWatchTime.Visible = IsStopWatchTool;
        }
        /// <summary>
        /// �˶� �� ����
        /// </summary>
        /// <param name="IsAlarmTool"></param>
        private void AlarmToolSetting(bool IsAlarmTool)
        {
            AlarmTabControl.Visible = IsAlarmTool;
            if (IsKorean) AlarmTabControl.TabPages[0].Text = StringLib_ko.AlarmList;
            else AlarmTabControl.TabPages[0].Text = StringLib_en.AlarmList;
            if (IsKorean) AlarmTabControl.TabPages[1].Text = StringLib_ko.AddAlarm;
            else AlarmTabControl.TabPages[1].Text = StringLib_en.AddAlarm;
            InputAlarmTime.Format = DateTimePickerFormat.Custom;
            InputAlarmTime.CustomFormat = "HH:mm:ss";
            InputAlarmTime.Text = "00:00:00";
            InputAlarmTime.ShowUpDown = true;

        }

        #endregion

        /// <summary>
        /// Ÿ�̸� Ŭ�� ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Click(object sender, EventArgs e)
        {
            if (toolMode != 0)
            {
                ChangeButtonColor(0);
            }
            else
            {
                ChangeButtonColor(3);
                return;
            }
        }

        /// <summary>
        ///  ��ž��ġ Ŭ�� ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopWatch_Click(object sender, EventArgs e)
        {
            if ((int)toolMode != 1)
            {
                ChangeButtonColor(1);
            }
            else
            {
                ChangeButtonColor(3);
                return;
            }
        }
        private void Alarm_Click(object sender, EventArgs e)
        {
            if ((int)toolMode != 2)
            {
                ChangeButtonColor(2);
            }
            else
            {
                ChangeButtonColor(3);
                return;
            }
        }

        #region Ÿ�̸� ����
        /// <summary>
        /// Ÿ�̸� Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TimeSpan timeLeft;
        SettingTimerTimeForm settingTimerTimeForm = new SettingTimerTimeForm();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        bool IsStopNow = true;
        string BeginTime = "00:00:00";
        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            if (IsStopNow)
            {
                timeLeft = StringToTimeSpan_Timer(ShowTimerTime.Text);
                timer.Start();
                timer.Interval = 1000;
                timer.Start();
                timer.Tick += Timer_Tick;
                if (IsKorean) StartTimerButton.Text = StringLib_ko.Stop;
                else StartTimerButton.Text = StringLib_en.Stop;
                IsStopNow = false;
            }
            else
            {
                timer.Tick -= Timer_Tick;
                timer.Stop();
                if (IsKorean) StartTimerButton.Text = StringLib_ko.Start;
                else StartTimerButton.Text = StringLib_en.Start;
                IsStopNow = true;
            }
        }
        /// <summary>
        /// 1�ʾ� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                // 1�� ����
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));

                // Label�� �ð� ������Ʈ
                ShowTimerTime.Text = timeLeft.ToString(@"hh\:mm\:ss");
            }
            else
            {
                // �ð��� �� �Ǿ��� �� Ÿ�̸Ӹ� ����
                timer.Stop();
                IsStopNow = true;
                StartTimerButton.Text = "����";
                StartTimerButton.Enabled = false;
                string Path = Application.StartupPath;

                var assembly = Assembly.GetExecutingAssembly();
                SoundPlayer player;
                using (Stream stream = assembly?.GetManifestResourceStream("Watch.TimerSound.wav"))
                {
                    player = new SoundPlayer(stream);
                    player.PlayLooping();
                }
                //SoundPlayer player = new SoundPlayer($"{Path}data\\TimerSound.wav");
                //player.PlayLooping();
                timer.Tick -= Timer_Tick;
                TimeOver timeOver = new TimeOver();
                if (timeOver.ShowDialog() == DialogResult.OK)
                {
                    player.Stop();
                }
            }
        }

        /// <summary>
        /// �ǵ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            string start = "";
            if (IsKorean) start = StringLib_ko.Start;
            else start = StringLib_en.Start;

            if (!IsStopNow)
            {
                // �������� ��� �ϴ� ������
                timer.Tick -= Timer_Tick;
                StartTimerButton.Text = start;
                IsStopNow = true;
                timer.Stop();
            }
            if (BeginTime != "00:00:00") StartTimerButton.Enabled = true;
            ShowTimerTime.Text = BeginTime;
        }

        /// <summary>
        /// �ð� ���� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTimerTime_Click(object sender, EventArgs e)
        {
            settingTimerTimeForm.ShowDialog();
            if (settingTimerTimeForm.DialogResult == DialogResult.OK)
            {
                // ���� Ÿ�̸� Ÿ�� ������ Ȯ�� ���� ���
                BeginTime = ShowTimerTime.Text = settingTimerTimeForm.SettingTime;
                timeLeft = StringToTimeSpan_Timer(ShowTimerTime.Text);
                StartTimerButton.Enabled = true;
            }
            else
            {
                // ���� Ÿ�̸� Ÿ�� ������ ��� ���� ���
            }
        }

        /// <summary>
        /// hh:mm:ss ������ ���ڿ��� TimeSpan���� �����Ͽ� return
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private TimeSpan StringToTimeSpan_Timer(string time)
        {
            string format = @"hh\:mm\:ss";

            TimeSpan result = TimeSpan.ParseExact(time, format, CultureInfo.InvariantCulture);
            return result;
        }

        /// <summary>
        /// hh:mm:ss.ss ������ ���ڿ��� TimeSpan���� �����Ͽ� return
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private TimeSpan StringToTimeSpan_StopWatch(string time)
        {
            string format = @"hh\:mm\:ss\.ff";

            TimeSpan result = TimeSpan.ParseExact(time, format, CultureInfo.InvariantCulture);
            return result;
        }
        #endregion

        #region �����ġ ����
        /// <summary>
        /// ��ž ��ġ ���� ��ư
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TimeSpan StopWatchNowTime;
        SettingTimerTimeForm settingStopWatchTimeForm = new SettingTimerTimeForm();
        System.Windows.Forms.Timer StopWatchTimer = new System.Windows.Forms.Timer();
        Stopwatch stopwatch = new Stopwatch();
        bool IsStopWatchStopNow = true;
        string StopWatchBeginTime = "00:00:00.00";
        /// <summary>
        /// ���� ��ư Ŭ�� ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopWatchButton_Click(object sender, EventArgs e)
        {
            if (IsStopWatchStopNow)
            {
                StopWatchNowTime = StringToTimeSpan_StopWatch(ShowStopWatchTime.Text);
                StopWatchTimer.Start();
                stopwatch.Start();
                StopWatchTimer.Interval = 10;
                StopWatchTimer.Tick += StopWatchTimer_Tick;
                if (IsKorean) StartStopWatchButton.Text = StringLib_ko.Stop;
                else StartStopWatchButton.Text = StringLib_en.Stop;
                IsStopWatchStopNow = false;
            }
            else
            {
                StopWatchTimer.Tick -= StopWatchTimer_Tick;
                StopWatchTimer.Stop();
                stopwatch.Stop();
                if (IsKorean) StartStopWatchButton.Text = StringLib_ko.Start;
                else StartStopWatchButton.Text = StringLib_en.Start;
                IsStopWatchStopNow = true;
            }
        }

        /// <summary>
        /// 1�ʸ��� �ð� �����ϰ� �ð� ������Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopWatchTimer_Tick(object? sender, EventArgs e)
        {
            // 1�� ����
            StopWatchNowTime = stopwatch.Elapsed;//StopWatchNowTime.Add(TimeSpan.FromMilliseconds(10));

            // Label�� �ð� ������Ʈ
            ShowStopWatchTime.Text = StopWatchNowTime.ToString(@"hh\:mm\:ss\.ff");


        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = $"{StopWatchListview.Items.Count + 1}";
            item.SubItems.Add(ShowStopWatchTime.Text);
            if (StopWatchListview.Items.Count == 0) item.SubItems.Add("");
            else item.SubItems.Add(GetTimeDiff(ShowStopWatchTime.Text));
            StopWatchListview.Items.Insert(0, item);

        }

        /// <summary>
        /// ���� �ð��� ���̸� ����ؼ� return
        /// </summary>
        /// <param name="NowTime"></param>
        /// <returns></returns>
        private string GetTimeDiff(string NowTime)
        {
            try
            {
                TimeSpan preTime = TimeSpan.ParseExact(StopWatchListview.Items[0].SubItems[1].Text, @"hh\:mm\:ss\.ff", null);
                TimeSpan curTime = TimeSpan.ParseExact(ShowStopWatchTime.Text, @"hh\:mm\:ss\.ff", null);
                return (curTime - preTime).ToString(@"hh\:mm\:ss\.ff");
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ��ž��ġ ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopWatchReset_Click(object sender, EventArgs e)
        {
            StopWatchTimer.Tick -= StopWatchTimer_Tick;
            IsStopWatchStopNow = true;
            ShowStopWatchTime.Text = StopWatchBeginTime;
            stopwatch = new Stopwatch();
            if (IsKorean) StartStopWatchButton.Text = StringLib_ko.Start;
            else StartStopWatchButton.Text = StringLib_en.Start;
            StopWatchListview.Items.Clear();
        }

        #endregion

        #region �˶� ����
        List<System.Windows.Forms.Button> Week = new List<System.Windows.Forms.Button>();
        private ContextMenuStrip contextMenu; // �˶� ����Ʈ �� ��Ŭ�� ���ؽ�Ʈ �޴�
        private System.Windows.Forms.Timer alarmTimer;
        private List<AlarmInfo> AlaramInfos = new List<AlarmInfo>(); // �߰��� �˶� ������
        /// <summary>
        /// ���� �ݺ� ���� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WillRepeat_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var day in Week)
            {
                day.Enabled = WillRepeat.Checked;
            }
        }

        /// <summary>
        /// ���� ��ư Ŭ���� ���� ���� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DayButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button? clickedButton = sender as System.Windows.Forms.Button;

            if (clickedButton != null)
            {
                // ��ư�� ������ ��������� Ȯ��
                if (clickedButton.BackColor == Color.Yellow)
                {
                    // ��������� ����
                    clickedButton.BackColor = Color.Transparent;
                }
                else
                {
                    // ��������� ����
                    clickedButton.BackColor = Color.Yellow;
                }
            }
        }
        /// <summary>
        /// ������ �˶� ���� �˶� ��Ͽ� �߰�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AlarmInfo alarmInfo = new AlarmInfo();
            alarmInfo.Name = AlarmName.Text;
            alarmInfo.IsRepeat = WillRepeat.Checked;
            alarmInfo.Days = new List<string>();
            if (alarmInfo.IsRepeat)
            {
                for (int i = 0; i < Week.Count; i++)
                {
                    if (Week[i].BackColor == Color.Yellow)
                    {
                        alarmInfo.Days.Add(Week[i].Text);
                    }
                }
            }

            alarmInfo.DateTime = InputAlarmTime.Value;
            alarmInfo.DateTime = GetNextAlarmTime(alarmInfo);
            AlaramInfos.Add(alarmInfo);
            TimerListViewUpdate();
            AlarmTabControl.SelectedIndex = 0;
        }

        /// <summary>
        /// �˶�  ����Ʈ ������Ʈ
        /// </summary>
        private void TimerListViewUpdate()
        {

            AlaramInfos = AlaramInfos.OrderBy(alarm => GetNextAlarmTime(alarm)).ToList(); // ����
            AlarmListView.Items.Clear();
            for (int i = 0; i < AlaramInfos.Count; i++)
            {
                AlarmInfo alarmInfo = (AlarmInfo)AlaramInfos[i];
                if (alarmInfo.IsRepeat)
                {
                    AddAlarmRepeatDay(alarmInfo);
                }
                else
                {
                    AddAlarmNoRepeatDay(alarmInfo);
                }
            }
        }

        private static readonly Dictionary<string, DayOfWeek> DayOfWeekMapping = new()
        {
            { "��", DayOfWeek.Sunday },
            { "��", DayOfWeek.Monday },
            { "ȭ", DayOfWeek.Tuesday },
            { "��", DayOfWeek.Wednesday },
            { "��", DayOfWeek.Thursday },
            { "��", DayOfWeek.Friday },
            { "��", DayOfWeek.Saturday }
        };

        /// <summary>
        /// �˶� �ð� ���� �� ���� �︱�� ����
        /// </summary>
        /// <param name="alarm"></param>
        /// <returns></returns>
        private DateTime GetNextAlarmTime(AlarmInfo alarm)
        {
            DateTime now = DateTime.Now;
            DateTime nextTrigger = DateTime.Today.Add(alarm.DateTime.TimeOfDay);

            if (!alarm.IsRepeat || alarm.Days == null || alarm.Days.Count == 0)
            {
                // �ݺ��� ���� ��� ���� �˶� �ð��� �̹� �����ٸ� ���Ϸ� ����
                return nextTrigger > now ? nextTrigger : nextTrigger.AddDays(1);
            }

            // �ݺ� ������ �ִ� ��� ���� ����� ��¥ ���
            int minDays = int.MaxValue;
            foreach (var dayString in alarm.Days)
            {
                if (!DayOfWeekMapping.TryGetValue(dayString, out DayOfWeek day)) continue;

                // ���ú��� �ش� ���ϱ��� ���� �� �� ���
                int daysUntil = ((int)day - (int)now.DayOfWeek + 7) % 7;

                // �����̰�, �˶� �ð��� �̹� ���� ��� 7�� �ķ� ���
                DateTime candidateTrigger = DateTime.Today.AddDays(daysUntil).Add(alarm.DateTime.TimeOfDay);
                if (daysUntil == 0 && candidateTrigger <= now)
                {
                    daysUntil = 7;
                    candidateTrigger = DateTime.Today.AddDays(daysUntil).Add(alarm.DateTime.TimeOfDay);
                }

                // ���� ���� �ݺ� ���Ϸ� ������Ʈ
                if (daysUntil < minDays || (daysUntil == minDays && candidateTrigger < nextTrigger))
                {
                    minDays = daysUntil;
                    nextTrigger = candidateTrigger;
                }
            }

            return nextTrigger;
        }

        /// <summary>
        /// �˶� ���� �ݺ��� ���
        /// </summary>
        private void AddAlarmRepeatDay(AlarmInfo alarmInfo)
        {
            ListViewItem listViewItem = new ListViewItem(alarmInfo.Name);
            if (IsKorean) listViewItem.SubItems.Add(alarmInfo.DateTime.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")));
            else listViewItem.SubItems.Add(alarmInfo.DateTime.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("en-US")));
            string days = "";
            for (int i = 0; i < alarmInfo?.Days?.Count; i++)
            {
                if (i != alarmInfo.Days.Count - 1) days += alarmInfo.Days[i].ToString() + ", ";
                else days += alarmInfo.Days[i].ToString();
            }
            listViewItem.SubItems.Add(days);
            AlarmListView.Items.Add(listViewItem);
        }

        /// <summary>
        /// �˶� ���� �ݺ��� �ƴ� ���
        /// </summary>
        private void AddAlarmNoRepeatDay(AlarmInfo alarmInfo)
        {
            ListViewItem listViewItem = new ListViewItem(alarmInfo.Name);

            if (IsKorean) listViewItem.SubItems.Add(alarmInfo.DateTime.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")));
            else listViewItem.SubItems.Add(alarmInfo.DateTime.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("en-US")));

            string days = "-";
            listViewItem.SubItems.Add(days);
            AlarmListView.Items.Add(listViewItem);
        }

        /// <summary>
        /// �˶� �̸� ���� �̺�Ʈ (�ѱ���)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameMenuItem_Click(object? sender, EventArgs e)
        {
            if (AlarmListView.SelectedItems.Count > 0)
            {
                int index = AlarmListView.SelectedIndices.Count - 1;
                ListViewItem selectedItem = AlarmListView.SelectedItems[index];
                AlarmRenameForm alarmRename = new AlarmRenameForm(selectedItem.Text);
                if (IsKorean)
                {
                    // �ѱ��� ����
                    alarmRename.LanguageSettingKo();
                }
                else
                {
                    // ���� ����
                    alarmRename.LanguageSettingEn();
                }
                if (alarmRename.ShowDialog() == DialogResult.OK)
                {
                    // ��ȿ�� �̸��� �Է��ϰ� Ȯ���� ���� ���
                    string newName = alarmRename.NewName;
                    selectedItem.Text = newName;
                    AlaramInfos[index].Name = newName;
                }

            }
        }

        /// <summary>
        /// �˶� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMenuItem_Click(object? sender, EventArgs e)
        {
            if (AlarmListView.SelectedItems.Count > 0)
            {
                int index = AlarmListView.SelectedItems[0].Index;
                AlarmListView.Items.RemoveAt(index);
                AlaramInfos.RemoveAt(index);
            }
        }

        /// <summary>
        /// �˶� ����Ʈ ��Ŭ������ �˶� �̸� ���� Ȥ�� �˶� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlarmListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // ��Ŭ�� ����
            {
                var hitTest = AlarmListView.HitTest(e.Location);
                if (hitTest.Item != null) // �׸� �������� �۵�
                {
                    contextMenu.Show(AlarmListView, e.Location);
                }
            }
        }

        /// <summary>
        /// �˶��� ���� �̸� ����
        /// </summary>
        private class AlarmInfo
        {
            public DateTime DateTime { get; set; }
            public string? Name { get; set; }
            public bool IsRepeat { get; set; }
            public List<string>? Days { get; set; }

        }

        /// <summary>
        /// ���� �ð��� ���ϱ� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlarmTimer_Tick(object? sender, EventArgs e)
        {
            var currentTime = DateTime.Now;

            // ������ �˶� �ð��� ���� �ð��� ������ �˶� �︲
            var alarmToTrigger = AlaramInfos.FirstOrDefault(alarm => alarm.DateTime.Hour == currentTime.Hour
                                                                 && alarm.DateTime.Minute == currentTime.Minute
                                                                 && alarm.DateTime.Second == currentTime.Second);

            if (alarmToTrigger != null)
            {
                string Path = Application.StartupPath;
                TimeOver timeOver = new TimeOver();
                SoundPlayer player = new SoundPlayer($"{Path}data\\TimerSound.wav");
                player.PlayLooping();
                // �˶� �︮��
                if (timeOver.ShowDialog() == DialogResult.OK)
                {
                    player.Stop();
                }

                for (int i = AlaramInfos.Count - 1; i >= 0; i--)
                {
                    if (AlaramInfos[i].DateTime.Equals(alarmToTrigger.DateTime))
                    {
                        // �ݺ� �˶��� �ƴϸ� �˶� ����Ʈ���� ����
                        if (!alarmToTrigger.IsRepeat)
                        {
                            AlarmListView.Items.RemoveAt(i);
                            AlaramInfos.RemoveAt(i);
                        }
                    }
                }
            }
        }

        #endregion


        #region PIP, ��� ����
        /// <summary>
        /// PIP���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool click = false;
        private void PIPMode_Click(object sender, EventArgs e)
        {
            click = !click;
            if (click)
            {
                // pip ��� Ȱ��ȭ
                TopMost = true;
                PIPMode.BackColor = Color.Yellow;
            }
            else
            {
                // pip ��� ��Ȱ��ȭ
                TopMost = false;
                PIPMode.BackColor = Color.Transparent;
            }
        }
        #endregion

        private void �ѱ���ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region �⺻ ȭ�� ���� ����
            IsKorean = true;
            Text = StringLib_ko.Clock;
            Timer.Text = StringLib_ko.Timer;
            StopWatch.Text = StringLib_ko.StopWatch;
            Alarm.Text = StringLib_ko.Alarm;
            #endregion

            #region Ÿ�̸� ���� ����
            settingTimerTimeForm.LanguageSettingKo();
            StartTimerButton.Text = StringLib_ko.Start;
            ResetButton.Text = StringLib_ko.Reset;
            #endregion

            #region �����ġ ���� ����
            StartStopWatchButton.Text = StringLib_ko.Start;
            CheckButton.Text = StringLib_ko.Record;
            StopWatchReset.Text = StringLib_ko.Reset;
            StopWatchListview.Columns[0].Text = StringLib_ko.Order;
            StopWatchListview.Columns[1].Text = StringLib_ko.Time;
            StopWatchListview.Columns[2].Text = StringLib_ko.TimeDifference;
            #endregion

            #region �˶� ���� ����
            contextMenu = new ContextMenuStrip();
            var renameMenuItem = new ToolStripMenuItem(StringLib_ko.Rename);
            renameMenuItem.Click += RenameMenuItem_Click;
            contextMenu.Items.Add(renameMenuItem);

            var deleteMenuItem = new ToolStripMenuItem(StringLib_ko.Delete);
            deleteMenuItem.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteMenuItem);

            AlarmListView.Columns[0].Text = StringLib_ko.AlarmName;
            AlarmListView.Columns[1].Text = StringLib_ko.Time;
            AlarmListView.Columns[2].Text = StringLib_ko.RepeatDays;

            AlarmTabControl.TabPages[0].Text = StringLib_ko.AlarmList;
            AlarmTabControl.TabPages[1].Text = StringLib_ko.AddAlarm;

            AlarmNameText.Text = StringLib_ko.AlarmName;
            AlarmName.Text = StringLib_ko.Alarm;
            AddBtn.Text = StringLib_ko.Confirm;
            WillRepeat.Text = StringLib_ko.DayRepeat;

            MonBtn.Text = StringLib_ko.Mon;
            TueBtn.Text = StringLib_ko.Tue;
            WedBtn.Text = StringLib_ko.Wed;
            ThuBtn.Text = StringLib_ko.Thu;
            FriBtn.Text = StringLib_ko.Fri;
            SatBtn.Text = StringLib_ko.Sat;
            SunBtn.Text = StringLib_ko.Sun;

            #endregion
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region �⺻ ȭ�� ���� ����
            IsKorean = false;
            Text = StringLib_en.Clock;
            Timer.Text = StringLib_en.Timer;
            StopWatch.Text = StringLib_en.StopWatch;
            Alarm.Text = StringLib_en.Alarm;
            #endregion

            #region Ÿ�̸� ���� ����
            settingTimerTimeForm.LanguageSettingEn();
            StartTimerButton.Text = StringLib_en.Start;
            ResetButton.Text = StringLib_en.Reset;
            #endregion

            #region �����ġ ���� ����
            StartStopWatchButton.Text = StringLib_en.Start;
            CheckButton.Text = StringLib_en.Record;
            StopWatchReset.Text = StringLib_en.Reset;
            StopWatchListview.Columns[0].Text = StringLib_en.Order;
            StopWatchListview.Columns[1].Text = StringLib_en.Time;
            StopWatchListview.Columns[2].Text = StringLib_en.TimeDifference;
            #endregion

            #region �˶� ���� ����
            contextMenu = new ContextMenuStrip();
            var renameMenuItem = new ToolStripMenuItem(StringLib_en.Rename);
            renameMenuItem.Click += RenameMenuItem_Click;
            contextMenu.Items.Add(renameMenuItem);

            var deleteMenuItem = new ToolStripMenuItem(StringLib_en.Delete);
            deleteMenuItem.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteMenuItem);

            AlarmListView.Columns[0].Text = StringLib_en.AlarmName;
            AlarmListView.Columns[1].Text = StringLib_en.Time;
            AlarmListView.Columns[2].Text = StringLib_en.RepeatDays;

            AlarmTabControl.TabPages[0].Text = StringLib_en.AlarmList;
            AlarmTabControl.TabPages[1].Text = StringLib_en.AddAlarm;

            AlarmNameText.Text = StringLib_en.AlarmName;
            AlarmName.Text = StringLib_en.Alarm;
            AddBtn.Text = StringLib_en.Confirm;
            WillRepeat.Text = StringLib_en.DayRepeat;

            MonBtn.Text = StringLib_en.Mon;
            TueBtn.Text = StringLib_en.Tue;
            WedBtn.Text = StringLib_en.Wed;
            ThuBtn.Text = StringLib_en.Thu;
            FriBtn.Text = StringLib_en.Fri;
            SatBtn.Text = StringLib_en.Sat;
            SunBtn.Text = StringLib_en.Sun;

            #endregion
        }

        /// <summary>
        /// ���� ���� �� ���� ������ ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �ð�_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.TimerTime = ShowTimerTime.Text;
            Properties.Settings.Default.StopWatchTimerTime = ShowStopWatchTime.Text;
            Properties.Settings.Default.StopWatchTimes = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.StopWatchTimeDiffs = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.AlaramTimes = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.AlaramNames = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.AlarmRepeatDays = new System.Collections.Specialized.StringCollection();
            for (int i = 0; i < StopWatchListview.Items.Count; i++)
            {
                Properties.Settings.Default.StopWatchTimes.Add(StopWatchListview.Items[i].SubItems[1].Text);
                Properties.Settings.Default.StopWatchTimeDiffs.Add(StopWatchListview.Items[i].SubItems[2].Text);
            }

            for (int i = 0; i < AlaramInfos.Count; i++)
            {
                Properties.Settings.Default.AlaramNames.Add(AlaramInfos[i].Name);
                Properties.Settings.Default.AlaramTimes.Add(AlaramInfos[i].DateTime.ToString());
                Properties.Settings.Default.AlarmRepeatDays.Add(AlarmListView.Items[i].SubItems[2].Text);
            }


            Properties.Settings.Default.Save();

        }
    }
}