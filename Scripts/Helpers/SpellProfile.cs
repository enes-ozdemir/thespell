using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellProfile", menuName = "ScriptableObjects/SpellProfile", order = 3)]
public class SpellProfile : ScriptableObject
{
    public string Name;
    public SPELL_TYPE Type;
    public SPELL_ELEMENT Element;
    public int Cost;
    public string Animation;

    public GameObject CharacterEffect;
    public string CharacterEffectAttachPoint;
    public int CharacterEffectDestroyTime;

    public GameObject CharacterEffect2;
    public string CharacterEffectAttachPoint2;
    public int CharacterEffectDestroyTime2;

    public GameObject MainEffect;
    public string EffectAttachPoint;
    public int EffectDestroyTime;

    public GameObject AdditionalEffect;
    public string AdditionalEffectAttachPoint;
    public int AdditionalEffectDestroyTime;

}
