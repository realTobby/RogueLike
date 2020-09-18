using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public Inventory playerInventory;
    public SpellManager playerSpellManager;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;

    public Texture2D cursorTexture;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(16, 16), CursorMode.Auto);

        playerInventory = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Inventory>();
        playerSpellManager = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<SpellManager>();
    }

    void UseItem(int index)
    {
        if(playerInventory.items[index].GetIsFull() == true)
        {
            playerSpellManager.Use(playerInventory.items[index]);
            playerInventory.DiscardItem(index);
        }
        else
        {
            Debug.Log("no item in slot " + (index+1));
        }
    }

    void CheckForInventoryPress()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            UseItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            UseItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            UseItem(3);
    }

    void MouseControl()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(this.transform.position, hit.transform.position, Color.red);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseControl();

        CheckForInventoryPress();

        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;

            

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        if (this.transform.position.y <= -50)
        {
            Debug.Log("reset pos");
            this.transform.position = new Vector3(0, 10, 0);
        }

    }
}
