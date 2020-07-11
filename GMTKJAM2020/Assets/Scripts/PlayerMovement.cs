using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity;
    
    private float hSpeed;
    private float vSpeed;
    private float zSpeed;
    
    private void Awake()
    {
        GameInput.movementInput += Move;
    }

    private void OnDestroy()
    {
        GameInput.movementInput -= Move;
    }

    private void Move(Vector2 input)
    {
        var moveDirection = transform.TransformDirection(new Vector3(input.x, 0, input.y));
        hSpeed = moveDirection.x;
        zSpeed = moveDirection.z;

        hSpeed *= moveSpeed;
        zSpeed *= moveSpeed;

        if (!controller.isGrounded)
        {
            hSpeed = 0;
            zSpeed = 0;
            vSpeed -= (gravity * Time.deltaTime) / 2;
        }
        var moveVector = new Vector3(hSpeed, vSpeed, zSpeed);
        controller.Move(moveVector * Time.deltaTime);
    }
}
