using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch
{
    public partial class SettingTimerTimeForm : Form
    {
        internal string SettingTime { get; set; }
        public SettingTimerTimeForm()
        {
            InitializeComponent();
            SettingTime = "00:00:00";
            SettingInputTimePicker();
        }

        /// <summary>
        /// datetimepicker 초기 설정
        /// </summary>
        private void SettingInputTimePicker()
        {
            InputTimePicker.Format = DateTimePickerFormat.Custom;
            InputTimePicker.CustomFormat = "HH:mm:ss";
            InputTimePicker.Text = "00:00:00";
            // 시간 표시를 원하면 ShowUpDown 속성을 true로 설정하면
            // 날짜 피커 대신 시간 선택 버튼이 나타납니다.
            InputTimePicker.ShowUpDown = true;
        }

        /// <summary>
        /// 확인 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SettingTime = InputTimePicker.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 취소 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            SettingTime = InputTimePicker.Text;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 한국어 버전
        /// </summary>
        /// <param name="IsKorean"></param>
        internal void LanguageSettingKo()
        {
            Text = StringLib_ko.SetTimerDuration;
            ApplyButton.Text = StringLib_ko.Confirm;
            CancelButton.Text = StringLib_ko.Cancel;
        }

        /// <summary>
        /// 영어 버전
        /// </summary>
        /// <param name="IsKorean"></param>
        internal void LanguageSettingEn()
        {
            Text = StringLib_en.SetTimerDuration;
            ApplyButton.Text = StringLib_en.Confirm;
            CancelButton.Text = StringLib_en.Cancel;
        }
    }
}
