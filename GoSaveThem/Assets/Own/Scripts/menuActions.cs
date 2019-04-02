using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuActions : MonoBehaviour
{
    public List<GameObject> mainMenuList, playList, soundList, howList, levelList;
    public Image Title, SoundPopUp, LevelPopUp, HowPopUp;
    public GameObject Disclaimer, StartBtn, SoundBtn, HowBtn;
    public GameObject Level1, Level2, Level3, BackBtn, LevelStartBtn, LevelCancelBtn, Lock2, Lock3;
    public GameObject MusicTxt, MusicSlider, VoiceTxt, VoiceSlider, SoundSaveBtn, SoundCancelBtn;
    public GameObject HowScrollView, HowCloseBtn;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuList = new List<GameObject>() { StartBtn, SoundBtn, HowBtn };
        playList = new List<GameObject>() { Level1, Level2, Level3, BackBtn, Lock2, Lock3};
        soundList = new List<GameObject>() { MusicTxt, MusicSlider, VoiceTxt, VoiceSlider, SoundSaveBtn, SoundCancelBtn };
        howList = new List<GameObject>() { HowScrollView, HowCloseBtn };
        levelList = new List<GameObject>() { LevelStartBtn, LevelCancelBtn };

        SoundPopUp.enabled = false;
        LevelPopUp.enabled = false;
        HowPopUp.enabled = false;
        Title.enabled = true;

        foreach (GameObject menuItem in mainMenuList) {
            menuItem.SetActive(true);
        }
        foreach (GameObject playItem in playList) {
            playItem.SetActive(false);
        }
        foreach (GameObject soundItem in soundList) {
            soundItem.SetActive(false);
        }
        foreach (GameObject howItem in howList) {
            howItem.SetActive(false);
        }
        foreach (GameObject levelItem in levelList) {
            levelItem.SetActive(false);
        }
    }

    public void playButton()
    {
        Title.enabled = false;
        SoundPopUp.enabled = false;
        LevelPopUp.enabled = false;
        HowPopUp.enabled = false;

        foreach (GameObject menuItem in mainMenuList)
        {
            menuItem.SetActive(false);
        }
        foreach (GameObject playItem in playList)
        {
            playItem.SetActive(true);
        }
        foreach (GameObject soundItem in soundList)
        {
            soundItem.SetActive(false);
        }
        foreach (GameObject howItem in howList)
        {
            howItem.SetActive(false);
        }
        foreach (GameObject levelItem in levelList)
        {
            levelItem.SetActive(false);
        }
    }

    public void backButton()
    {
        SoundPopUp.enabled = false;
        LevelPopUp.enabled = false;
        HowPopUp.enabled = false;
        Title.enabled = true;

        foreach (GameObject menuItem in mainMenuList)
        {
            menuItem.SetActive(true);
        }
        foreach (GameObject playItem in playList)
        {
            playItem.SetActive(false);
        }
        foreach (GameObject soundItem in soundList)
        {
            soundItem.SetActive(false);
        }
        foreach (GameObject howItem in howList)
        {
            howItem.SetActive(false);
        }
        foreach (GameObject levelItem in levelList)
        {
            levelItem.SetActive(false);
        }
    }

    public void soundButton()
    {
        SoundPopUp.enabled = true;
        LevelPopUp.enabled = false;
        HowPopUp.enabled = false;
        Title.enabled = false;

        foreach (GameObject menuItem in mainMenuList)
        {
            menuItem.SetActive(false);
        }
        foreach (GameObject playItem in playList)
        {
            playItem.SetActive(false);
        }
        foreach (GameObject soundItem in soundList)
        {
            soundItem.SetActive(true);
        }
        foreach (GameObject howItem in howList)
        {
            howItem.SetActive(false);
        }
        foreach (GameObject levelItem in levelList)
        {
            levelItem.SetActive(false);
        }
    }

    public void levelButton()
    {
        SoundPopUp.enabled = false;
        LevelPopUp.enabled = true;
        HowPopUp.enabled = false;
        Title.enabled = false;

        foreach (GameObject menuItem in mainMenuList)
        {
            menuItem.SetActive(false);
        }
        foreach (GameObject playItem in playList)
        {
            playItem.SetActive(false);
        }
        foreach (GameObject soundItem in soundList)
        {
            soundItem.SetActive(false);
        }
        foreach (GameObject howItem in howList)
        {
            howItem.SetActive(false);
        }
        foreach (GameObject levelItem in levelList)
        {
            levelItem.SetActive(true);
        }
    }

    public void howButton()
    {
        SoundPopUp.enabled = false;
        LevelPopUp.enabled = false;
        HowPopUp.enabled = true;
        Title.enabled = false;

        foreach (GameObject menuItem in mainMenuList)
        {
            menuItem.SetActive(false);
        }
        foreach (GameObject playItem in playList)
        {
            playItem.SetActive(false);
        }
        foreach (GameObject soundItem in soundList)
        {
            soundItem.SetActive(false);
        }
        foreach (GameObject howItem in howList)
        {
            howItem.SetActive(true);
        }
        foreach (GameObject levelItem in levelList)
        {
            levelItem.SetActive(false);
        }

    }

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
