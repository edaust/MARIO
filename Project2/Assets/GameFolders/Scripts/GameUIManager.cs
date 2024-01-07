using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.GameFolders.Scripts
{
    internal class GameUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text txtDiamond;

        private void OnEnable()
        {
            Events.onCollected.AddListener(UpdateDiamondUI);
        }

        private void OnDisable()
        {
            Events.onCollected.RemoveListener(UpdateDiamondUI);
        }

        private void UpdateDiamondUI(int total)
        {
            txtDiamond.text = total.ToString();
        }
    }
}
