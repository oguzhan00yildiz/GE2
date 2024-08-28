using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private bool isPlayerOnTheWheel = false;
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
        if (Input.GetKeyDown(KeyCode.E)&&isPlayerOnTheWheel)
        {
            isShipDriving=true;
            Debug.Log("Ship is moving");
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
            Debug.Log("Press E to Drive the Ship");
            isPlayerOnTheWheel = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShipWheel"))
        {
            Debug.Log("Ship is not using anymore");
            //isShipDriving = false;
        }
    }
}
