namespace Watch
{
    partial class SettingTimerTimeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ApplyButton = new Button();
            CancelButton = new Button();
            InputTimePicker = new DateTimePicker();
            SuspendLayout();
            // 
            // ApplyButton
            // 
            ApplyButton.Location = new Point(63, 88);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(96, 39);
            ApplyButton.TabIndex = 1;
            ApplyButton.Text = "확인";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(175, 88);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(96, 39);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "취소";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // InputTimePicker
            // 
            InputTimePicker.CalendarFont = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InputTimePicker.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InputTimePicker.Location = new Point(63, 31);
            InputTimePicker.Name = "InputTimePicker";
            InputTimePicker.Size = new Size(208, 29);
            InputTimePicker.TabIndex = 3;
            // 
            // SettingTimerTimeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 181);
            ControlBox = false;
            Controls.Add(InputTimePicker);
            Controls.Add(CancelButton);
            Controls.Add(ApplyButton);
            Name = "SettingTimerTimeForm";
            ShowIcon = false;
            Text = "타이머 시간 설정";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button ApplyButton;
        private Button CancelButton;
        private DateTimePicker InputTimePicker;
    }
}