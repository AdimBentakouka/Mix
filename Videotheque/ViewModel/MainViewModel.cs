﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.Model;

namespace Videotheque.ViewModel
{
    class MainViewModel : AbstractModel
    {
        public Page Source { get { return GetValue<Page>(); } set { SetValue<Page>(value); } }

  
    }
}