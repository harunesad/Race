using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameEndMenu.SetActive(true);
        levelProgress.SetActive(false);
        if (other.gameObject.CompareTag("Player"))
        {
            gameEndParticle.Play();
            nextLevel.SetActive(true);
            PlayerCarForward.Instance.forwardMove = false;
            CarAi.Instance.aiForwardMove = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            tryAgain.SetActive(true);
            PlayerCarForward.Instance.forwardMove = false;
            CarAi.Instance.aiForwardMove = false;
            Debug.Log("ai win");
            gameEndText.text = "You Lose";
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
