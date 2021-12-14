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
    public float playtime;
    public int progresseStart = 0;
    public int progresseEnd = 0;

    private int groupCount = 0;


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
        if (playtime < 10)
        {
            playtime += Time.deltaTime;
        }
        if (playtime > 0.47244 * 4 && groupCount <= 48)  //노래가 127bpm, 1분에 127번의 마디가 들어감. 즉 1마디당 60/127
        {
            SpawnArrowGroup();
            playtime = 0;
        }
    }//첫 시작은 4.875 차이
    
    void SpawnArrowGroup()
    {
        groupCount++;
        Debug.Log("Group is " + groupCount);
        int[] a = { 0, 0, 0, 0, 0, 0, 0, 0};
        if (groupCount < 6)
            SetOrder1(a);
        else if(groupCount >= 6 && groupCount<14)
            SetOrder2(a);
        else if (groupCount >= 14 && groupCount < 22)
            SetOrder3(a);
        else if (groupCount >= 22 && groupCount < 30)
            SetOrder2(a);
        else if (groupCount >= 30 && groupCount < 38)
            SetOrder4(a);
        else if (groupCount >= 38 && groupCount < 42)
            SetOrder2(a);
        else if (groupCount >= 42 && groupCount < 50)
            SetOrder3(a);


        for (int i = 0 ; i < 8; i++)
            SpawnArrow(a[i],i);
    }
    void SpawnArrowGroup2()
    {
        groupCount++;
        Debug.Log("Group is " + groupCount);
        int[] a = { 0, 0, 0, 0, 0, 0, 0, 0 };
        SetOrder2(a);
        for (int i = 0; i < 8; i++)
            SpawnArrow(a[i], i);
    }

    void SpawnArrow(int prefebClass, int arrowOrder) //prefebClass는 -1~3, arrowOrder는 0~7 거리차는,,, 4는 2.36346 (더 쪼갤 거면 8은 1.18173)
    {
        if (prefebClass == -1)
        {
            return;
        }
        arrow[prefebClass, fieldArrowCount[prefebClass]].transform.position = poolingArrowPreFeb[prefebClass].transform.position - new Vector3(0, 10 + (1.18173f * arrowOrder), 0);
        arrow[prefebClass, fieldArrowCount[prefebClass]].SetActive(true);
        fieldArrowCount[prefebClass]++;
        if (fieldArrowCount[prefebClass] >= 11)
            fieldArrowCount[prefebClass] = 0;
        progressStartAdd();
    }

    public void BackPoolArrow(GameObject arrow)
    {
        arrow.transform.position = poolPosition;
        arrow.SetActive(false);
        arrow.GetComponent<MoveArrow>().isfinish = false;
    }

    public void progressStartAdd()
    {
        progresseStart++;
       // Debug.Log(progresseStart);
    }
    public void progressEndAdd()
    {
        progresseEnd++;
        Debug.Log(progresseEnd);
    }

    void SetOrder1(int[] a)
    {
        int random = Random.Range(0, 4);

        switch (random)
        {
            case 0:
                a[0] = 0;
                a[1] = -1;
                a[2] = -1;
                a[3] = -1;
                a[4] = 0;
                a[5] = -1;
                a[6] = -1;
                a[7] = -1;
                break;
            case 1:
                a[0] = 1;
                a[1] = -1;
                a[2] = -1;
                a[3] = -1;
                a[4] = 1;
                a[5] = -1;
                a[6] = -1;
                a[7] = -1;
                break;
            case 2:
                a[0] = 2;
                a[1] = -1;
                a[2] = -1;
                a[3] = -1;
                a[4] = 2;
                a[5] = -1;
                a[6] = -1;
                a[7] = -1;
                break;
            case 3:
                a[0] = 3;
                a[1] = -1;
                a[2] = -1;
                a[3] = -1;
                a[4] = 3;
                a[5] = -1;
                a[6] = -1;
                a[7] = -1;
                break;
        }

    }
    void SetOrder2(int[] a)
    {
        int random = Random.Range(0, 8);

        switch (random)
        {
            case 0:
                a[0] = 0;
                a[1] = -1;
                a[2] = 0;
                a[3] = -1;
                a[4] = 0;
                a[5] = -1;
                a[6] = 0;
                a[7] = -1;
                break;
            case 1:
                a[0] = 1;
                a[1] = -1;
                a[2] = 1;
                a[3] = -1;
                a[4] = 1;
                a[5] = -1;
                a[6] = 1;
                a[7] = -1;
                break;
            case 2:
                a[0] = 2;
                a[1] = -1;
                a[2] = 2;
                a[3] = -1;
                a[4] = 2;
                a[5] = -1;
                a[6] = 2;
                a[7] = -1;
                break;
            case 3:
                a[0] = 3;
                a[1] = -1;
                a[2] = 3;
                a[3] = -1;
                a[4] = 3;
                a[5] = -1;
                a[6] = 3;
                a[7] = -1;
                break;
            case 4:
                a[0] = 0;
                a[1] = -1;
                a[2] = 0;
                a[3] = -1;
                a[4] = 3;
                a[5] = -1;
                a[6] = 3;
                a[7] = -1;
                break;
            case 5:
                a[0] = 1;
                a[1] = -1;
                a[2] = 1;
                a[3] = -1;
                a[4] = 2;
                a[5] = -1;
                a[6] = 2;
                a[7] = -1;
                break;
            case 6:
                a[0] = 0;
                a[1] = -1;
                a[2] = 1;
                a[3] = -1;
                a[4] = 2;
                a[5] = -1;
                a[6] = 3;
                a[7] = -1;
                break;
            case 7:
                a[0] = 3;
                a[1] = -1;
                a[2] = 2;
                a[3] = -1;
                a[4] = 1;
                a[5] = -1;
                a[6] = 0;
                a[7] = -1;
                break;
        }
    }
        void SetOrder3(int[] a)
        {
            int random = Random.Range(0, 4);

            switch (random)
            {
                case 0:
                    a[0] = 0;
                    a[1] = -1;
                    a[2] = 0;
                    a[3] = -1;
                    a[4] = 0;
                    a[5] = -1;
                    a[6] = 3;
                    a[7] = 3;
                    break;
                case 1:
                    a[0] = 1;
                    a[1] = -1;
                    a[2] = 1;
                    a[3] = -1;
                    a[4] = 1;
                    a[5] = -1;
                    a[6] = 2;
                    a[7] = 2;
                    break;
                case 2:
                    a[0] = 2;
                    a[1] = -1;
                    a[2] = 2;
                    a[3] = -1;
                    a[4] = 2;
                    a[5] = -1;
                    a[6] = 1;
                    a[7] = 1;
                    break;
                case 3:
                    a[0] = 3;
                    a[1] = -1;
                    a[2] = 3;
                    a[3] = -1;
                    a[4] = 3;
                    a[5] = -1;
                    a[6] = 0;
                    a[7] = 0;
                    break;
            }
        }
    void SetOrder4(int[] a)
    {
        int random = Random.Range(4, 8);

        switch (random)
        {
            case 4:
                a[0] = 0;
                a[1] = -1;
                a[2] = 2;
                a[3] = 1;
                a[4] = 2;
                a[5] = 1;
                a[6] = -1;
                a[7] = -1;
                break;
            case 5:
                a[0] = 3;
                a[1] = -1;
                a[2] = 1;
                a[3] = 2;
                a[4] = 1;
                a[5] = 2;
                a[6] = -1;
                a[7] = -1;
                break;
            case 6:
                a[0] = 1;
                a[1] = -1;
                a[2] = 3;
                a[3] = 0;
                a[4] = 3;
                a[5] = 0;
                a[6] = -1;
                a[7] = -1;
                break;
            case 7:
                a[0] = 2;
                a[1] = -1;
                a[2] = 0;
                a[3] = 3;
                a[4] = 0;
                a[5] = 3;
                a[6] = -1;
                a[7] = -1;
                break;
        }
    }
}
