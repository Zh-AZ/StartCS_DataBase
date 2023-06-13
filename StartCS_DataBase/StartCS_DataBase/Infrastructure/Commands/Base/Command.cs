﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StartCS_DataBase.Infrastructure.Commands.Base
{
    internal abstract class Command
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
