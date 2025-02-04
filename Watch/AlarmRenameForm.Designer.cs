namespace Watch
{
    partial class AlarmRenameForm
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
            InputNewNameLabel = new Label();
            NewNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // ApplyButton
            // 
            ApplyButton.Location = new Point(244, 31);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(96, 44);
            ApplyButton.TabIndex = 2;
            ApplyButton.Text = "확인";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(244, 91);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(96, 44);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "취소";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // InputNewNameLabel
            // 
            InputNewNameLabel.AutoSize = true;
            InputNewNameLabel.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            InputNewNameLabel.Location = new Point(12, 112);
            InputNewNameLabel.Name = "InputNewNameLabel";
            InputNewNameLabel.Size = new Size(157, 20);
            InputNewNameLabel.TabIndex = 4;
            InputNewNameLabel.Text = "새 이름을 입력하세요:";
            // 
            // NewNameTextBox
            // 
            NewNameTextBox.Location = new Point(12, 144);
            NewNameTextBox.Name = "NewNameTextBox";
            NewNameTextBox.Size = new Size(328, 25);
            NewNameTextBox.TabIndex = 5;
            // 
            // AlarmRenameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 197);
            ControlBox = false;
            Controls.Add(NewNameTextBox);
            Controls.Add(InputNewNameLabel);
            Controls.Add(CancelButton);
            Controls.Add(ApplyButton);
            Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlarmRenameForm";
            ShowIcon = false;
            Text = "이름 변경";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ApplyButton;
        private Button CancelButton;
        private Label InputNewNameLabel;
        private TextBox NewNameTextBox;
    }
}