using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int score = 0;
    public Text scoreText;
    public Sprite[] effectImages;
    public GameObject image;

    private void Update()
    {
        scoreText.text = "SCORE: " + score;
    }

    public void ChangeEffect(int a)
    {
        image.GetComponent<Image>().sprite = effectImages[a];
        if (a == 0)
            score = score - 1;
        if (a == 1)
            score = score + 3;
        if (a == 2)
            score = score + 5;

    }
    
}
