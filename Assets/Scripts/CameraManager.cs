using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset = new Vector3(1.3f, 1.1f, -7f); 
    public float smoothSpeed;
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (spriteRenderer.flipX == false)
        {
            cameraOffset = new Vector3(1.3f, 1.1f, -7f); 
        }
        else if (spriteRenderer.flipX == true)
        {
            cameraOffset = new Vector3(-1.3f, 1.1f, -7f); 
        }


        Vector3 desiredPosition = playerTransform.position + cameraOffset;


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
