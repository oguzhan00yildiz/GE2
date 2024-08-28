using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] PlayerInteractions playerInteractions;
    [Header("Ship Movement Settings")]
    public float forwardSpeed = 10f;  
    public float rotationSpeed = 70f; 
    public float pitchSpeed = 30f;    
    public float diveSpeed = 15f;     

    private float currentPitch = 0f;  
    private float currentYaw = 0f;    
    private float currentRoll = 0f;   

    private void Update()
    {
        if (!playerInteractions.isShipDriving) return;
        HandleMovement();
    }

    private void HandleMovement()
    {
       
        float moveInput = Input.GetAxis("Vertical"); 
        transform.Translate(Vector3.forward * moveInput * forwardSpeed * Time.deltaTime);

        float yawInput = Input.GetAxis("Horizontal"); 
        currentYaw += yawInput * rotationSpeed * Time.deltaTime;

        
        transform.Rotate(0f, currentYaw, 0f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentPitch = -pitchSpeed * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentPitch = pitchSpeed * Time.deltaTime; 
        }
        else
        {
            currentPitch = 0f; 
        }

        
        transform.Rotate(currentPitch, 0f, 0f);

        
        if (Input.GetKey(KeyCode.Q))
        {
            currentRoll = rotationSpeed * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.E))
        {
            currentRoll = -rotationSpeed * Time.deltaTime; 
        }
        else
        {
            currentRoll = 0f; 
        }

        transform.Rotate(0f, 0f, currentRoll);
    }
}
