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
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        distance = finishLine.transform.position.z - playerCar.transform.position.z;
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
