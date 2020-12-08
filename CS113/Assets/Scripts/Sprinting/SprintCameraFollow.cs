using UnityEngine;

public class SprintCameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    void LateUpdate()
    {
        //Vector3 desiredPos = target.position + offset;
        //Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPos;
        transform.position = target.position + offset;
    }

}
