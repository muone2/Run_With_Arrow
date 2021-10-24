using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public static ArrowSpawner instance;
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

    public GameObject[] goolArrow;
    public GameObject[] poolingArrowPreFeb;
    GameObject[,] arrow = new GameObject[4,11];
    Vector3 poolPosition = new Vector3(10,10,0);
    int[] fieldArrowCount = new int[4];
    public float playtime = -2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolingArrowPreFeb.Length; i++)
        {
            fieldArrowCount[i] = 0;
            for (int j = 0; j < 11; j++)
            {
                arrow[i, j] = Instantiate(poolingArrowPreFeb[i], poolPosition, Quaternion.identity);
                arrow[i, j].transform.parent = gameObject.transform;
                arrow[i, j].GetComponent<MoveArrow>().arrowtype = i;
                arrow[i, j].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        playtime += Time.deltaTime;
        if (playtime > 0.465116)  //노래가 129bpm, 1분에 129번의 마디가 들어감. 즉 1마디당 60/129
        {
            SpawnArrow();
            playtime = 0;
        }
    }

    void SpawnArrow()
    {
        int a = Random.Range(0, poolingArrowPreFeb.Length);
        arrow[a, fieldArrowCount[a]].transform.position = poolingArrowPreFeb[a].transform.position - new Vector3(0, 10, 0);
        arrow[a, fieldArrowCount[a]].SetActive(true);
        fieldArrowCount[a]++;
        if (fieldArrowCount[a] >= 11)
            fieldArrowCount[a] = 0;
    }

    public void BackPoolArrow(GameObject arrow)
    {
       arrow.transform.position = poolPosition;
       arrow.SetActive(false);
        
    }
}
