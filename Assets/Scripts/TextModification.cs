using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextModification : MonoBehaviour
{
    public static TextModification Instance;

    [SerializeField] TMP_Text scoring;
    [SerializeField] TMP_Text Timer;
    int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoring.text = "Kills: " + points.ToString();
    }
    public void AddKill()
    {
        points += 1;
        scoring.text = "Kills: " + points.ToString();
    }
}
