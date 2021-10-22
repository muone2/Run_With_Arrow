using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleMoveGround : MonoBehaviour
{
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(ground.transform.position.x>-52.02)
            ground.transform.position = ground.transform.position - new Vector3(0.01f, 0, 0);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("InGame");
    }

}
