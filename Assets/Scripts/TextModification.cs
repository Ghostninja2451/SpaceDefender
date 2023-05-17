using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextModification : MonoBehaviour
{
    public static TextModification Instance;
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    [SerializeField] TMP_Text scoring;
    [SerializeField] TMP_Text Timer;
    [SerializeField] TMP_Text mod;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoring.text = "Kills: " + points.ToString();
        if (timeIsRunning)
        {
            timeRemaining += Time.deltaTime;
            displayTime(timeRemaining);

        }
        displayModifier();
    }
    public void AddKill()
    {
        points += 1;
        scoring.text = "Kills: " + points.ToString();
    }
    public void displayTime(float timedisplay)
    {
        timedisplay += 1;
        float minutes = Mathf.FloorToInt(timedisplay / 60);
        float seconds = Mathf.FloorToInt(timedisplay % 60);
        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    public void displayModifier()
    {
        mod.text = "Mod \n" + "Health: " + AIPlayer.instance.maxhealth.ToString() + "\n" + "Speep: " + AIPlayer.instance.maxSpeed.ToString();
    }
}
