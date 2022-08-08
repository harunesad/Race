using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress instance;

    [SerializeField] Image levelBar;
    [SerializeField] GameObject playerCar;
    [SerializeField] GameObject finishLine;
    [SerializeField] float distance;
    [SerializeField] float distanceUpdate;

    //public Text currentLevelText;
    //public Text nextLevelText;

    //public int currentLevel;
    //public int nextLevel;

    //string currentLevelKey = "CurrentLevel";
    //string nextLevelKey = "NextLevel";
    private void Awake()
    {
        instance = this;
        //if (!PlayerPrefs.HasKey(currentLevelKey))
        //{
        //    currentLevelText.text = "1";
        //}
        //else
        //{
        //    currentLevel = PlayerPrefs.GetInt(currentLevelKey);

        //}
        //if (!PlayerPrefs.HasKey(nextLevelKey))
        //{
        //    currentLevelText.text = "2";
        //}
        //else
        //{
        //    currentLevel = PlayerPrefs.GetInt(nextLevelKey);

        //}
    }
    void Start()
    {
        distance = finishLine.transform.position.z - playerCar.transform.position.z;
        //PlayerPrefs.SetInt(currentLevelKey, currentLevel);
        //PlayerPrefs.SetInt(nextLevelKey, nextLevel);
    }
    void Update()
    {
        distanceUpdate = distance / playerCar.transform.position.z;
        levelBar.fillAmount =  1 / Mathf.Abs(distanceUpdate);
    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
