using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float mouseSensitivity = 100f;
    public float minY = -20f;
    public float maxY = 60f;

    private float currentYaw = 0f;
    private float currentPitch = 0f;

    void LateUpdate()
    {
        // Capture mouse input.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Update the rotation angles.
        currentYaw += mouseX; // Horizontal rotation.
        currentPitch -= mouseY; // Vertical rotation.

        // Limit the vertical rotation.
        currentPitch = Mathf.Clamp(currentPitch, minY, maxY);

        // Calculate the desired camera position.
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Update the camera's position and rotation.
        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f); // The camera looks at the player.

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        offset = offset * (1f - scroll);

    }
}
