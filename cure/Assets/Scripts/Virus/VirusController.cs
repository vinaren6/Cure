using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{      
    [Header("Green virus parameters")]
    [SerializeField] float greenMinSplitTime = 2f;
    [SerializeField] float greenMaxSplitTime = 5f;
    List<Virus> greenVirions = new List<Virus>();
    float greenSplitTime = 0f;

    [Header("Orange virus parameters")]
    [SerializeField] float orangeMinSplitTime = 2f;
    [SerializeField] float orangeMaxSplitTime = 5f;
    List<Virus> orangeVirions = new List<Virus>();
    float orangeSplitTime = 0f;

    [Header("Red virus parameters")]
    [SerializeField] float redMinSplitTime = 2f;
    [SerializeField] float redMaxSplitTime = 5f;
    List<Virus> redVirions = new List<Virus>();
    float redSplitTime = 0f;

    [Header("Blue virus parameters")]
    [SerializeField] float blueMinSplitTime = 2f;
    [SerializeField] float blueMaxSplitTime = 5f;
    List<Virus> blueVirions = new List<Virus>();
    float blueSplitTime = 0f;

    [Header("Testing mode")]
    [Tooltip("Setting this to true will disable the splitting of the virus " +
        "allowing for a controlled test environment.")]
    [SerializeField] bool testing = false;

    private void Start()
    {
        greenSplitTime = SetNextSplitTime(greenMinSplitTime, greenMaxSplitTime);
        orangeSplitTime = SetNextSplitTime(orangeMinSplitTime, orangeMaxSplitTime);
        redSplitTime = SetNextSplitTime(redMinSplitTime, redMaxSplitTime);
        blueSplitTime = SetNextSplitTime(blueMinSplitTime, blueMaxSplitTime);
    }

    private void FixedUpdate()
    {
        if(testing) 
        {
            greenSplitTime = SetNextSplitTime(greenMinSplitTime, greenMaxSplitTime);
            orangeSplitTime = SetNextSplitTime(orangeMinSplitTime, orangeMaxSplitTime);
            redSplitTime = SetNextSplitTime(redMinSplitTime, redMaxSplitTime);
            blueSplitTime = SetNextSplitTime(blueMinSplitTime, blueMaxSplitTime);
            return; 
        }
        if (greenSplitTime < Time.time)
        {
            SplitVirions(greenVirions);
            greenSplitTime = SetNextSplitTime(greenMinSplitTime, greenMaxSplitTime);
        }
        if (orangeSplitTime < Time.time)
        {
            SplitVirions(orangeVirions);
            orangeSplitTime = SetNextSplitTime(orangeMinSplitTime, orangeMaxSplitTime);
        }
        if (redSplitTime < Time.time)
        {
            SplitVirions(redVirions);
            redSplitTime = SetNextSplitTime(redMinSplitTime, redMaxSplitTime);
        }
        if (blueSplitTime < Time.time)
        {
            SplitVirions(blueVirions);
            blueSplitTime = SetNextSplitTime(blueMinSplitTime, blueMaxSplitTime);
        }
    }

    private float SetNextSplitTime(float min, float max)
    {
        return Random.Range(min, max + 1) + Time.time;
    }

    private void SplitVirions (List<Virus> virions)
    {
        virions.RemoveAll(Virus => Virus == null);
        foreach (Virus virus in virions)
        {
            virus.SplitCell();
        }
    }

    public void AddToVirionList(Virus virus, Type type)
    {
        switch(type)
        {
            case Type.Green:
                greenVirions.Add(virus);
                break;
            case Type.Orange:
                orangeVirions.Add(virus);
                break;
            case Type.Red:
                redVirions.Add(virus);
                break;
            case Type.Blue:
                blueVirions.Add(virus);
                break;
        }
    }
}
