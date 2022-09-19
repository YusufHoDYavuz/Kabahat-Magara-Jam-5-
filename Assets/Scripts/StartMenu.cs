using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject contentImage, contentSelected, contentInContent, teamImage, teamSelected, teamInContent;
    [SerializeField] Slider volumeSlider;
    public Text soundTextValue;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ControllerContent()
    {
        ControllerOpen();
        TeamClose();
    }

    public void TeamContent()
    {
        ControllerClose();
        TeamOpen();
    }

    void ControllerOpen()
    {
        contentImage.SetActive(true);
        contentSelected.SetActive(true);
        contentInContent.SetActive(true);
        contentImage.gameObject.transform.DOScale(new Vector3(13, 10, 1), 0.75f).SetEase(Ease.InOutBack).OnComplete(()=> {
            contentInContent.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.InOutBack);
        });
        contentSelected.gameObject.transform.DOScale(new Vector3(2, 0.075f, 0), 1);
    }
    
    void ControllerClose()
    {
        contentImage.gameObject.transform.DOScale(new Vector3(0, 0, 1), 0.4f);
        contentInContent.gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.05f);
        contentSelected.gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.4f);
    }
    
    void TeamOpen()
    {
        teamImage.SetActive(true);
        teamSelected.SetActive(true);
        teamInContent.SetActive(true);
        teamImage.gameObject.transform.DOScale(new Vector3(13, 10, 1), 0.75f).SetEase(Ease.InOutBack).OnComplete(()=> {
            teamInContent.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.InOutBack);
        });
        teamSelected.gameObject.transform.DOScale(new Vector3(2, 0.075f, 0), 1);
    }
    
    void TeamClose()
    {
        teamImage.gameObject.transform.DOScale(new Vector3(0, 0, 1), 0.4f);
        teamInContent.gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        teamSelected.gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.4f);
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    void Start()
    {
        if (!PlayerPrefs.HasKey("volumeSlider"))
        {
            PlayerPrefs.SetFloat("volumeSlider", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        soundTextValue.text = Mathf.RoundToInt(volumeSlider.value * 100) + "%";
        Save();
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeSlider");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("volumeSlider", volumeSlider.value);
    }
}

