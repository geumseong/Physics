using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool paused = false;

    public GameObject timerObject;
    public int timeLeft;

    public GameObject enemy;
    float maxHeight = 2.7f;
    float minHeight = -2.7f;
    float xAxisSpawnPoint = 7.2f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(SpawnEnemy());
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            OnPressESC();
        }
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            yield return new WaitForSeconds(3f);
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(xAxisSpawnPoint, Random.Range(minHeight, maxHeight), 0);
        }
    }

    IEnumerator StartTimer() {
        while(true) {
            timerObject.GetComponent<Text>().text = "" + timeLeft;
            yield return new WaitForSeconds(1f);
            timeLeft--;
            if(timeLeft == 0) {
                SceneManager.LoadScene("Victory");
            }
        }
    }

    public void OnPressESC() {
        if(paused == true) {
            paused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else {
            paused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
