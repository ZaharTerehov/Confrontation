
using System.Collections.Generic;
using System;
using UI.Services;

namespace UI.Interfaces
{
    public interface IUIService
    {
        public void FillDictionary<T>(Dictionary<Type, T> dictionary, List<T> list);

        public Window CloseCurrent(Window currentWindow);

        public Window Open<T>(Dictionary<Type, Window> dictionary);
    }
}