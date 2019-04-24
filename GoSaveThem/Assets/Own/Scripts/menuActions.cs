using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuActions : MonoBehaviour
{
    public List<GameObject> mainMenuList, playList, soundList, howList, levelList, levelNumList;
    public Image Title, SoundPopUp, LevelPopUp, HowPopUp;
    public GameObject Disclaimer, StartBtn, SoundBtn, HowBtn;
    public GameObject Level1, Level2, Level3, BackBtn, Level1StartBtn, Level2StartBtn, LevelCancelBtn, Lock3, LevelNumber1, LevelNumber2;
    public GameObject MusicTxt, MusicSlider, VoiceTxt, VoiceSlider, SoundSaveBtn, SoundCancelBtn;
    public GameObject HowScrollView, HowCloseBtn;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuList = new List<GameObject>() { StartBtn, SoundBtn, HowBtn };
        playList = new List<GameObject>() { Level1, Level2, Level3, BackBtn, Lock3};
        soundList = new List<GameObject>() { MusicTxt, MusicSlider, VoiceTxt, VoiceSlider, SoundSaveBtn, SoundCancelBtn };
        howList = new List<GameObject>() { HowScrollView, HowCloseBtn };
        levelList = new List<GameObject>() { Level1StartBtn, Level2StartBtn, LevelCancelBtn };
        levelNumList = new List<GameObject>() { LevelNumber1, LevelNumber2 };

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
        foreach (GameObject levelNum in levelNumList)
        {
            levelNum.SetActive(false);
        }
    }

    public void PlayButton()
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

    public void BackButton()
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
        foreach (GameObject levelNum in levelNumList)
        {
            levelNum.SetActive(false);
        }
    }

    public void SoundButton()
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

    public void LevelButton(int levelNumber)
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

        LevelCancelBtn.SetActive(true);

        if (levelNumber == 1)
        {
            LevelNumber1.SetActive(true);
            Level1StartBtn.SetActive(true);

        }
        else if (levelNumber == 2)
        {
            LevelNumber2.SetActive(true);
            Level2StartBtn.SetActive(true);

        }
    }

    public void HowButton()
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

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
