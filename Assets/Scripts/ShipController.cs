using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] PlayerInteractions playerInteractions;
    [Header("Ship Movement Settings")]
    public float forwardSpeed = 10f;  // �leri h�z
    public float rotationSpeed = 70f; // Yatay d�n�� h�z�
    public float pitchSpeed = 30f;    // Yukar�/a�a�� hareket h�z�
    public float diveSpeed = 15f;     // Dal�� ve y�kselme h�z�

    private float currentPitch = 0f;  // Yukar� ve a�a�� pitch kontrol�
    private float currentYaw = 0f;    // Sol ve sa� y�nlendirme
    private float currentRoll = 0f;   // Roll kontrol� (yan yat�rma)

    private void Update()
    {
        if (!playerInteractions.isShipDriving) return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        // �leri ve geri hareket (W ve S tu�lar�)
        float moveInput = Input.GetAxis("Vertical"); // W ve S tu�lar� (ileri geri)
        transform.Translate(Vector3.forward * moveInput * forwardSpeed * Time.deltaTime);

        // Yatay d�n�� (A ve D tu�lar�)
        float yawInput = Input.GetAxis("Horizontal"); // A ve D tu�lar� (sol sa�)
        currentYaw += yawInput * rotationSpeed * Time.deltaTime;

        // Yaw (sa�a sola d�n��) gemiyi d�nd�r�r
        transform.Rotate(0f, currentYaw, 0f);

        // Yukar�-a�a�� pitch kontrol� (Ctrl ve Shift tu�lar�)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentPitch = -pitchSpeed * Time.deltaTime; // Dal�� (Shift tu�u)
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentPitch = pitchSpeed * Time.deltaTime; // Yukar� hareket (Ctrl tu�u)
        }
        else
        {
            currentPitch = 0f; // Ne Shift ne de Ctrl tu�una bas�lmad�ysa pitch s�f�rlan�r
        }

        // Pitch (yukar� ve a�a�� hareket) gemiyi d�nd�r�r
        transform.Rotate(currentPitch, 0f, 0f);

        // Roll kontrol� (Q ve E tu�lar� ile yana yatma)
        if (Input.GetKey(KeyCode.Q))
        {
            currentRoll = rotationSpeed * Time.deltaTime; // Sol yatma (Q tu�u)
        }
        else if (Input.GetKey(KeyCode.E))
        {
            currentRoll = -rotationSpeed * Time.deltaTime; // Sa� yatma (E tu�u)
        }
        else
        {
            currentRoll = 0f; // Ne Q ne de E tu�una bas�lmad�ysa roll s�f�rlan�r
        }

        // Roll (yana yatma) gemiyi yanlara yat�r�r
        transform.Rotate(0f, 0f, currentRoll);
    }
}
