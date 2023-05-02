using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextModification : MonoBehaviour
{
    [SerializeField] TMP_Text scoring;
    [SerializeField] TMP_Text Timer;
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        scoring = GetComponent<TMP_Text>();
        Timer = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }

    public void UpdatePoints()
    {
        this.points = AIPlayer.points;
        scoring.text = "Kills: " + this.points;
    }

}
