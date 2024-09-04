using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;


public class Firefighter : MonoBehaviour
{
    public GameObject firefighterPrefab;
    public static bool hasSpawned = false;

    private List<GameObject> firefighters = new List<GameObject>();
    private FirefighterList myFirefighter = new FirefighterList();

    [System.Serializable]
    public class FirefighterInstance
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
    public class FirefighterList
    {
        public FirefighterInstance[] firefighter;
    }



    void Start()
    {
        StartCoroutine(FetchData());
    }

    IEnumerator FetchData()
    {
        string url = "http://localhost:8585";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching data : " + www.error);
            
            }
            else
            {
                myFirefighter = JsonUtility.FromJson<FirefighterList>(www.downloadHandler.text);
                if (!hasSpawned)
                {
                    SpawnFighters();
                    hasSpawned = true;
                }
                else
                {
                    UpdatePos();
                }
            }
        }
    }

    void SpawnFighters()
    {
        foreach (FirefighterInstance fighter in myFirefighter.firefighter)
        {
            if (firefighters.Count >= 6) break;

            GameObject newFirefighter = Instantiate(firefighterPrefab);
            firefighters.Add(newFirefighter);

            newFirefighter.transform.position = new Vector3(
                (2.0f * fighter.position.x) - 1.0f,
                fighter.position.y,
                (fighter.position.z * -2.0f) + 1.0f
            );
        }
    }

    void UpdatePos()
    {
        for (int i = 0; i < firefighters.Count; i++)
        {
            if (i >= myFirefighter.firefighter.Length) break;

            FirefighterInstance fighter = myFirefighter.firefighter[i];
            GameObject firefighter = firefighters[i];

            firefighter.transform.position = new Vector3(
                (2.0f * fighter.position.x) - 1.0f,
                fighter.position.y,
                (fighter.position.z * -2.0f) + 1.0f
            );
        }
    }

    void Update()
    {
        if (hasSpawned)
        {
            StartCoroutine(FetchData());
        }
        
    }
}
