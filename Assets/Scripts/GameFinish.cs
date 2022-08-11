using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public static GameFinish instance;
    [SerializeField] ParticleSystem gameEndParticle;
    [SerializeField] GameObject gameEndMenu;
    [SerializeField] GameObject levelProgress;
    [SerializeField] GameObject nextLevel;
    [SerializeField] GameObject tryAgain;
    [SerializeField] TextMeshProUGUI gameEndText;

    public Text currentLevelText;
    public Text nextLevelText;

    public int currentLevelCount;
    public int nextLevelCount;

    string currentLevelKey = "CurrentLevel";
    string nextLevelKey = "NextLevel";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (!PlayerPrefs.HasKey(currentLevelKey))
        {
            currentLevelCount = 1;
            currentLevelText.text = currentLevelCount.ToString();
            PlayerPrefs.SetInt(currentLevelKey, currentLevelCount);
        }
        else
        {
            currentLevelCount = PlayerPrefs.GetInt(currentLevelKey);
            currentLevelText.text = currentLevelCount.ToString();
        }
        if (!PlayerPrefs.HasKey(nextLevelKey))
        {
            nextLevelCount = 2;
            nextLevelText.text = nextLevelCount.ToString();
            PlayerPrefs.SetInt(nextLevelKey, nextLevelCount);
        }
        else
        {
            nextLevelCount = PlayerPrefs.GetInt(nextLevelKey);
            nextLevelText.text = nextLevelCount.ToString();
        }
    }
    private void Start()
    {
        currentLevelCount = PlayerPrefs.GetInt(currentLevelKey);
        nextLevelCount = PlayerPrefs.GetInt(nextLevelKey);
        currentLevelText.text = currentLevelCount.ToString();
        nextLevelText.text = nextLevelCount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameEndMenu.SetActive(true);
        levelProgress.SetActive(false);
        currentLevelText.gameObject.SetActive(false);
        nextLevelText.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Player"))
        {
            gameEndParticle.Play();
            nextLevel.SetActive(true);
            PlayerCarForward.Instance.forwardMove = false;
            CarAi.Instance.aiForwardMove = false;
            SwerveSystem.Instance1.moveable = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            tryAgain.SetActive(true);
            PlayerCarForward.Instance.forwardMove = false;
            CarAi.Instance.aiForwardMove = false;
            gameEndText.text = "You Lose";
            SwerveSystem.Instance1.moveable = false;
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        currentLevelCount++;
        nextLevelCount++;
        PlayerPrefs.SetInt(currentLevelKey, currentLevelCount);
        PlayerPrefs.SetInt(nextLevelKey, nextLevelCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
