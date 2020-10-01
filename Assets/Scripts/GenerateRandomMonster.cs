using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GenerateRandomMonster : MonoBehaviour
{
    private ARPlaneManager planeManager;
    
    public List<GameObject> allMonsters;
    private bool monsterExists = false;

    // Start is called before the first frame update
    void Start()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            if (plane.alignment == PlaneAlignment.HorizontalUp && monsterExists == false)
            {
                GameObject monster = allMonsters[Random.Range(0, allMonsters.Count)];


                Vector3 center = new Vector3(plane.center.x, plane.center.y, plane.center.z);
                GameObject m = Instantiate(monster, center, Quaternion.Euler(0, Random.Range(0, 160), 0));

                monsterExists = true;
                plane.gameObject.SetActive(false);
            }
        }
    }
}