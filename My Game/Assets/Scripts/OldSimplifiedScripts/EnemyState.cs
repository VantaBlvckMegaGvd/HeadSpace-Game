using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

    public EnemyAttackRotation enemy;
    private float speed;
    
    private int attack;
    public float timeout;
    public Transform enemySpawn;
    public Transform enemyRotation;
    public Transform target;
    public GameObject enemyHead;
    public GameObject bullet2Prefab;
    public Transform bulletSpawn;
    public Transform bulletRotation;

    public Transform axeSpawn;
    public Transform axeRotation;
    public GameObject axePrefab;
    private float bulletSpeed;
    private float axeSpeed;

   Vector2 find;
    // Use this for initialization

    public void Start()
    {
        LoadEnemyAttackRotation(enemy);
    }


    private void Update()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter(Collider gamespace)
    {
        SpotObject();
    }

    void SpotObject()
    {

    }


    public void LoadEnemyAttackRotation(EnemyAttackRotation enemy)
    {
        Destroy(enemyHead);
        speed = enemy.moveSpeed;


        attack = enemy.attackMaxDamage;
        bulletSpeed = enemy.bulletSpeed;
        axeSpeed = enemy.axeSpeed;
        //fill this in

        enemyHead = Instantiate(enemy.charecter, enemySpawn.position, enemyRotation.rotation, this.transform);
        enemyHead.transform.localScale = Vector3.one;
        timeout = enemy.attackCooldown;

    }

    void FollowPlayer()
    {
        Vector3 targetPosition = target.transform.position;

        float distance = Vector3.Distance(targetPosition, this.transform.position);
        
        

        if (distance < 15f)
        {
            find = (target.position - transform.position).normalized;
            transform.Translate(find * Time.deltaTime * speed);

        }

        if (distance < 14f && distance > 5f)
        {
            Shoot();
        }

        if (distance < 4f)
        {
            Melee();
        }
    }
    void Shoot()
    {
      
         timeout -= Time.deltaTime;
        if(timeout<0)
        {
            var bullet = Instantiate(bullet2Prefab, bulletSpawn.position, bulletRotation.rotation);
            bullet.GetComponent<Rigidbody>().velocity =  bullet.transform.forward * bulletSpeed;


            Destroy(bullet, 2f);

            timeout = enemy.attackCooldown;
        }

       
    }
    void Melee()
    {
        
        timeout -= Time.deltaTime;
        if (timeout < 0)
        {
            var axe = Instantiate(axePrefab, axeSpawn.position, axeRotation.rotation);
            axe.GetComponent<Rigidbody>().velocity = axe.transform.forward * axeSpeed;


            Destroy(axe, 2f);

            timeout = enemy.attackCooldown;
        }

        
    }
}
