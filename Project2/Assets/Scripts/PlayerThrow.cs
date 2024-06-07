using System;
using UnityEngine;

namespace Assets.GameFolders.Scripts
{
    public class PlayerThrow : MonoBehaviour
    {
        public GameObject AcornPrefab;
        public float throwForce = 750f;
        private PlayerCollect _playerCollect;
        private KarakterHareket _karakterHareket;
        public AudioSource throwSound;

        private void Start()
        {
            _playerCollect = GetComponent<PlayerCollect>();
            _karakterHareket = GetComponent<KarakterHareket>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerCollect.AcornCount > 0)
            {
                _playerCollect.AcornCount--;
                throwSound.Play();

                bool isLookingLeft = _karakterHareket.spriteRenderer.transform.localScale.x < 0;
                Vector3 spawnPos = transform.position + Vector3.up +
                                   (isLookingLeft ? Vector3.left : Vector3.right);

                GameObject acorn = Instantiate(AcornPrefab, spawnPos, Quaternion.identity);
                acorn.GetComponent<CircleCollider2D>().isTrigger = false;
                acorn.GetComponent<Rigidbody2D>().isKinematic = false;
                acorn.GetComponent<Rigidbody2D>().AddForce((isLookingLeft ? Vector3.left : Vector3.right) * throwForce);
            }
        }
    }
}