using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseClass

{
    public enum genders
    {
        MALE,
        FEMALE
    }

    [Header("Infos")]
    public string MyName;
    public int CurrentLevel;
    public int CurrentXP;
    [Header("Health & Mana")]
    public int CurrentHealth;
    public int MaximumHealth;
    public int CurrentMana;
    public int MaximumMana;

    [Header("Gender")]
    public genders gender; 

    [Header("Stats")]
    public int Strength;
    public int Endurance;
    public int Agility;
    public int Wisdom;
    public int Intelligence;

    [Header("Skills")]
    public int StatPoints;
    public int SkillPoints;
    //List of current skills

}
