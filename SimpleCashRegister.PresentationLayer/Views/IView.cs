﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Views
{
    interface IView<T>
    {
        string Display(T item);
    }
}
