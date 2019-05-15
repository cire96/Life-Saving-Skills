using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    void EnterMenu(){
        SceneManager.LoadScene(0);
    }
    void EnterLevel1(){
        SceneManager.LoadScene(1);
    }
    void EnterLevel2(){
        SceneManager.LoadScene(2);
    }
}
