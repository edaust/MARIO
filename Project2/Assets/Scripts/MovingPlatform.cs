using System;
using UnityEngine;

namespace Assets.GameFolders.Scripts
{
    public class MovingPlatform : MonoBehaviour
    {
        public int hight = 10;
        private float startYPos;

        private void Start()
        {
            startYPos = transform.position.y;
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, startYPos + Mathf.PingPong(Time.time * 2, hight),
                transform.position.z); //move on y axis only
        }
    }
}