using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private RFX4_EffectEvent _effect;
    private Animator animator;
    private bool animationCheck = true;
    void Start()
    {
        _effect = GetComponent<RFX4_EffectEvent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (InputManager.PressedKey(KeyCode.F1))
        {
            SpellStore.spellDictionary.TryGetValue("SecondSpell", out GameController.CurrentSpell);
            DoSpell("SecondSpell");
        }
        else if (InputManager.PressedKey(KeyCode.F2))
        {
            Debug.Log("1. Büyüyü çağırdın F2 ile");
            SpellStore.spellDictionary.TryGetValue("FirstSpell", out GameController.CurrentSpell);
            DoSpell("FirstSpell");
        }
        else if (InputManager.PressedKey(KeyCode.F3))
        {
            SpellStore.spellDictionary.TryGetValue("ThirdSpell", out GameController.CurrentSpell);
            DoSpell("ThirdSpell");
        }
        else if (InputManager.PressedKey(KeyCode.F4))
        {
            SpellStore.spellDictionary.TryGetValue("FourthSpell", out GameController.CurrentSpell);
            DoSpell("FourthSpell");
        }
        else if (InputManager.PressedKey(KeyCode.F5))
        {
            SpellStore.spellDictionary.TryGetValue("FifthSpell", out GameController.CurrentSpell);
            DoSpell("FifthSpell");
        }
    }

    void DoSpell(string spellname)
    {
        if (GameController.Player.ManaCost(GameController.CurrentSpell.Cost))
        {
            RFX4_EffectEvent effect = SpellStore.GetSpell(gameObject, spellname);
            SpellInfo info = SpellStore.GetInfo(spellname);
            _effect.CharacterEffect = effect.CharacterEffect;
            _effect.CharacterAttachPoint = effect.CharacterAttachPoint;
            _effect.CharacterAttachPoint2 = effect.CharacterAttachPoint2;
            _effect.CharacterEffect_DestroyTime = effect.CharacterEffect_DestroyTime;
            _effect.CharacterEffect2_DestroyTime = effect.CharacterEffect2_DestroyTime;
            _effect.MainEffect = effect.MainEffect;
            _effect.AttachPoint = effect.AttachPoint;
            _effect.AdditionalEffect = effect.AdditionalEffect;
            _effect.AdditionalEffectAttachPoint = effect.AdditionalEffectAttachPoint;
            _effect.AdditionalEffect_DestroyTime = effect.AdditionalEffect_DestroyTime;
            animator.SetTrigger(info.Animation);
        }
        else
        {

        }
    }
}
