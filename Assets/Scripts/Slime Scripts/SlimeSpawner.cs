using UnityEngine;

public class SlimeSpawner : MonoBehaviour {



    public static GameObject spawn(GameObject s,Vector3 vec){
        return Instantiate(s);
    }

}