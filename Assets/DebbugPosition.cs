using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebbugPosition : MonoBehaviour
{
    public Text Text;

    // Update is called once per frame
    void Update()
    {
        Text.text = transform.position.ToString();
    }
}