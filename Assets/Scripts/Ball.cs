using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Text text;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 direction;

    float touchTimeStart;
    private float touchTimeFinish;
    float timeInterval;


    float throwForce = 50f; // to control throw force in Z direction

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * .5f, Screen.height * .1f, 2));
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
            startPos.z = transform.position.z - Camera.main.transform.position.z;
            startPos = Camera.main.ScreenToWorldPoint(startPos);
            rigidBody.isKinematic = false;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPos = Input.GetTouch(0).position;
            endPos.z = transform.position.z - Camera.main.transform.position.z;
            endPos = Camera.main.ScreenToWorldPoint(endPos);
            Vector3 force = endPos - startPos;
            force.z = force.magnitude;
            force /= (Time.time - touchTimeStart);
            rigidBody.AddForce(force * throwForce);

            Invoke("ResetBall", 3);
        }
    }


    public void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Monster"))
        {
            Destroy(otherObject.gameObject);
        }
    }


    public void ResetBall()
    {
        rigidBody.isKinematic = true;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * .5f, Screen.height * .1f, 2));
    }
}