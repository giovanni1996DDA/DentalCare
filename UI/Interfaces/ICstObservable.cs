﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Interfaces
{
    public interface ICstObservable
    {
        void Suscribe(IcstObserver obj);
    }
}
