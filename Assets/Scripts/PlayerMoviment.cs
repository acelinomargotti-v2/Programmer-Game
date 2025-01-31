using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float playerSpeed;
    public float playerRotationSpeed;
    public float verticalSpeed; // Climbing and descending speed.
    public int playerSpaceOnInvetary;
    public Transform cameraTransform; // Main camera reference

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerShift();
        PlayerVerticalMovement();
    }

    public void PlayerRotation()
    {
        transform.Rotate(0, playerRotationSpeed * Time.deltaTime, 0);

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput != 0)
        {
            transform.Rotate(0, verticalInput * playerRotationSpeed * 15 * Time.deltaTime, 0);
        }

        if (horizontalInput != 0)
        {
            transform.Rotate(horizontalInput * playerRotationSpeed * 15 * Time.deltaTime, 0, 0);
        }
    }

    public void PlayerShift()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 forward = cameraTransform.forward; // forward camera direction
        Vector3 right = cameraTransform.right; // right camera direction

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movimentDirection = forward * verticalInput + right * horizontalInput;

        if (verticalInput != 0)
        {
            transform.Translate(movimentDirection.normalized * playerSpeed * Time.deltaTime, Space.World);
        }
        else if (horizontalInput != 0)
        {
            transform.Translate(movimentDirection.normalized * playerSpeed * Time.deltaTime, Space.World);
        }
    }

    public void PlayerVerticalMovement()
    {
        float verticalMovement = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            verticalMovement = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            verticalMovement = -1f;
        }

        Vector3 verticalDirection = new Vector3(0f, verticalMovement * verticalSpeed * Time.deltaTime, 0f);
        transform.Translate(verticalDirection, Space.World);
    }
}
