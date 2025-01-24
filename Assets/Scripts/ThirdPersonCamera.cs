using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;          // Refer�ncia ao transform do player
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset inicial da c�mera
    public float mouseSensitivity = 100f; // Sensibilidade do mouse
    public float minY = -20f;         // �ngulo m�nimo para o pitch
    public float maxY = 60f;          // �ngulo m�ximo para o pitch

    private float currentYaw = 0f;    // Rota��o horizontal (yaw)
    private float currentPitch = 0f;  // Rota��o vertical (pitch)

    void LateUpdate()
    {
        // Captura a entrada do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Atualiza os �ngulos de rota��o
        currentYaw += mouseX; // Rota��o horizontal
        currentPitch -= mouseY; // Rota��o vertical

        // Limita a rota��o vertical
        currentPitch = Mathf.Clamp(currentPitch, minY, maxY);

        // Calcula a posi��o desejada da c�mera
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Atualiza a posi��o e rota��o da c�mera
        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f); // A c�mera olha para o player

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        offset = offset * (1f - scroll);

    }
}
