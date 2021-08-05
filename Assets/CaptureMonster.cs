using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMonster : MonoBehaviour
{

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began)
            {

                Monster monster =  FindObjectOfType<Monster>();
                
                if(monster != null)
                {
                    Instantiate(ball, monster.transform.position, monster.transform.rotation);
                    Destroy(monster.gameObject);
                }

            }
        }
    }
}
