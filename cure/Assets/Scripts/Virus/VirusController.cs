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

    [Header("Orange virus parameters")]
    [SerializeField] float orangeMinSpawnTime = 2f;
    [SerializeField] float orangeMaxSpawnTime = 5f;
    [SerializeField] Transform orangeParent = null;
    float orangeSplitTime = 0f;

    [Header("Red virus parameters")]
    [SerializeField] float redMinSpawnTime = 2f;
    [SerializeField] float redMaxSpawnTime = 5f;
    [SerializeField] Transform redParent = null;
    float redSplitTime = 0f;

    [Header("Blue virus parameters")]
    [SerializeField] float blueMinSpawnTime = 2f;
    [SerializeField] float blueMaxSpawnTime = 5f;
    [SerializeField] Transform blueParent = null;
    float blueSplitTime = 0f;


    void Start()
    {
        SetGreenSplitTime();
        SetOrangeSplitTime();
        SetRedSplitTime();
        SetBlueSplitTime();
    }

    private void SetGreenSplitTime()
    {
        greenSplitTime = SetRandomTime(greenMinSpawnTime, greenMaxSpawnTime);
    }
    private void SetOrangeSplitTime()
    {
        orangeSplitTime = SetRandomTime(orangeMinSpawnTime , orangeMaxSpawnTime);
    }
    private void SetRedSplitTime()
    {
        redSplitTime = SetRandomTime(redMinSpawnTime, redMaxSpawnTime);
    }
    private void SetBlueSplitTime()
    {
        blueSplitTime = SetRandomTime(blueMinSpawnTime, blueMaxSpawnTime);
    }

    private float SetRandomTime(float min, float max)
    {
        return Random.Range(min, max + 1) + Time.time;
    }

    private void FixedUpdate()
    {
        if (greenSplitTime < Time.time)
        {
            SpreadVirus(greenParent.GetComponentsInChildren<Virus>());
            SetGreenSplitTime();
        }
        if (orangeSplitTime < Time.time)
        {
            SpreadVirus(orangeParent.GetComponentsInChildren<Virus>());
            SetOrangeSplitTime();
        }
        if (redSplitTime < Time.time)
        {
            SpreadVirus(redParent.GetComponentsInChildren<Virus>());
            SetRedSplitTime();
        }
        if (blueSplitTime < Time.time)
        {
            SpreadVirus(blueParent.GetComponentsInChildren<Virus>());
            SetBlueSplitTime();
        }
    }

    private void SpreadVirus(Virus[] virions)
    {
        for (int i = 0; i < virions.Length; i++)
        {
            if (virions[i] != null)
                virions[i].SplitCell();
        }
    }
}
