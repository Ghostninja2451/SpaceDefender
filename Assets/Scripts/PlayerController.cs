using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] bool pcMode;
    private Vector2 move;
    private Vector2 mouseLook;
    private Vector2 joystickLook;
    private Vector3 rotationTarget;

    public void onMove(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
    }
    public void onMouseLook(InputAction.CallbackContext callbackContext)
    {
        mouseLook = callbackContext.ReadValue<Vector2>();
    }
    public void onJoyStickLook(InputAction.CallbackContext callbackContext)
    {
        joystickLook = callbackContext.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pcMode)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);
            if(Physics.Raycast(ray, out hit))
            {
                rotationTarget = hit.point;
            }
            movePlayerWithAim();
        }
        else
        {
            if (joystickLook.x == 0 && joystickLook.y == 0)
            {
                movePlayer();
            }
            else
            {
                movePlayerWithAim();
            }                
        }

    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement), rotationSpeed);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void movePlayerWithAim()
    {
        if(pcMode)
        {
            var lookPosition = rotationTarget - transform.position;
            lookPosition.y = 0;
            var rotation = Quaternion.LookRotation(lookPosition);

            Vector3 aimDirection = new Vector3(rotationTarget.x, 0, rotationTarget.y);
            if(aimDirection != Vector3.zero)
            {

            }
        }
        else
        {

        }
    }
}
