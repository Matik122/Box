using System;
using Windows;

namespace Services
{
    public class WindowResolver
    {
        public PlayConfirmWindow.Model GetPlayConfirmWindowModel(Action onPlayClick,WindowsService windowsService)
        {
            return new(onPlayClick, windowsService);
        }
    }
}