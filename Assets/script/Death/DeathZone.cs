using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private Transform playerSpawn;

    private void Awake(){
        playerSpawn = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            col.transform.position = playerSpawn.position;
        }
    }
}
