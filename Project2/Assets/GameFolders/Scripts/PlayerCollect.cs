using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameFolders.Scripts
{
    internal class PlayerCollect : MonoBehaviour
    {
        public int LevelCollectRequirement = 0;

        int totalCollectCount = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Collectable"))
            {
                totalCollectCount++;
                Events.onCollected?.Invoke(totalCollectCount);

                Destroy(collision.gameObject);

                if (totalCollectCount == LevelCollectRequirement)
                    Events.onSuccess?.Invoke();
            }
        }
    }
}
//