using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStore : MonoBehaviour
{
    [SerializeField]
    private SpellProfile[] spellProfiles;
    private static Dictionary<string, SpellProfile> spellDictionary = new Dictionary<string, SpellProfile>();


    void Start()
    {
        for (int i = 0; i < spellProfiles.Length; i++)
        {
            spellDictionary.Add(spellProfiles[i].Name, spellProfiles[i]);
        }
    }

    public static RFX4_EffectEvent GetSpell(GameObject player, string spellName)
    {
        RFX4_EffectEvent spell = player.GetComponent<RFX4_EffectEvent>();
        SpellProfile spellProfile;

        spellDictionary.TryGetValue(spellName, out spellProfile);

        if (spellProfile == null) return null;

        spell.CharacterEffect = spellProfile.CharacterEffect;
        spell.CharacterAttachPoint = GameObject.FindGameObjectWithTag(spellProfile.CharacterEffectAttachPoint).transform;
        
        spell.CharacterEffect_DestroyTime = spellProfile.CharacterEffectDestroyTime;

        spell.CharacterEffect2 = spellProfile.CharacterEffect2;
        spell.CharacterAttachPoint2 = GameObject.FindGameObjectWithTag(spellProfile.CharacterEffectAttachPoint2).transform;
        
        spell.CharacterEffect2_DestroyTime = spellProfile.CharacterEffectDestroyTime2;

        spell.MainEffect = spellProfile.MainEffect;
        spell.AttachPoint = GameObject.FindGameObjectWithTag(spellProfile.EffectAttachPoint).transform;
        spell.Effect_DestroyTime = spellProfile.EffectDestroyTime;

        //spell.AdditionalEffect = spellProfile.AdditionalEffect;
        //spell.AdditionalEffectAttachPoint = player.transform.Find(spellProfile.AdditionalEffectAttachPoint);
        //spell.AdditionalEffect_DestroyTime = spellProfile.AdditionalEffectDestroyTime;



        return spell;
    }

    public static SpellInfo GetInfo(String spellName)
    {
        SpellInfo info = new SpellInfo();
        SpellProfile spellProfile;

        spellDictionary.TryGetValue(spellName, out spellProfile);
        if (spellProfile == null) return null;

        info.Name = spellProfile.Name;
        info.Type = spellProfile.Type;
        info.Element = spellProfile.Element;
        info.Cost = spellProfile.Cost;
        info.Animation = spellProfile.Animation;

        return info;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

public class SpellInfo
{
    public string Name { get; set; }
    public SPELL_TYPE Type { get; set; }
    public SPELL_ELEMENT Element { get; set; }
    public int Cost { get; set; }
    public String Animation { get; set; }
}
