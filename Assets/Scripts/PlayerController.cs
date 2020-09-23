using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public Inventory playerInventory;
    public SpellManager playerSpellManager;

    public GameObject projectilePrefab;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;

    public Texture2D cursorTexture;
    RaycastHit hit;

    private float dr;
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

    void CheckForSpellPress()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CastSpell(1);
        }
    }

    void CastSpell(int spellIndex)
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        Vector3 direction = GetRayPos() - this.transform.position;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = direction * 100f;
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>());
    }

    Vector3 GetRayPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 100;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(this.transform.position, hit.transform.position, Color.red);
            Vector3 target = ray.GetPoint(distance);
            return target;
        }
        return new Vector3();
    }

    void MouseControl()
    {
        Vector3 direction = GetRayPos() - transform.position;
        float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MouseControl();

        CheckForInventoryPress();

        CheckForSpellPress();

        // is the controller on the ground?
            //Feed moveDirection with input.
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // float dr is declared outside
            /** There is no diagonal rotation, atm. **/
            if (h != 0) dr = 90 * h;
            if (v < 0) dr = 180;
            else if (v > 0) dr = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, dr, 0), 360 * Time.deltaTime);
            // not normalized, yet.
            transform.position += new Vector3(h, 0, v) * Time.deltaTime * speed;

        if (this.transform.position.y <= -50)
        {
            Debug.Log("reset pos");
            this.transform.position = new Vector3(0, 10, 0);
        }

    }
}
