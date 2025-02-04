using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch
{
    public partial class AlarmRenameForm : Form
    {
        public string NewName { get; private set; }
        string CheckName = "";

        public AlarmRenameForm(string NowName)
        {
            InitializeComponent();
            NewNameTextBox.Text = NowName;
        }

        /// <summary>
        /// 한국어로 설정
        /// </summary>
        internal void LanguageSettingKo()
        {
            Text = StringLib_ko.Rename;
            InputNewNameLabel.Text = StringLib_ko.EnterANewName;
            ApplyButton.Text = StringLib_ko.Confirm;
            CancelButton.Text = StringLib_ko.Cancel;
            CheckName = StringLib_ko.CheckName;
        }

        /// <summary>
        /// 영어로 설정
        /// </summary>
        internal void LanguageSettingEn()
        {
            Text = StringLib_en.Rename;
            InputNewNameLabel.Text = StringLib_en.EnterANewName;
            ApplyButton.Text = StringLib_en.Confirm;
            CancelButton.Text = StringLib_en.Cancel;
            CheckName = StringLib_en.CheckName;
        }

        /// <summary>
        /// 확인 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            // 새 이름 설정 시 유효한 문자열인지 검사
            if (NewNameTextBox.Text != null && NewNameTextBox.Text != string.Empty)
            {
                NewName = NewNameTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(CheckName);
            }
        }

        /// <summary>
        /// 취소 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
