using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.GameFolders.Scripts
{
    internal class PlayerCollect : MonoBehaviour
    {
        public int LevelCollectRequirement = 0;
        [SerializeField] Image[] healtSprites;
        [SerializeField] TextMeshProUGUI scoreTxt;
        [SerializeField] GameObject failPannel;
        public TextMeshProUGUI acornTxt;
        public SpriteRenderer _renderer;
        public GameObject CollectEffect;
        int healtCount;
        int totalCollectCount = 0;
        int collectedAcornCount = 0;
        public AudioSource DieSound, TakeDamageSound, GemCollectSound, AcornCollectSound;

        public int AcornCount
        {
            get
            {
                return collectedAcornCount;
            }
            set
            {
                collectedAcornCount = value;
                acornTxt.text = "X " + collectedAcornCount;
            }
        }

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

                Destroy(Instantiate(CollectEffect, collision.transform.position, Quaternion.identity), 1);

                Destroy(collision.gameObject);
                GemCollectSound.Play();

                if (totalCollectCount == LevelCollectRequirement)
                    Events.onSuccess?.Invoke();
            }
            else if (collision.GetComponent<Bat>())
            {
                StartCoroutine(TakeDamage());
                TakeDamageSound.Play();
                ChangeHealt(-1);
            }
            else if (collision.CompareTag("Acorn"))
            {
                collectedAcornCount++;
                AcornCollectSound.Play();
                acornTxt.text = "X " + collectedAcornCount;
                Destroy(collision.gameObject);
            }
        }

        void ChangeHealt(int healt = 0)
        {
            healtCount += healt;
            healtCount = Math.Clamp(healtCount, 0, 3); //degerın min max degerını asmadıgından emın olmak için.
            if (healtCount == 0)
            {
                DieSound.Play();
                gameObject.SetActive(false);
                failPannel.SetActive(true);
            }

            foreach (var image in healtSprites)
            {
                image.color = Color.black;
            }

            for (int i = 0; i < healtCount; i++)
            {
                healtSprites[i].color = Color.white;
            }
        }

        IEnumerator TakeDamage()
        {
            _renderer.color = Color.red;
            yield return new WaitForSeconds(.1f);
            _renderer.color = Color.white;
        }
    }
}
//