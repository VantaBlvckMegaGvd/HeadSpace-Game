using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement2 : MonoBehaviour
{
    public Rigidbody Player;
    private GameObject currentHead;
    public float moveSpeed;
    public float jump;
    public int attack;
    public SpaceShift[] player;
    public GameObject bullet2Prefab;
    public Transform bulletSpawn;
    public Transform bulletRotation;
    public int health = 4;
    public Transform playerSpawn;
    public Transform playerRotation;

    public float bulletSpeed = 8.0f;


    public void Start()
    {
        LoadSpaceShift(player[0]);
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 horizontalmovement = new Vector3(horizontal, 0f, 0f);
        transform.Translate(horizontalmovement * Time.deltaTime * moveSpeed);

        if (Input.GetMouseButtonDown(1))
        {
            Fired();
        }

    }










    void Fired()
    {
        var bullet = GameObject.Instantiate(bullet2Prefab, bulletSpawn.position, bulletRotation.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, 4.0f);
    }
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpGood();
        }
    }
    void JumpGood()
    {
        Vector3 jumpup = new Vector3(0f, jump, 0f);
        Player.AddForce(jumpup, ForceMode.Impulse);
    }

    public void LoadSpaceShift(SpaceShift spaceShift)
    {
        Destroy(currentHead);
        moveSpeed = spaceShift.moveSpeed;
        jump = spaceShift.jump;
        health = spaceShift.health;
        attack = spaceShift.attack;
        
        //fill this in

        currentHead = Instantiate(spaceShift.charecter, playerSpawn.position, playerRotation.rotation, this.transform);
        currentHead.transform.localScale = Vector3.one;

    }
}