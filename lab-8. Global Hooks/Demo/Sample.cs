﻿// This code is distributed under MIT license. 
// Copyright (c) 2015 George Mamaladze
// See license.txt or http://opensource.org/licenses/mit-license.php

using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Demo
{
    internal class Sample
    {
        private IKeyboardMouseEvents _mGlobalHook;

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            _mGlobalHook = Hook.GlobalEvents();

            _mGlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            _mGlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {   
            Console.WriteLine(@"KeyPress: 	{0}", e.KeyChar);
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            Console.WriteLine(@"MouseDown: 	{0}; 	 System Timestamp: 	{1}", e.Button, e.Timestamp);

            // uncommenting the following line will suppress the middle mouse button click
            if (e.Button == MouseButtons.Middle) { e.Handled = true; }
        }

        public void Unsubscribe()
        {
            _mGlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            _mGlobalHook.KeyPress -= GlobalHookKeyPress;

            //It is recommened to dispose it
            _mGlobalHook.Dispose();
        }
    }
}