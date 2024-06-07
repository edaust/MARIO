using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;

    void LateUpdate()
    {
        transform.position = targetObject.transform.position + cameraOffset;
    }
}