// Code writer: Nicklas 
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{   
    [Header("Green virus parameters")]
    [SerializeField] float greenMinSplitTime = 2f;
    [SerializeField] float greenMaxSplitTime = 5f;
    float greenSplitTime = 0f;

    [Header("Orange virus parameters")]
    [SerializeField] float orangeMinSplitTime = 2f;
    [SerializeField] float orangeMaxSplitTime = 5f;
    float orangeSplitTime = 0f;

    [Header("Red virus parameters")]
    [SerializeField] float redMinSplitTime = 2f;
    [SerializeField] float redMaxSplitTime = 5f;
    float redSplitTime = 0f;

    [Header("Blue virus parameters")]
    [SerializeField] float blueMinSplitTime = 2f;
    [SerializeField] float blueMaxSplitTime = 5f;
    float blueSplitTime = 0f;

    [Header("Testing mode")]
    [Tooltip("Setting this to true will disable the splitting of the virus " +
    "allowing for a controlled test environment.")]
    [SerializeField] bool testing = false;

    [SerializeField] int maxiumumVirions = 800;

    int virionCount = 0;

    List<Virus>[] viruses = new List<Virus>[] 
    {
        new List<Virus>(),
        new List<Virus>(),
        new List<Virus>(),
        new List<Virus>()
    };

    private void Start()
    {
        testing = false;
        SetSplitTimes();
    }

    private void FixedUpdate()
    {
        if(testing) 
        {
            SetSplitTimes();
            return; 
        }

        virionCount = GetTotalVirions();

        if (greenSplitTime < Time.time)
        {
            SplitVirions(viruses[0]);
            greenSplitTime = SetNextSplitTime(greenMinSplitTime, greenMaxSplitTime);
        }
        if (orangeSplitTime < Time.time)
        {
            SplitVirions(viruses[1]);
            orangeSplitTime = SetNextSplitTime(orangeMinSplitTime, orangeMaxSplitTime);
        }
        if (redSplitTime < Time.time)
        {
            SplitVirions(viruses[2]);
            redSplitTime = SetNextSplitTime(redMinSplitTime, redMaxSplitTime);
        }
        if (blueSplitTime < Time.time)
        {
            SplitVirions(viruses[3]);
            blueSplitTime = SetNextSplitTime(blueMinSplitTime, blueMaxSplitTime);
        }
    }

    private int GetTotalVirions()
    {
        return GetNumberOfVirions(0) + GetNumberOfVirions(1) + GetNumberOfVirions(2) + GetNumberOfVirions(3);
    }

    private float SetNextSplitTime(float min, float max)
    {
        return Random.Range(min, max + 1) + Time.time;
    }
    private void SetSplitTimes()
    {
        greenSplitTime = SetNextSplitTime(greenMinSplitTime, greenMaxSplitTime);
        orangeSplitTime = SetNextSplitTime(orangeMinSplitTime, orangeMaxSplitTime);
        redSplitTime = SetNextSplitTime(redMinSplitTime, redMaxSplitTime);
        blueSplitTime = SetNextSplitTime(blueMinSplitTime, blueMaxSplitTime);
    }

    private void SplitVirions (List<Virus> virions)
    {
        virions.RemoveAll(Virus => Virus == null);
        foreach (Virus virus in virions)
        {
            if(virionCount >= maxiumumVirions)
            {
                continue;
            }
            virus.SplitCell();
        }
    }

    public void AddToVirionList(Virus virus, Type type)
    {
        switch(type)
        {
            case Type.Green:
                viruses[0].Add(virus);
                break;
            case Type.Orange:
                viruses[1].Add(virus);
                break;
            case Type.Red:
                viruses[2].Add(virus);
                break;
            case Type.Blue:
                viruses[3].Add(virus);
                break;
        }
    }


    public int GetNumberOfVirions(int index)
    {
        viruses[index].RemoveAll(Virus => Virus == null);
        return viruses[index].Count;
    }
}
