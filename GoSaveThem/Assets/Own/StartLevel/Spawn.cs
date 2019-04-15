using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject initiate;
    private List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject victimPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        foreach ( GameObject s in GameObject.FindGameObjectsWithTag("Spawn") ){
            spawnPoints.Add(s);
        }

    }

    // Update is called once per frame
    public void SpawnVictims()
    {
        Debug.Log("Spawn Victims");
        LevelSettings LevelSettings = initiate.GetComponent<LevelSettings>();
        
        for ( int i = 0; i < LevelSettings.NrGreenVictims; i++ ){
            SpawnV("Green");
            Debug.Log("<color=green><b>Green victim spawned</b></color>");
        }
        for ( int i = 0; i < LevelSettings.NrYellowVictims; i++ ){
            SpawnV("Yellow");
            Debug.Log("<color=Yellow><b>Yellow victim spawned</b></color>");
        }
        for ( int i = 0; i < LevelSettings.NrRedVictims; i++ ){
            SpawnV("Red");
            Debug.Log("<color=red><b>Red victim spawned</b></color>");
        }
        for ( int i = 0; i < LevelSettings.NrBlackVictims; i++ ){
            SpawnV("Black");
            Debug.Log("<color=black><b>Black vicitm spawn</b></color>");
        }
    }

    void SpawnV( string prio ){
        int index = Random.Range( 0, (spawnPoints.Count - 1) );
        //Debug.Log(spawnPoints.Count);
        GameObject spawn = spawnPoints[index];
        spawnPoints.RemoveAt(index);
        GameObject victim = Instantiate(victimPrefab, spawn.transform.position, spawn.transform.rotation);
        victim.transform.parent = spawn.transform;
        // Slumpmässigt välj ett utseende
        GameObject skin = victim.transform.GetChild(Random.Range(0,18)).gameObject;
        skin.SetActive(true);
        victim.GetComponent<Parameters>().prio = prio;
    }
}
