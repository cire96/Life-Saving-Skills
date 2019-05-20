using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public int NrVictims = 4;
    public int MaxNrGreenVictims = 1;
    public int MaxNrBlackVictims = 1;

    public int NrGreenVictims;
    public int NrBlackVictims;
    public int NrYellowVictims;
    public int NrRedVictims;

    public GameObject SpawnHolder;

    // Start is called before the first frame update
    void Start()
    {   
        // Slumpa antal gröna och svarta offer, får max vara något heltal så det inte blir för enkelt.
        NrGreenVictims = Random.Range(0, MaxNrGreenVictims);
        NrBlackVictims = Random.Range(0, MaxNrBlackVictims);
        // Resten blir antingen röda eller gula offer.
        NrYellowVictims = Random.Range(0, (NrVictims - NrGreenVictims - NrBlackVictims));
        NrRedVictims = NrVictims - NrGreenVictims - NrBlackVictims - NrYellowVictims;
        //SpawnHolder.GetComponent<Spawn>().SpawnVictims();
    }
}
