using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.GameFolders.Scripts
{
    internal class PlayerCollect : MonoBehaviour
    {
        public int LevelCollectRequirement = 0;
        [SerializeField] Image[] healtSprites;
        [SerializeField] TextMeshProUGUI scoreTxt;
        [SerializeField] GameObject failPannel;
        int healtCount;
        int totalCollectCount = 0; 

        private void Start()
        {
            healtCount = 3;
            ChangeHealt();
        }
        private void Update()
        {
            scoreTxt.text = "Score: " + totalCollectCount;
        }
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
            else if(collision.GetComponent<Bat>()) 
            {
                ChangeHealt(-1);
            }
        }
        void ChangeHealt(int healt = 0)
        {
            healtCount += healt;
            healtCount = Math.Clamp(healtCount, 0, 3); //degerın min max degerını asmadıgından emın olmak için.
            if(healtCount == 0)
            {
                gameObject.SetActive(false);
                failPannel.SetActive(true);
            }
            foreach(var image in healtSprites)
            {
                image.color = Color.black;
            } 
            for (int i = 0; i < healtCount; i++)
            {
                healtSprites[i].color = Color.white;
            }
        }
    }
}
//