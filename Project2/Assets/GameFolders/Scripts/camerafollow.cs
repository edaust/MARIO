using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;

     void LateUpdate()
    {
        transform.position = targetObject.transform.position+ cameraOffset;
    }
}
