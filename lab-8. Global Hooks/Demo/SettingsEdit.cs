using System;
using System.Windows.Forms;

namespace Demo
{
    public partial class SettingsEdit : Form
    {
        private string _emailFrom;

        private string _emailTo;

        private string _password;

        private string _fileSize;

        private bool _isHiddenMode;

        public string EmailFrom
        {
            get => _emailFrom;
            set => _emailFrom = value;
        }

        public string EmailTo
        {
            get => _emailTo;
            set => _emailTo = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string FileSize
        {
            get => _fileSize;
            set => _fileSize = value;
        }

        public bool IsHiddenMode
        {
            get => _isHiddenMode;
            set => _isHiddenMode = value;
        }

        public SettingsEdit()
        {
            InitializeComponent();
            isHiddenModeCheckBox.Checked = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            EmailFrom = emailFromTextBox.Text;
            Password = passwordTextBox.Text;
            EmailTo = emailToTextBox.Text;
            IsHiddenMode = isHiddenModeCheckBox.Checked;
            FileSize = fileSizeTextBox.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {}
    }
}
