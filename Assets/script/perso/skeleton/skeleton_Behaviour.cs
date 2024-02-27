using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public int Damage;
    private Transform target;
    private int destPoint = 0;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if ( Vector3.Distance(transform.position, target.position) < 0.3f) {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            sr.flipX = !sr.flipX;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("Player")){
            col.transform.GetComponent<playerHealth>().takeDamage(Damage);
            col.transform.localScale = new Vector3(3, 2, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("FireBall")){
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }

}
