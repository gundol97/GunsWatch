namespace Watch
{
    partial class TimeOver
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
            OKButton = new Button();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            OKButton.Location = new Point(-1, -1);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(187, 65);
            OKButton.TabIndex = 0;
            OKButton.Text = "확인";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // TimeOver
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 61);
            ControlBox = false;
            Controls.Add(OKButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TimeOver";
            ShowIcon = false;
            Text = "TimeOver";
            ResumeLayout(false);
        }

        #endregion

        private Button OKButton;
    }
}