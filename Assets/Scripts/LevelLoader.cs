using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    int levelToLoad;	

	void Start () {
        levelToLoad = PlayerPrefs.GetInt("levelToLoad");
        //Debug.Log(levelToLoad);
        Instantiate(Resources.Load("Level" + levelToLoad.ToString()));
	}
	
	void Update () {
        
	}
}
