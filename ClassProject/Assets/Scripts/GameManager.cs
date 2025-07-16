using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Game Variable")]
    public PlayerController player;
    public float time;
    public bool timeActive;

    [Header("Game UI")]
    public TMP_Text gameUI_score;
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_time;

    [Header("Countdown UI")]
    public TMP_Text countdownText;
    public int countdown;

    [Header("EndScreen UI")]
    public TMP_Text endUI_score;
    public TMP_Text endUI_time;

    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;
    public GameObject endUI;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        // make sure the timer is set to 0
        time = 0;

        // disable player movement initially
        player.enabled = false;

        // set screen to the countdown
        SetScreen(countdownUI);

        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        countdownText.gameObject.SetActive(true);
        countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }

        countdownText.text = "go";
        yield return new WaitForSeconds(1f);

        player.enabled = true;

        startGame();


    }

    void startGame()
    {
        SetScreen(gameUI);

        timeActive = true;

    }
    public void endGame()
    {
        timeActive = false;
        player.enabled = false;

        // set UI to display stats
        endUI_score.text = "Score: " + player.coinCount;
        endUI_time.text = "Time: " + (time * 10).ToString("F2");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SetScreen(endUI);

    }

    public void OnRestartButton()
    {
        // restart the scene to play again
        SceneManager.LoadScene(0);
    }



    // Update is called once per frame
    void Update()
    {
        if(timeActive)
        {
            time = time + Time.deltaTime;

        }

        // set the UI to dislay stats
        gameUI_score.text = "Coins: " + player.coinCount;
        gameUI_health.text = "Health: " + player.health;
        gameUI_time.text = "Time: " + (time * 10).ToString("F2");
    }

    public void SetScreen(GameObject screen)
    {
        // diable all other screens
        gameUI.SetActive(false);
        countdownUI.SetActive(false);
        endUI.SetActive(false);

        // activate requested screen
        screen.SetActive(true);

    }
}
