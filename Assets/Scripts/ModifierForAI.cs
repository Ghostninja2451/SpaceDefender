using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierForAI : MonoBehaviour
{
    [SerializeField] float countDown;
    private float newHealthMod;
    private float newSpeedMod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0)
        {
            Modificaiton(.1f, .1f);
            countDown = 60f;
        }
        countDown -= Time.deltaTime;
    }


    public void Modificaiton(float healthMod, float speedMod)
    {
        Debug.Log("Upgrade");
        AIPlayer.instance.maxhealth += AIPlayer.instance.maxhealth * healthMod;

        AIPlayer.instance.maxSpeed += AIPlayer.instance.maxSpeed * speedMod;

        Debug.Log(newSpeedMod.ToString());
        Debug.Log(newHealthMod.ToString());
        Debug.Log(AIPlayer.instance.maxSpeed.ToString());
        Debug.Log(AIPlayer.instance.maxhealth.ToString());
    }
}
