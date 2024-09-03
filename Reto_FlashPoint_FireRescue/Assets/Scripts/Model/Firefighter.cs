using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighter : MonoBehaviour
{

    public TextAsset textJSON;
    public Transform firefighterTransform;
    public Transform firefighterTransform2;
    public Transform firefighterTransform3;
    public Transform firefighterTransform4;
    public Transform firefighterTransform5;
    public Transform firefighterTransform6;


    [System.Serializable]
    public class FirefighterAgent {
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
    public class FighterList
    {
        public FirefighterAgent[] player;
    }

    public FighterList myFirefighter = new FighterList();

    void Start()
    {
        myFirefighter = JsonUtility.FromJson<FighterList>(textJSON.text);
        Coordinates firstPosition = myFirefighter.player[0].position;
        Coordinates firstPosition2 = myFirefighter.player[1].position;
        Coordinates firstPosition3 = myFirefighter.player[2].position;
        Coordinates firstPosition4 = myFirefighter.player[3].position;
        Coordinates firstPosition5 = myFirefighter.player[4].position;
        Coordinates firstPosition6 = myFirefighter.player[5].position;
        
        firefighterTransform.position = new Vector3((2.0f * firstPosition.x) - 1.0f, firstPosition.y, (firstPosition.z * -2.0f) + 1.0f);
        firefighterTransform2.position = new Vector3((2.0f * firstPosition2.x) - 1.0f, firstPosition2.y, (firstPosition2.z * -2.0f) + 1.0f);
        firefighterTransform3.position = new Vector3((2.0f * firstPosition3.x) - 1.0f, firstPosition3.y, (firstPosition3.z * -2.0f) + 1.0f);
        firefighterTransform4.position = new Vector3((2.0f * firstPosition4.x) - 1.0f, firstPosition4.y, (firstPosition4.z * -2.0f) + 1.0f);
        firefighterTransform5.position = new Vector3((2.0f * firstPosition5.x) - 1.0f, firstPosition5.y, (firstPosition5.z * -2.0f) + 1.0f);
        firefighterTransform6.position = new Vector3((2.0f * firstPosition6.x) - 1.0f, firstPosition6.y, (firstPosition6.z * -2.0f) + 1.0f);
    }
}
