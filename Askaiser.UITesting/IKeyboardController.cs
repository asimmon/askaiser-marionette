﻿using System.Threading.Tasks;

namespace Askaiser.UITesting
{
    internal interface IKeyboardController
    {
        Task TypeText(string text);

        Task KeyPress(params VirtualKeyCode[] keyCodes);

        Task KeyDown(params VirtualKeyCode[] keyCodes);

        Task KeyUp(params VirtualKeyCode[] keyCodes);
    }
}