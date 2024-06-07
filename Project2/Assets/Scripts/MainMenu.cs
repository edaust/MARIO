using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.GameFolders.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayBtn_Click()  //PlayBtn_Click metodu ile UI'daki bir butona tıklanarak, "Game" adında yeni bir sahne ekrana gelir.
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}
