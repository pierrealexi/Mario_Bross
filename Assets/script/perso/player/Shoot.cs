using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;

    public GameObject fireballPrefab;

    public float DelayShoot;

    private bool canShoot = true;

    public float fireballSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot){
            if (Input.GetKey(KeyCode.UpArrow)){
                UnityEngine.SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer.flipX)
                {
                    shoot(firePoint,new Vector2(-1,0));
                }
                else
                {
                    shoot(firePoint,new Vector2(1,0));
                }
                StartCoroutine(shootDelay());
            }
        }
    }

    private void shoot(Transform spawnPoint, Vector2 direction){
        canShoot = false;
        GameObject fireball= Instantiate(fireballPrefab, spawnPoint.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;
    }

    IEnumerator shootDelay(){
        yield return new WaitForSeconds(1/DelayShoot);
        canShoot = true;
    }

}
