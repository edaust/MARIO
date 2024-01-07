using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.GameFolders.Scripts
{
    internal class GameUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text txtDiamond;
        [SerializeField] private GameObject successPanel;
        [SerializeField] private GameObject failPanel;


        private void OnEnable()
        {
            Events.onCollected.AddListener(UpdateDiamondUI);
            Events.onSuccess.AddListener(OpenSuccessPanel);
            Events.onFail.AddListener(OpenFailPanel);
        }

        private void OnDisable()
        {
            Events.onCollected.RemoveListener(UpdateDiamondUI);
            Events.onSuccess.RemoveListener(OpenSuccessPanel);
            Events.onFail.RemoveListener(OpenFailPanel);
        }

        private void UpdateDiamondUI(int total)
        {
            txtDiamond.text = total.ToString();
        }


        private void OpenFailPanel()
        {
            failPanel.SetActive(true);
        }

        private void OpenSuccessPanel()
        {
            successPanel.SetActive(true);
        }

        public void RetryBtn_Click()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        public void SuccessBtn_click()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

    }
}
//