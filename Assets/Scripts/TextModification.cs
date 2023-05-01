using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextModification : MonoBehaviour
{
    public static float points;
    [SerializeField] TMP_Text scoring;
    [SerializeField] TMP_Text Timer;
    private AIPlayer ai;
    // Start is called before the first frame update
    void Start()
    {
        scoring = GetComponent<TMP_Text>();
        Timer = GetComponent<TMP_Text>();
        ai = GetComponent<AIPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        scoring.text = "Kills: " + points;

    }

}
