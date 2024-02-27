using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator parentAnimator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("FireBall"))
        {
            // parentAnimator.SetBool("dead", true);
            // parentAnimator.SetBool("dead", false);
            // yield return new WaitForSeconds(0.8f);
            Destroy(objectToDestroy);
        }
    }
}
