﻿using System.Threading.Tasks;

namespace Askaiser.UITesting.Commands
{
    internal class TypeTextCommandHandler
    {
        private readonly IKeyboardController _keyboardController;

        public TypeTextCommandHandler(IKeyboardController keyboardController)
        {
            this._keyboardController = keyboardController;
        }

        public async Task Execute(KeyboardTextCommand command)
        {
            await this._keyboardController.TypeText(command.Text).ConfigureAwait(false);
        }
    }
}