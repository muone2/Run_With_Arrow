using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveGround : MonoBehaviour
{
    public GameObject[] ground;
    Vector3 movementset = new Vector3(-1.0f, 0, 0);
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ground.Length; i++)
        {
            ground[i].transform.Translate(movementset * speed * Time.deltaTime);
            if (ground[i].transform.position.x <= -30)
            {
                ground[i].transform.position = new Vector3(29, 0, 0);
            }
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("InGame");
    }

}
