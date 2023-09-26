using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    private float widthvalue = 8;
    public Color[] coinColors;
    public TextMeshPro playerScoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        //SpawnCoin();
        Invoke("SpawnCoin", 1);
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
    }

    public void SpawnCoin()
    {
        float randomXValue = Random.Range(-widthvalue, widthvalue); 
        Vector3 pos = new Vector3(randomXValue, 5, 0);
        GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);

        CoinScript coinScript = coin.GetComponent<CoinScript>();

        int rndValue = Random.Range(0, 3);
        coinScript.ChangeCoinValue(rndValue);
        coinScript.ChangeCoinColor(coinColors[rndValue]);
        Invoke("SpawnCoin", Random.Range(0.5f, 2f));
    }
}
