using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        afk,
        driving
    }

    private PlayerState playerState;

    public CharacterController controller;
    public Transform cam;

    public float movementSpeed;

    private float horizontalInput;
    private float verticalInput;

    private float turnSmoothTime = 0.15f;
    float turnSmoothVelocity;

    [Header("Audio")]
    [SerializeField] private AudioClip[] boatAudioClips;
    [SerializeField] private AudioSource boatAudio;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Vector3 moveDir = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 moveDir = new Vector3(horizontalInput, 0f, verticalInput).normalized;       

        if (moveDir.magnitude >= 0.1f)
        {
            if(playerState == PlayerState.afk)
            {
                playerState = PlayerState.driving;
                updateAudio();                
            }              

            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * movementSpeed * Time.deltaTime);
        }
        else if (playerState == PlayerState.driving)
        {
            playerState = PlayerState.afk;
            updateAudio();
        }            
    }

    public void updateAudio()
    {
        switch (playerState)
        {
            case PlayerState.afk:
                boatAudio.clip = boatAudioClips[0];
                boatAudio.volume = 0.618f;
                boatAudio.pitch = 0.79f;
                boatAudio.spatialBlend = 0;
                boatAudio.Play();
                break;
            case PlayerState.driving:
                boatAudio.clip = boatAudioClips[1];
                boatAudio.volume = 1f;
                boatAudio.pitch = 1.61f;
                boatAudio.spatialBlend = 0.818f;
                boatAudio.Play();
                break;
        }
    }
}
