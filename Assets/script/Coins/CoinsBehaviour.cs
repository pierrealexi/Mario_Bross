using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinValue = 1;
    private GameObject UI;
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("CoinAmount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player") {
            int currentCoins = int.Parse(UI.GetComponent<Text>().text) + coinValue;
            UI.GetComponent<Text>().text = currentCoins.ToString();
            Destroy(gameObject);
        }
    }
}
