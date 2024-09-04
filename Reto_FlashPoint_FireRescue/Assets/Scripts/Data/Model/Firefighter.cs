using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighter : MonoBehaviour
{

    public TextAsset textJSON;
    public GameObject firefighterPrefab;
    // public Transform parentTransform;
    public static bool hasSpawned = false;
    private int count = 0;

    [System.Serializable]
    public class firefighterInstance
    {
        public int id;
        public int actionPoints;
        public int victim;
        public int knockOut;
        public bool carryingVictim;
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
    public class firefighterList
    {
        public firefighterInstance[] firefighter;
    }

    public firefighterList myFirefighter = new firefighterList();

    void Start()
    {
        if (hasSpawned) return;

        myFirefighter = JsonUtility.FromJson<firefighterList>(textJSON.text);

        foreach (firefighterInstance fighter in myFirefighter.firefighter)
        {
            if (count >= 6) break;
            GameObject newFirefighter = Instantiate(firefighterPrefab);

            newFirefighter.transform.position = new Vector3(
                (2.0f * fighter.position.x) - 1.0f,
                fighter.position.y,
                (fighter.position.z * -2.0f) + 1.0f
            );

            count++;
            
        }

        hasSpawned = true;

    }
        void Update()
        {
        
        }
        
}
