using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samourai_Behaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    public float jumpForce; 
    private bool isGrounded = false;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
{
    float direction = Input.GetAxis("Horizontal");

    if (isGrounded){
        anim.SetBool("Jump", false);
    }
    // Si la touche d'espace est enfoncée et que le personnage est au sol
    if (Input.GetKey(KeyCode.Space) && isGrounded) 
    {
        Jump();
        anim.SetBool("Jump", true);
    }
    // Si la touche de déplacement horizontal est enfoncée
    else if (direction != 0)
    {
        Run(direction);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}

    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, 0f); //je m'assure ici que mon personnage n'accumule pas les sauts
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Run(float input){
        flip(rb.velocity.x);
        rb.velocity = new Vector2(speed*input, rb.velocity.y);
    }

    void flip(float velocity){
        if (velocity > 0.1f){
            sr.flipX = false;
        }else if (velocity < -0.1f){
            sr.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            isGrounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
}
