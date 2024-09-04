using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public TextAsset textJSON;
    public GameObject firePrefab;
    public static bool hasSpawned = false;

    [System.Serializable]
    public class FireInstance 
    {
        public int id;
        public Coordinates position;
    }

    [System.Serializable]
    public class Coordinates
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class FireList
    {
        public FireInstance[] fire;
    }

    public FireList myFire = new FireList();

    // Start is called before the first frame update
    void Start()
    {
        myFire = JsonUtility.FromJson<FireList>(textJSON.text);
        Coordinates firstPosition = myFire.fire[0].position;
        Vector3 position = new Vector3(
            (2.0f * firstPosition.x) - 1.0f, 
            firstPosition.y, 
            (firstPosition.z * -2.0f) + 1.0f
        );
        
        if (!hasSpawned)
        {
            Instantiate(firePrefab, position, Quaternion.identity);
            hasSpawned = true;  // Set the flag to true to prevent further spawning
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
