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
    [Tooltip("Setting this to true will disable the spliting of the virus allowing for a controlled test environment.")]
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
        if(testing) { return; }
        if (greenSplitTime < Time.time)
        {
            SpreadVirus(greenVirions);
            greenSplitTime = SetNextSplitTime(greenMinSplitTime, greenMaxSplitTime);
        }
        if (orangeSplitTime < Time.time)
        {
            SpreadVirus(orangeVirions);
            orangeSplitTime = SetNextSplitTime(orangeMinSplitTime, orangeMaxSplitTime);
        }
        if (redSplitTime < Time.time)
        {
            SpreadVirus(redVirions);
            redSplitTime = SetNextSplitTime(redMinSplitTime, redMaxSplitTime);
        }
        if (blueSplitTime < Time.time)
        {
            SpreadVirus(blueVirions);
            blueSplitTime = SetNextSplitTime(blueMinSplitTime, blueMaxSplitTime);
        }
    }

    private float SetNextSplitTime(float min, float max)
    {
        return Random.Range(min, max + 1) + Time.time;
    }

    private void SpreadVirus(List<Virus> virions)
    {
        virions.RemoveAll(Virus => Virus == null);
        foreach (Virus virus in virions)
        {
            virus.SplitCell();
        }
    }

    public void AddToVirionList(Virus virus, VirusType virusType)
    {
        switch(virusType)
        {
            case VirusType.Green:
                greenVirions.Add(virus);
                break;
            case VirusType.Orange:
                orangeVirions.Add(virus);
                break;
            case VirusType.Red:
                redVirions.Add(virus);
                break;
            case VirusType.Blue:
                blueVirions.Add(virus);
                break;
        }
    }

    public void RemoveFromVirionsList(Virus virus,VirusType virusType)
    {
        switch (virusType)
        {
            case VirusType.Green:
                greenVirions.Remove(virus);
                break;
            case VirusType.Orange:
                orangeVirions.Remove(virus);
                break;
            case VirusType.Red:
                redVirions.Remove(virus);
                break;
            case VirusType.Blue:
                blueVirions.Remove(virus);
                break;
        }
    }
}
