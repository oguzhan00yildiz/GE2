using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] PlayerInteractions playerInteractions;
    [Header("Ship Movement Settings")]
    public float forwardSpeed = 10f;  // Ýleri hýz
    public float rotationSpeed = 70f; // Yatay dönüþ hýzý
    public float pitchSpeed = 30f;    // Yukarý/aþaðý hareket hýzý
    public float diveSpeed = 15f;     // Dalýþ ve yükselme hýzý

    private float currentPitch = 0f;  // Yukarý ve aþaðý pitch kontrolü
    private float currentYaw = 0f;    // Sol ve sað yönlendirme
    private float currentRoll = 0f;   // Roll kontrolü (yan yatýrma)

    private void Update()
    {
        if (!playerInteractions.isShipDriving) return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Ýleri ve geri hareket (W ve S tuþlarý)
        float moveInput = Input.GetAxis("Vertical"); // W ve S tuþlarý (ileri geri)
        transform.Translate(Vector3.forward * moveInput * forwardSpeed * Time.deltaTime);

        // Yatay dönüþ (A ve D tuþlarý)
        float yawInput = Input.GetAxis("Horizontal"); // A ve D tuþlarý (sol sað)
        currentYaw += yawInput * rotationSpeed * Time.deltaTime;

        // Yaw (saða sola dönüþ) gemiyi döndürür
        transform.Rotate(0f, currentYaw, 0f);

        // Yukarý-aþaðý pitch kontrolü (Ctrl ve Shift tuþlarý)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentPitch = -pitchSpeed * Time.deltaTime; // Dalýþ (Shift tuþu)
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentPitch = pitchSpeed * Time.deltaTime; // Yukarý hareket (Ctrl tuþu)
        }
        else
        {
            currentPitch = 0f; // Ne Shift ne de Ctrl tuþuna basýlmadýysa pitch sýfýrlanýr
        }

        // Pitch (yukarý ve aþaðý hareket) gemiyi döndürür
        transform.Rotate(currentPitch, 0f, 0f);

        // Roll kontrolü (Q ve E tuþlarý ile yana yatma)
        if (Input.GetKey(KeyCode.Q))
        {
            currentRoll = rotationSpeed * Time.deltaTime; // Sol yatma (Q tuþu)
        }
        else if (Input.GetKey(KeyCode.E))
        {
            currentRoll = -rotationSpeed * Time.deltaTime; // Sað yatma (E tuþu)
        }
        else
        {
            currentRoll = 0f; // Ne Q ne de E tuþuna basýlmadýysa roll sýfýrlanýr
        }

        // Roll (yana yatma) gemiyi yanlara yatýrýr
        transform.Rotate(0f, 0f, currentRoll);
    }
}
