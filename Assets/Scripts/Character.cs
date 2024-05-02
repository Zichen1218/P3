using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController characterController;
    public Transform cameraTransform;  // Add a public Transform to assign the camera
    public float speed = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get the input from WASD keys
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        // Transform the move from local space to world space relative to the camera's rotation
        move = cameraTransform.TransformDirection(move);
        move.y = 0; // Ensure that the character does not move up/down

        // Move the character
        characterController.Move(move * Time.deltaTime * speed);
    }
}
