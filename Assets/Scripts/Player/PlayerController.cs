using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 move;
    public float forwardSpeed;

    private int desiredLane = 1; // Lanes: 0,1,2
    public float laneDistance = 2;

    public float jumpHeight = 2;
    public float gravity = -12f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver || PlayerManager.gameFinish)
            return;
        move.z = forwardSpeed;
        if (controller.isGrounded)
        {
            velocity.y = -1;
            //Yukarı zıplama
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
        //Sağa gitme
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        //Sola gitme
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }
        Vector3 targetPosition =
            transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 400 * Time.deltaTime);
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
        controller.Move(move * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver || PlayerManager.gameFinish)
            return;
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
        if (hit.transform.tag == "End")
        {
            PlayerManager.gameFinish = true;
        }
    }
}
