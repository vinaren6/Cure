using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{      


    [Header("Green virus parameters")]
    [SerializeField] float greenSpawnRange = 2f;
    [SerializeField] float greenWaveSpawnTime = 5f;
    [SerializeField] Transform greenParent = null;
    float greenSplitTime = 0f;
    float greenSpawnClock = 0f;

    [Header("Orange virus parameters")]
    [SerializeField] float orangeSpawnRange = 2f;
    [SerializeField] float orangeWaveSpawnTime = 5f;
    [SerializeField] Transform orangeParent = null;
    float orangeSplitTime = 0f;
    float orangeSpawnClock = 0f;

    [Header("Red virus parameters")]
    [SerializeField] float redSpawnRange = 2f;
    [SerializeField] float redWaveSpawnTime = 5f;
    [SerializeField] Transform redParent = null;
    float redSplitTime = 0f;
    float redSpawnClock = 0f;

    [Header("Blue virus parameters")]
    [SerializeField] float blueSpawnRange = 2f;
    [SerializeField] float blueWaveSpawnTime = 5f;
    [SerializeField] Transform blueParent = null;
    float blueSplitTime = 0f;
    float blueSpawnClock = 0f;


    void Start()
    {
        SetVirusSplitTimes();
    }

    private void SetVirusSplitTimes()
    {
        greenSplitTime = greenWaveSpawnTime + Random.Range(-greenSpawnRange, greenSpawnRange + 1);
        orangeSplitTime = orangeWaveSpawnTime + Random.Range(-orangeSpawnRange, orangeSpawnRange + 1);
        redSplitTime = redWaveSpawnTime + Random.Range(-redSpawnRange, redSpawnRange + 1);
        blueSplitTime = blueWaveSpawnTime + Random.Range(-blueSpawnRange, blueSpawnRange + 1);
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
                greenSplitTime = greenWaveSpawnTime + Random.Range(-greenSpawnRange, greenSpawnRange + 1);

                SpreadVirus(greenParent.GetComponentsInChildren<Virus>());
                break;
            case "Orange":
                orangeSpawnClock = Time.time;
                orangeSplitTime = orangeWaveSpawnTime + Random.Range(-orangeSpawnRange, orangeSpawnRange + 1);

                SpreadVirus(orangeParent.GetComponentsInChildren<Virus>());
                break;
            case "Red":
                redSpawnClock = Time.time;
                redSplitTime = redWaveSpawnTime + Random.Range(-redSpawnRange, redSpawnRange + 1);

                SpreadVirus(redParent.GetComponentsInChildren<Virus>());
                break;
            case "Blue":
                blueSpawnClock = Time.time;
                blueSplitTime = blueWaveSpawnTime + Random.Range(-blueSpawnRange, blueSpawnRange + 1);

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
