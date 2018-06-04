using Assets.Scripts.Buffs;
using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill {
    public string Name;
    public SkillType Type;
    public string Description;
    public int CostMana;
    public int CostHealth;
    public Dictionary<Buff,bool> Buffs;
    public Dictionary<Debuff,bool> Debuffs;

}
