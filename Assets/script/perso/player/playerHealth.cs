using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float InvinciblityTime;

    public bool isInvincible = false;
    public healthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage){
        if (!isInvincible){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //le joueur est il vivant

            if (currentHealth <= 0){
                Die();
                return; // pour sortir de la fonction
            }

            isInvincible = true;
            StartCoroutine(InvincibleFlash(InvinciblityTime));
            StartCoroutine(InvincibleDelay(3f));
        }
    }

    public IEnumerator InvincibleFlash(float time){
        while (isInvincible){
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(time);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator InvincibleDelay(float time){
        yield return new WaitForSeconds(time);
        isInvincible = false;
    }

    void Die(){
        //bloque les mouvements

        transform.GetComponent<Samourai_Behaviour>().enabled = false;

        // animation de mort

        transform.GetComponent<Animator>().SetTrigger("Death");

        // empeche les collisions

    
        transform.GetComponent<Collider2D>().enabled = false;
        transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        // empeche de shooter 

        transform.GetComponent<Shoot>().enabled = false;
        Debug.Log("Player died");
    }

}
