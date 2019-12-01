using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private RFX4_EffectEvent effect;
    private Animator animator;
    private Player player;
    private bool animationCheck = true;
    void Start()
    {
        effect = GetComponent<RFX4_EffectEvent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.PressedKey(KeyCode.F1))
        {
            SpellStore.spellDictionary.TryGetValue("Spell16", out GameController.CurrentSpell);
            DoSpell("Spell16");
        }
        else if (InputManager.PressedKey(KeyCode.F2))
        {
            Debug.Log("1. Büyüyü çağırdın F2 ile");
            SpellStore.spellDictionary.TryGetValue("FirstSpell", out GameController.CurrentSpell);
            DoSpell("FirstSpell");
        }

        else if (InputManager.PressedKey(KeyCode.F3))
        {
            SpellStore.spellDictionary.TryGetValue("Spell7", out GameController.CurrentSpell);
            DoSpell("Spell7");
        }

        else if (InputManager.PressedKey(KeyCode.F4))
        {
            SpellStore.spellDictionary.TryGetValue("Spell22", out GameController.CurrentSpell);
            DoSpell("Spell22");
        }

    }

    void DoSpell(string spellname)
    {
        RFX4_EffectEvent effect = SpellStore.GetSpell(gameObject, spellname);
        SpellInfo info = SpellStore.GetInfo(spellname);
        this.effect.CharacterEffect = effect.CharacterEffect;
        this.effect.CharacterAttachPoint = effect.CharacterAttachPoint;
        this.effect.CharacterAttachPoint2 = effect.CharacterAttachPoint2;
        this.effect.CharacterEffect_DestroyTime = effect.CharacterEffect_DestroyTime;
        this.effect.CharacterEffect2_DestroyTime = effect.CharacterEffect2_DestroyTime;
        this.effect.MainEffect = effect.MainEffect;
        this.effect.AttachPoint = effect.AttachPoint;
        animator.SetTrigger(info.Animation);
    }
}
