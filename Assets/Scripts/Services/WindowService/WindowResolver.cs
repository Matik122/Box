using System;
using Windows;

namespace Services
{
    public class WindowResolver
    {
        private readonly WindowsService _windowsService;
        
        public WindowResolver(WindowsService windowsService)
        {
            _windowsService = windowsService;
        }
        
        public PlayConfirmWindow.Model GetPlayConfirmWindowModel(Action onPlayClick)
        {
            return new(onPlayClick, _windowsService);
        }
    }
}