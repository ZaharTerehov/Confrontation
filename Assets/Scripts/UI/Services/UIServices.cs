
using System.Collections.Generic;
using UI.Interfaces;
using System;

namespace UI.Services
{
    public class UIServices : IUIWindowsManagerService
    {
        public void FillDictionary<T>(Dictionary<Type, T> dictionary, List<T> list)
        {
            foreach (var element in list)
            {
                dictionary.Add(element.GetType(), element);
            }
        }
        
        public Window CloseCurrent(Window currentWindow)
        {
            if (currentWindow != null)
            {
                currentWindow.Hide();
                return currentWindow;
            }

            return null;
        }

        public Window Open<T>(Dictionary<Type, Window> dictionary)
        {
            var window = dictionary[typeof(T)];
            window.Show();

            return window;
        }
    }
}