namespace Watch
{
    partial class 시계
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StopWatch = new Button();
            Alarm = new Button();
            Timer = new Button();
            splitContainer1 = new SplitContainer();
            AlarmTabControl = new TabControl();
            tabPage1 = new TabPage();
            AlarmListView = new ListView();
            tabPage2 = new TabPage();
            panel3 = new Panel();
            AlarmName = new TextBox();
            AlarmNameText = new Label();
            AddBtn = new Button();
            SunBtn = new Button();
            SatBtn = new Button();
            FriBtn = new Button();
            ThuBtn = new Button();
            WedBtn = new Button();
            TueBtn = new Button();
            MonBtn = new Button();
            WillRepeat = new CheckBox();
            InputAlarmTime = new DateTimePicker();
            NowTimeLabel = new Label();
            StopWatchReset = new Button();
            ShowStopWatchTime = new Label();
            CheckButton = new Button();
            StartStopWatchButton = new Button();
            panel2 = new Panel();
            StopWatchListview = new ListView();
            순서 = new ColumnHeader();
            시간 = new ColumnHeader();
            시간차이 = new ColumnHeader();
            PIPMode = new Button();
            ResetButton = new Button();
            StartTimerButton = new Button();
            ShowTimerTime = new Label();
            menuStrip1 = new MenuStrip();
            한국어ToolStripMenuItem = new ToolStripMenuItem();
            한국어ToolStripMenuItem1 = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            AlarmTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // StopWatch
            // 
            StopWatch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StopWatch.Location = new Point(116, -1);
            StopWatch.Name = "StopWatch";
            StopWatch.Size = new Size(117, 51);
            StopWatch.TabIndex = 1;
            StopWatch.Text = "스톱워치";
            StopWatch.UseVisualStyleBackColor = true;
            StopWatch.Click += StopWatch_Click;
            // 
            // Alarm
            // 
            Alarm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Alarm.Location = new Point(232, -1);
            Alarm.Name = "Alarm";
            Alarm.Size = new Size(117, 51);
            Alarm.TabIndex = 2;
            Alarm.Text = "알람";
            Alarm.UseVisualStyleBackColor = true;
            Alarm.Click += Alarm_Click;
            // 
            // Timer
            // 
            Timer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Timer.Location = new Point(0, -1);
            Timer.Name = "Timer";
            Timer.Size = new Size(117, 51);
            Timer.TabIndex = 3;
            Timer.Text = "타이머";
            Timer.UseVisualStyleBackColor = true;
            Timer.Click += Timer_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(AlarmTabControl);
            splitContainer1.Panel1.Controls.Add(NowTimeLabel);
            splitContainer1.Panel1.Controls.Add(StopWatchReset);
            splitContainer1.Panel1.Controls.Add(ShowStopWatchTime);
            splitContainer1.Panel1.Controls.Add(CheckButton);
            splitContainer1.Panel1.Controls.Add(StartStopWatchButton);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(PIPMode);
            splitContainer1.Panel1.Controls.Add(ResetButton);
            splitContainer1.Panel1.Controls.Add(StartTimerButton);
            splitContainer1.Panel1.Controls.Add(ShowTimerTime);
            splitContainer1.Panel1.Controls.Add(menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(350, 452);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 4;
            // 
            // AlarmTabControl
            // 
            AlarmTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AlarmTabControl.Controls.Add(tabPage1);
            AlarmTabControl.Controls.Add(tabPage2);
            AlarmTabControl.Location = new Point(0, 26);
            AlarmTabControl.Name = "AlarmTabControl";
            AlarmTabControl.SelectedIndex = 0;
            AlarmTabControl.Size = new Size(347, 370);
            AlarmTabControl.TabIndex = 12;
            AlarmTabControl.Visible = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(AlarmListView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(339, 342);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "알람 목록";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // AlarmListView
            // 
            AlarmListView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AlarmListView.Location = new Point(3, 3);
            AlarmListView.Name = "AlarmListView";
            AlarmListView.Size = new Size(333, 336);
            AlarmListView.TabIndex = 0;
            AlarmListView.UseCompatibleStateImageBehavior = false;
            AlarmListView.View = View.Details;
            AlarmListView.MouseDown += AlarmListView_MouseDown;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(339, 342);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "알람 추가";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(AlarmName);
            panel3.Controls.Add(AlarmNameText);
            panel3.Controls.Add(AddBtn);
            panel3.Controls.Add(SunBtn);
            panel3.Controls.Add(SatBtn);
            panel3.Controls.Add(FriBtn);
            panel3.Controls.Add(ThuBtn);
            panel3.Controls.Add(WedBtn);
            panel3.Controls.Add(TueBtn);
            panel3.Controls.Add(MonBtn);
            panel3.Controls.Add(WillRepeat);
            panel3.Controls.Add(InputAlarmTime);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 336);
            panel3.TabIndex = 0;
            // 
            // AlarmName
            // 
            AlarmName.Location = new Point(12, 204);
            AlarmName.Name = "AlarmName";
            AlarmName.Size = new Size(309, 23);
            AlarmName.TabIndex = 16;
            AlarmName.Text = "알람";
            // 
            // AlarmNameText
            // 
            AlarmNameText.AutoSize = true;
            AlarmNameText.Location = new Point(12, 186);
            AlarmNameText.Name = "AlarmNameText";
            AlarmNameText.Size = new Size(59, 15);
            AlarmNameText.TabIndex = 15;
            AlarmNameText.Text = "알람 이름";
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(106, 259);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(119, 63);
            AddBtn.TabIndex = 13;
            AddBtn.Text = "확인";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // SunBtn
            // 
            SunBtn.Enabled = false;
            SunBtn.Location = new Point(276, 136);
            SunBtn.Name = "SunBtn";
            SunBtn.Size = new Size(45, 35);
            SunBtn.TabIndex = 12;
            SunBtn.Text = "일";
            SunBtn.UseVisualStyleBackColor = true;
            SunBtn.Click += DayButton_Click;
            // 
            // SatBtn
            // 
            SatBtn.Enabled = false;
            SatBtn.Location = new Point(232, 136);
            SatBtn.Name = "SatBtn";
            SatBtn.Size = new Size(45, 35);
            SatBtn.TabIndex = 11;
            SatBtn.Text = "토";
            SatBtn.UseVisualStyleBackColor = true;
            SatBtn.Click += DayButton_Click;
            // 
            // FriBtn
            // 
            FriBtn.Enabled = false;
            FriBtn.Location = new Point(188, 136);
            FriBtn.Name = "FriBtn";
            FriBtn.Size = new Size(45, 35);
            FriBtn.TabIndex = 10;
            FriBtn.Text = "금";
            FriBtn.UseVisualStyleBackColor = true;
            FriBtn.Click += DayButton_Click;
            // 
            // ThuBtn
            // 
            ThuBtn.Enabled = false;
            ThuBtn.Location = new Point(144, 136);
            ThuBtn.Name = "ThuBtn";
            ThuBtn.Size = new Size(45, 35);
            ThuBtn.TabIndex = 9;
            ThuBtn.Text = "목";
            ThuBtn.UseVisualStyleBackColor = true;
            ThuBtn.Click += DayButton_Click;
            // 
            // WedBtn
            // 
            WedBtn.Enabled = false;
            WedBtn.Location = new Point(100, 136);
            WedBtn.Name = "WedBtn";
            WedBtn.Size = new Size(45, 35);
            WedBtn.TabIndex = 8;
            WedBtn.Text = "수";
            WedBtn.UseVisualStyleBackColor = true;
            WedBtn.Click += DayButton_Click;
            // 
            // TueBtn
            // 
            TueBtn.Enabled = false;
            TueBtn.Location = new Point(56, 136);
            TueBtn.Name = "TueBtn";
            TueBtn.Size = new Size(45, 35);
            TueBtn.TabIndex = 7;
            TueBtn.Text = "화";
            TueBtn.UseVisualStyleBackColor = true;
            TueBtn.Click += DayButton_Click;
            // 
            // MonBtn
            // 
            MonBtn.Enabled = false;
            MonBtn.Location = new Point(12, 136);
            MonBtn.Name = "MonBtn";
            MonBtn.Size = new Size(45, 35);
            MonBtn.TabIndex = 6;
            MonBtn.Text = "월";
            MonBtn.UseVisualStyleBackColor = true;
            MonBtn.Click += DayButton_Click;
            // 
            // WillRepeat
            // 
            WillRepeat.AutoSize = true;
            WillRepeat.Location = new Point(12, 111);
            WillRepeat.Name = "WillRepeat";
            WillRepeat.Size = new Size(78, 19);
            WillRepeat.TabIndex = 5;
            WillRepeat.Text = "요일 반복";
            WillRepeat.UseVisualStyleBackColor = true;
            WillRepeat.CheckedChanged += WillRepeat_CheckedChanged;
            // 
            // InputAlarmTime
            // 
            InputAlarmTime.CalendarFont = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InputAlarmTime.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InputAlarmTime.Location = new Point(64, 49);
            InputAlarmTime.Name = "InputAlarmTime";
            InputAlarmTime.Size = new Size(208, 29);
            InputAlarmTime.TabIndex = 4;
            // 
            // NowTimeLabel
            // 
            NowTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NowTimeLabel.AutoSize = true;
            NowTimeLabel.Font = new Font("맑은 고딕", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            NowTimeLabel.Location = new Point(114, 83);
            NowTimeLabel.Name = "NowTimeLabel";
            NowTimeLabel.Size = new Size(119, 37);
            NowTimeLabel.TabIndex = 10;
            NowTimeLabel.Text = "00:00:00";
            // 
            // StopWatchReset
            // 
            StopWatchReset.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StopWatchReset.Location = new Point(213, 138);
            StopWatchReset.Name = "StopWatchReset";
            StopWatchReset.Size = new Size(69, 33);
            StopWatchReset.TabIndex = 9;
            StopWatchReset.Text = "초기화";
            StopWatchReset.UseVisualStyleBackColor = true;
            StopWatchReset.Visible = false;
            StopWatchReset.Click += StopWatchReset_Click;
            // 
            // ShowStopWatchTime
            // 
            ShowStopWatchTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ShowStopWatchTime.AutoSize = true;
            ShowStopWatchTime.Font = new Font("맑은 고딕", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ShowStopWatchTime.Location = new Point(114, 83);
            ShowStopWatchTime.Name = "ShowStopWatchTime";
            ShowStopWatchTime.Size = new Size(155, 37);
            ShowStopWatchTime.TabIndex = 8;
            ShowStopWatchTime.Text = "00:00:00.00";
            ShowStopWatchTime.Visible = false;
            // 
            // CheckButton
            // 
            CheckButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CheckButton.Location = new Point(138, 138);
            CheckButton.Name = "CheckButton";
            CheckButton.Size = new Size(69, 33);
            CheckButton.TabIndex = 7;
            CheckButton.Text = "기록";
            CheckButton.UseVisualStyleBackColor = true;
            CheckButton.Visible = false;
            CheckButton.Click += CheckButton_Click;
            // 
            // StartStopWatchButton
            // 
            StartStopWatchButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StartStopWatchButton.Location = new Point(63, 138);
            StartStopWatchButton.Name = "StartStopWatchButton";
            StartStopWatchButton.Size = new Size(69, 33);
            StartStopWatchButton.TabIndex = 6;
            StartStopWatchButton.Text = "시작";
            StartStopWatchButton.UseVisualStyleBackColor = true;
            StartStopWatchButton.Visible = false;
            StartStopWatchButton.Click += StartStopWatchButton_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(StopWatchListview);
            panel2.Location = new Point(0, 189);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 208);
            panel2.TabIndex = 4;
            // 
            // StopWatchListview
            // 
            StopWatchListview.Columns.AddRange(new ColumnHeader[] { 순서, 시간, 시간차이 });
            StopWatchListview.Dock = DockStyle.Fill;
            StopWatchListview.Location = new Point(0, 0);
            StopWatchListview.Name = "StopWatchListview";
            StopWatchListview.Size = new Size(350, 208);
            StopWatchListview.TabIndex = 0;
            StopWatchListview.UseCompatibleStateImageBehavior = false;
            StopWatchListview.View = View.Details;
            StopWatchListview.Visible = false;
            // 
            // 순서
            // 
            순서.Text = "순서";
            순서.Width = 100;
            // 
            // 시간
            // 
            시간.Text = "시간";
            시간.Width = 125;
            // 
            // 시간차이
            // 
            시간차이.Text = "시간 차이";
            시간차이.Width = 125;
            // 
            // PIPMode
            // 
            PIPMode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PIPMode.Location = new Point(295, 0);
            PIPMode.Name = "PIPMode";
            PIPMode.Size = new Size(55, 24);
            PIPMode.TabIndex = 3;
            PIPMode.Text = "pip";
            PIPMode.UseVisualStyleBackColor = true;
            PIPMode.Click += PIPMode_Click;
            // 
            // ResetButton
            // 
            ResetButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ResetButton.Location = new Point(191, 138);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(69, 33);
            ResetButton.TabIndex = 2;
            ResetButton.Text = "되돌리기";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Visible = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // StartTimerButton
            // 
            StartTimerButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StartTimerButton.Enabled = false;
            StartTimerButton.Location = new Point(84, 138);
            StartTimerButton.Name = "StartTimerButton";
            StartTimerButton.Size = new Size(69, 33);
            StartTimerButton.TabIndex = 1;
            StartTimerButton.Text = "시작";
            StartTimerButton.UseVisualStyleBackColor = true;
            StartTimerButton.Visible = false;
            StartTimerButton.Click += StartTimerButton_Click;
            // 
            // ShowTimerTime
            // 
            ShowTimerTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ShowTimerTime.AutoSize = true;
            ShowTimerTime.Font = new Font("맑은 고딕", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ShowTimerTime.Location = new Point(116, 83);
            ShowTimerTime.Name = "ShowTimerTime";
            ShowTimerTime.Size = new Size(119, 37);
            ShowTimerTime.TabIndex = 0;
            ShowTimerTime.Text = "00:00:00";
            ShowTimerTime.Visible = false;
            ShowTimerTime.Click += ShowTimerTime_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { 한국어ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(79, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // 한국어ToolStripMenuItem
            // 
            한국어ToolStripMenuItem.Checked = true;
            한국어ToolStripMenuItem.CheckState = CheckState.Checked;
            한국어ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 한국어ToolStripMenuItem1, englishToolStripMenuItem });
            한국어ToolStripMenuItem.Name = "한국어ToolStripMenuItem";
            한국어ToolStripMenuItem.Size = new Size(71, 20);
            한국어ToolStripMenuItem.Text = "Language";
            // 
            // 한국어ToolStripMenuItem1
            // 
            한국어ToolStripMenuItem1.Name = "한국어ToolStripMenuItem1";
            한국어ToolStripMenuItem1.Size = new Size(180, 22);
            한국어ToolStripMenuItem1.Text = "한국어";
            한국어ToolStripMenuItem1.Click += 한국어ToolStripMenuItem1_Click;
            // 
            // englishToolStripMenuItem
            // 
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Size = new Size(180, 22);
            englishToolStripMenuItem.Text = "english";
            englishToolStripMenuItem.Click += englishToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(Timer);
            panel1.Controls.Add(StopWatch);
            panel1.Controls.Add(Alarm);
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 51);
            panel1.TabIndex = 4;
            // 
            // 시계
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 452);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "시계";
            ShowIcon = false;
            Text = "시계";
            FormClosing += 시계_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            AlarmTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button StopWatch;
        private Button Alarm;
        private Button Timer;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Label ShowTimerTime;
        private Button ResetButton;
        private Button StartTimerButton;
        private Button PIPMode;
        private Panel panel2;
        private ListView StopWatchListview;
        private Button CheckButton;
        private Button StartStopWatchButton;
        private Label ShowStopWatchTime;
        private Button StopWatchReset;
        private ColumnHeader 순서;
        private ColumnHeader 시간;
        private ColumnHeader 시간차이;
        private Label NowTimeLabel;
        private TabControl AlarmTabControl;
        private TabPage tabPage1;
        private ListView AlarmListView;
        private TabPage tabPage2;
        private Panel panel3;
        private DateTimePicker InputAlarmTime;
        private CheckBox WillRepeat;
        private Button SunBtn;
        private Button SatBtn;
        private Button FriBtn;
        private Button ThuBtn;
        private Button WedBtn;
        private Button TueBtn;
        private Button MonBtn;
        private Button AddBtn;
        private Label AlarmNameText;
        private TextBox AlarmName;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 한국어ToolStripMenuItem;
        private ToolStripMenuItem 한국어ToolStripMenuItem1;
        private ToolStripMenuItem englishToolStripMenuItem;
    }
}