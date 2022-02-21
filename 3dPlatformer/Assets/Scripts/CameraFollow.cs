
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed; // place around 10 due to delta time
    public Vector3 Offset;

    void FixedUpdate()
    {
        Vector3 DesiredPosition = Target.position + Offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed * Time.deltaTime);
        transform.position = SmoothedPosition;
    }

}
