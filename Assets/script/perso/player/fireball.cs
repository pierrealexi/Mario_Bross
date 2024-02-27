using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToLive = 1.5f;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DestroyAfterTime(){
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
