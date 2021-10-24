using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    public int arrowtype;
    public Vector3 movementset = new Vector3(0, 1.0f, 0);
    float speed = 5f;
    int effecttypy;
    bool isfinish = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 7 && !CompareTag("gool"))
        {
            transform.Translate(movementset * speed * Time.deltaTime);
        }

        if (transform.position.y >= 4.7 && isfinish == false)
        {
            UIManager.instance.ChangeEffect(0);
            isfinish = true;
        }
            if (transform.position.y >= 7)
        {
            ArrowSpawner.instance.BackPoolArrow(gameObject);
        }

        if (Mathf.Abs(ArrowSpawner.instance.goolArrow[arrowtype].transform.position.y - gameObject.transform.position.y) < 0.7)
        {
            effecttypy = 1;
            if (Mathf.Abs(ArrowSpawner.instance.goolArrow[arrowtype].transform.position.y - gameObject.transform.position.y) < 0.25)
            {
                effecttypy = 2;
            }

            switch (arrowtype)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        ArrowSpawner.instance.BackPoolArrow(gameObject);
                        UIManager.instance.ChangeEffect(effecttypy);
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        ArrowSpawner.instance.BackPoolArrow(gameObject);
                        UIManager.instance.ChangeEffect(effecttypy);
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        ArrowSpawner.instance.BackPoolArrow(gameObject);
                        UIManager.instance.ChangeEffect(effecttypy);
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        ArrowSpawner.instance.BackPoolArrow(gameObject);
                        UIManager.instance.ChangeEffect(effecttypy);
                    }
                    break;
            }
        }
    }
}
