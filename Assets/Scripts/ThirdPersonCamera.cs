using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;          // Referência ao transform do player
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset inicial da câmera
    public float mouseSensitivity = 100f; // Sensibilidade do mouse
    public float minY = -20f;         // Ângulo mínimo para o pitch
    public float maxY = 60f;          // Ângulo máximo para o pitch

    private float currentYaw = 0f;    // Rotação horizontal (yaw)
    private float currentPitch = 0f;  // Rotação vertical (pitch)

    void LateUpdate()
    {
        // Captura a entrada do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Atualiza os ângulos de rotação
        currentYaw += mouseX; // Rotação horizontal
        currentPitch -= mouseY; // Rotação vertical

        // Limita a rotação vertical
        currentPitch = Mathf.Clamp(currentPitch, minY, maxY);

        // Calcula a posição desejada da câmera
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Atualiza a posição e rotação da câmera
        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f); // A câmera olha para o player

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        offset = offset * (1f - scroll);

    }
}
