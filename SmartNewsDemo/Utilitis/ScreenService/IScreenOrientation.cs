using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNewsDemo.Utilitis
{
    public interface IScreenOrientation
    {
        void SetLandscape();

        void SetPortrait();

        void UnlockScreenOrientation();

        bool IsLandCape();

        bool IsPortrait();

        bool IsUnlocked();
    }
}
