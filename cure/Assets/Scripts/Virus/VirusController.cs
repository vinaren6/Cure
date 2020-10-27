using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{      
    [Header("Green virus parameters")]
    [SerializeField] float greenMinSpreadTime = 2f;
    [SerializeField] float greenMaxSpreadTime = 5f;
    [SerializeField] Transform greenParent = null;
    float greenSplitTime = 0f;

    [Header("Orange virus parameters")]
    [SerializeField] float orangeMinSpreadTime = 2f;
    [SerializeField] float orangeMaxSpreadTime = 5f;
    [SerializeField] Transform orangeParent = null;
    float orangeSplitTime = 0f;

    [Header("Red virus parameters")]
    [SerializeField] float redMinSpreadTime = 2f;
    [SerializeField] float redMaxSpreadTime = 5f;
    [SerializeField] Transform redParent = null;
    float redSplitTime = 0f;

    [Header("Blue virus parameters")]
    [SerializeField] float blueMinSpreadTime = 2f;
    [SerializeField] float blueMaxSpreadTime = 5f;
    [SerializeField] Transform blueParent = null;
    float blueSplitTime = 0f;

    [Header("Testing mode")]
    [Tooltip("Setting this to true will disable the spliting of the virus allowing for a controlled test environment.")]
    [SerializeField] bool testing = false;

    private void Start()
    {
        SetGreenSplitTime();
        SetOrangeSplitTime();
        SetRedSplitTime();
        SetBlueSplitTime();
    }

    private void SetGreenSplitTime()
    {
        greenSplitTime = SetRandomTime(greenMinSpreadTime, greenMaxSpreadTime);
    }
    private void SetOrangeSplitTime()
    {
        orangeSplitTime = SetRandomTime(orangeMinSpreadTime , orangeMaxSpreadTime);
    }
    private void SetRedSplitTime()
    {
        redSplitTime = SetRandomTime(redMinSpreadTime, redMaxSpreadTime);
    }
    private void SetBlueSplitTime()
    {
        blueSplitTime = SetRandomTime(blueMinSpreadTime, blueMaxSpreadTime);
    }

    private float SetRandomTime(float min, float max)
    {
        return Random.Range(min, max + 1) + Time.time;
    }

    private void FixedUpdate()
    {
        if(testing) { return; }
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
