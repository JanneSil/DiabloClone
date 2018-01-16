using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour {

    public int CurrentLevel;
    public int BaseXP = 20;
    public int CurrentXP;

    public int XPForNextLevel;
    public int XPDifferenceToNextLevel;
    public int TotalXPDifference;

    public float FillAmount;
    //public float ReversedFillAmount;

    public int StatPoints;
    public int SkillPoints;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("AddXP",1f,1f);
	}
	
    public void AddXP()
    {
        CalculateLevel(5);
    }

    void CalculateLevel(int amount)
    {
        CurrentXP += amount;

        int temp_cur_lvl = (int)Mathf.Sqrt(CurrentXP / BaseXP)+1;

        if (CurrentLevel != temp_cur_lvl)
        {
            CurrentLevel = temp_cur_lvl;
        }

        XPForNextLevel = BaseXP * CurrentLevel * CurrentLevel;
        XPDifferenceToNextLevel = XPForNextLevel - CurrentXP;
        TotalXPDifference = XPForNextLevel - (BaseXP * (CurrentLevel - 1) * (CurrentLevel - 1));

        FillAmount = 1 - ((float)XPDifferenceToNextLevel / (float)TotalXPDifference);
        //ReversedFillAmount = 1 - FillAmount;

        StatPoints = 5 * (CurrentLevel - 1);
        SkillPoints = 15 * (CurrentLevel - 1);
    }

}
