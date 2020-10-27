using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{      
    [Header("Green virus parameters")]
    [SerializeField] float greenMinSpawnTime = 2f;
    [SerializeField] float greenMaxSpawnTime = 5f;
    [SerializeField] Transform greenParent = null;
    float greenSplitTime = 0f;
    float greenSpawnClock = 0f;

    [Header("Orange virus parameters")]
    [SerializeField] float orangeMinSpawnTime = 2f;
    [SerializeField] float orangeMaxSpawnTime = 5f;
    [SerializeField] Transform orangeParent = null;
    float orangeSplitTime = 0f;
    float orangeSpawnClock = 0f;

    [Header("Red virus parameters")]
    [SerializeField] float redMinSpawnTime = 2f;
    [SerializeField] float redMaxSpawnTime = 5f;
    [SerializeField] Transform redParent = null;
    float redSplitTime = 0f;
    float redSpawnClock = 0f;

    [Header("Blue virus parameters")]
    [SerializeField] float blueMinSpawnTime = 2f;
    [SerializeField] float blueMaxSpawnTime = 5f;
    [SerializeField] Transform blueParent = null;
    float blueSplitTime = 0f;
    float blueSpawnClock = 0f;


    void Start()
    {
        SetVirusSplitTimes();
    }

    private void SetVirusSplitTimes()
    {
        greenSplitTime = Random.Range(greenMinSpawnTime, greenMaxSpawnTime + 1);
        orangeSplitTime = Random.Range(orangeMinSpawnTime, orangeMaxSpawnTime + 1);
        redSplitTime = Random.Range(redMinSpawnTime, redMaxSpawnTime + 1);
        blueSplitTime = Random.Range(blueMinSpawnTime, blueMaxSpawnTime + 1);
    }

    private void FixedUpdate()
    {
        SplitViruses();
    }

    private void SplitViruses()
    {
        if (greenSpawnClock + greenSplitTime < Time.time)
        {
            InitializeSpreadOfVirus("Green");
        }
        if (orangeSpawnClock + orangeSplitTime < Time.time)
        {
            InitializeSpreadOfVirus("Orange");
        }
        if (redSpawnClock + redSplitTime < Time.time)
        {
            InitializeSpreadOfVirus("Red");
        }
        if (blueSpawnClock + blueSplitTime < Time.time)
        {
            InitializeSpreadOfVirus("Blue");
        }
    }

    private void InitializeSpreadOfVirus(string typeToSpread)
    {
        switch(typeToSpread)
        {
            case "Green":
                greenSpawnClock = Time.time;
                greenSplitTime = Random.Range(greenMinSpawnTime, greenMaxSpawnTime + 1);

                SpreadVirus(greenParent.GetComponentsInChildren<Virus>());
                break;
            case "Orange":
                orangeSpawnClock = Time.time;
                orangeSplitTime = Random.Range(orangeMinSpawnTime, orangeMaxSpawnTime + 1);

                SpreadVirus(orangeParent.GetComponentsInChildren<Virus>());
                break;
            case "Red":
                redSpawnClock = Time.time;
                redSplitTime = Random.Range(redMinSpawnTime, redMaxSpawnTime + 1);

                SpreadVirus(redParent.GetComponentsInChildren<Virus>());
                break;
            case "Blue":
                blueSpawnClock = Time.time;
                blueSplitTime = Random.Range(blueMinSpawnTime, blueMaxSpawnTime + 1);

                SpreadVirus(blueParent.GetComponentsInChildren<Virus>());
                break;
        }
    }

    private void SpreadVirus(Virus[] viruses)
    {
        for (int i = 0; i < viruses.Length; i++)
        {
            if (viruses[i] != null)
                viruses[i].SplitCell();
        }
    }
}
