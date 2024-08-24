using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public bool isShipDriving = false;
    private  CharacterController characterController;
    private ThirdPersonController thirdPersonController;
    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isShipDriving)
        {
            Debug.Log("Gemi kullaniliyor");
            thirdPersonController.MoveSpeed = 0;
            thirdPersonController.SprintSpeed = 0;
            thirdPersonController.JumpHeight = 0;
            thirdPersonController.CanMove = false;
            transform.SetParent(GameObject.FindGameObjectWithTag("Ship").transform);
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShipWheel"))
        {
            Debug.Log("Gemiyi Kullanmak icin E tusuna bas");
            isShipDriving = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShipWheel"))
        {
            Debug.Log("Gemi kullanýmý bitti");
            //isShipDriving = false;
        }
    }
}
