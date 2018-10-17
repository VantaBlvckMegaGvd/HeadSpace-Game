using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShift : MonoBehaviour {

    private GameObject enemyHead;
    public float moveSpeed;
    public float jump;
    public int attack;
    public Transform enemySpawn;
    public Transform enemyRotation;
    public SpaceShift enemy;
    // Use this for initialization
  
    public void Start()
    {
      LoadSpaceShift(enemy);
    }
    

    public void LoadSpaceShift(SpaceShift spaceShift)
    {
        Destroy(enemyHead);
        moveSpeed = spaceShift.moveSpeed;
        
        
        attack = spaceShift.attack;

        //fill this in

        enemyHead = Instantiate(spaceShift.charecter, enemySpawn.position, enemyRotation.rotation, this.transform);
        enemyHead.transform.localScale = Vector3.one;

    }
}
