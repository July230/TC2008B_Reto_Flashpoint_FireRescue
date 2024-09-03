using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighter : MonoBehaviour
{

    public TextAsset textJSON;


    [System.Serializable]

    public class FirefighterAgent {
        public int id;
        public int actionPoints;
        public int victim;
        public int knockOut;
        public bool carryingVictim;
    }

    public FirefighterAgent myFirefighter = new FirefighterAgent();

    void Start()
    {
        myFirefighter = JsonUtility.FromJson<FirefighterAgent>(textJSON.text);
    }
}
