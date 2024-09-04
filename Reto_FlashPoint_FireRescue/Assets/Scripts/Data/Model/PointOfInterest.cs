using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{

    public TextAsset textJSON;
    public GameObject POIPrefab;
    public Transform parentTransform;
    public static bool hasSpawned = false;
    private int count = 0;

    [System.Serializable]
    public class POIInstance
    {
        public int id;
        public Coordinates position;
    }

    [System.Serializable]
    public class Coordinates
    {
        public int x;
        public int y;
        public int z;
    }

    [System.Serializable]
    public class POIList
    {
        public POIInstance[] pointOfInterest;
    }

    public POIList myPOI = new POIList();

    // Start is called before the first frame update
    void Start()
    {
        if (hasSpawned) return;

        myPOI = JsonUtility.FromJson<POIList>(textJSON.text);

        foreach (POIInstance point in myPOI.pointOfInterest)
        {
            if (count >= 18) break;
            GameObject newPOI = Instantiate(POIPrefab, parentTransform);

            newPOI.transform.position = new Vector3(
                (2.0f * point.position.x) - 1.0f,
                point.position.y,
                (point.position.z * -2.0f) + 1.0f
            );

            count++;
        }

        hasSpawned = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
