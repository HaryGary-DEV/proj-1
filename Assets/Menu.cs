using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public Slider slider;
    public float gameTimer = 60;
    float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WinScreen.activeSelf || LoseScreen.activeSelf)
        {
            Debug.LogError(1);
            timer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && WinScreen.activeSelf && timer <= 0 || Input.GetKeyDown(KeyCode.Mouse0) && LoseScreen.activeSelf && timer <= 0)
        {
            SceneManager.LoadScene(0);
        }

        gameTimer -= Time.deltaTime;
        slider.value = gameTimer;
        if (gameTimer <= 0)
        {
            GameObject[] bags = GameObject.FindGameObjectsWithTag("Bag");
            foreach (GameObject bag in bags)
            {
                bag.SetActive(false);
            }
            LoseScreen.SetActive(true);
        }
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
