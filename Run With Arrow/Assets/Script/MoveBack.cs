using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public GameObject[] back;
    Vector3 movementset = new Vector3(-1.0f, 0, 0);
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < back.Length; i++)
        {
            back[i].transform.Translate(movementset * speed * Time.deltaTime);
            if (back[i].transform.position.x <= -24)
            {
                back[i].transform.position = new Vector3(24, 0, 0);
            }
        }
    }
}
