using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public TextAsset textJSON;
    public GameObject firePrefab;
    public Transform parentTransform;
    public static bool hasSpawned = false;
    private int count = 0;

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
        if (hasSpawned) return;
        
        myFire = JsonUtility.FromJson<FireList>(textJSON.text);

        foreach (FireInstance fire in myFire.fire)
        {
            if (count >= 9) break;
            GameObject newFire = Instantiate(firePrefab, parentTransform);
            
            newFire.transform.position = new Vector3(
                (2.0f * fire.position.x) - 1.0f,
                fire.position.y,
                (fire.position.z * -2.0f) + 1.0f
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