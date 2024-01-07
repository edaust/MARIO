using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.GameFolders.Scripts
{
    public static class Events
    {
        public static UnityEvent<int> onCollected = new();

    }
}
//