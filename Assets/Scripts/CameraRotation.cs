using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public int speed;
    public Transform cameraAxisTransform;
    public float minAngle;
    public float maxAngle;
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * speed
            * Input.GetAxis("Mouse X"), 0);
        var newAngleX = cameraAxisTransform.transform.localEulerAngles.x - Time.deltaTime * -speed
            * Input.GetAxis("Mouse Y");
        if (newAngleX > 180) newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        cameraAxisTransform.transform.localEulerAngles = new Vector3(newAngleX, 0, 0);
        
    }
}
