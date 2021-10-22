using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

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
    public GameObject player;
    public float a;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            a = -1;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            a = 1;

        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow))
            a = 0;

        player.GetComponent<Animator>().SetFloat("MotionState", a);

    }
}
