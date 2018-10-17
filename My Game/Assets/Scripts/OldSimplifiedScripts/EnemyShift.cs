using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShift : MonoBehaviour {

    private GameObject enemyHead;
    public float speed;
    public float jump;
    public int attack;
    public Transform enemySpawn;
    public Transform enemyRotation;
    public SpaceShift enemy;
    public Transform target;
    GameObject charecter;

    Vector2 find;
    // Use this for initialization
  
    public void Start()
    {
      LoadSpaceShift(enemy);
    }
 

    private void Update()
    {
        find = (target.position - transform.position).normalized;
        transform.Translate(find * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider gamespace)
    {
        SpotObject();
    }

    void SpotObject()
    {

    }


    public void LoadSpaceShift(SpaceShift spaceShift)
    {
        Destroy(enemyHead);
        speed = spaceShift.moveSpeed;
        
        
        attack = spaceShift.attack;

        //fill this in

        enemyHead = Instantiate(spaceShift.charecter, enemySpawn.position, enemyRotation.rotation, this.transform);
        enemyHead.transform.localScale = Vector3.one;

    }
}
