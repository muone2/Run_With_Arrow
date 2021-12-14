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
    public GameObject endingCanvas;
    public Text endingScore;

    public GameObject sound1;
    public GameObject sound2;
    public GameObject sound3;

    bool endingOn = false;

    private void Update()
    {
        scoreText.text = "SCORE: " + score;
        if (ArrowSpawner.instance.playtime > 5 && endingOn == false)
        {
            Ending();
            StartCoroutine("FadeIn");
        }

    }

    public void ChangeEffect(int a)
    {
        ArrowSpawner.instance.progressEndAdd();
        image.GetComponent<Image>().sprite = effectImages[a];
        if (a == 0)
        {
            sound1.SetActive(false);
            sound2.SetActive(false);
            sound3.SetActive(false);
            sound1.SetActive(true);
            score = score - 1;
        }
        if (a == 1)
        {
            sound1.SetActive(false);
            sound2.SetActive(false);
            sound3.SetActive(false);
            sound2.SetActive(true);
            score = score + 3;
        }
        if (a == 2)
        {
            sound1.SetActive(false);
            sound2.SetActive(false);
            sound3.SetActive(false);
            sound3.SetActive(true);
            score = score + 5;
        }
    }

    public void Ending()
    {
        endingOn = true;
        endingCanvas.SetActive(true);
        endingScore.text = "" + score;
    }

    IEnumerator FadeIn()
    {
        float i = 0;
        while (i < 1.0f)
        {
            i += 0.01f;
            endingCanvas.GetComponent<CanvasGroup>().alpha = i;
            yield return new WaitForSeconds(0.025f);
        }
    }

    public void GameESC()
    {
        Application.Quit();
    }

}
