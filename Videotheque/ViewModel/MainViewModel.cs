using System;
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
        public Film Film { get { return GetValue<Film>(); } set { SetValue<Film>(value); } }

        public Ami Ami { get { return GetValue<Ami>(); } set { SetValue<Ami>(value); } }


    }
}
