using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class WeaponUIScroller : MonoBehaviour
{
    [SerializeField] ScrollRect weaponScrollUI;
    [SerializeField] float weaponUIIndex;
    [SerializeField] float scrollDuration = 0.5f;


    public void ScrollWeaponInUI(int weaponTypeIndex)
    {
        weaponUIIndex = (float)weaponTypeIndex / 2;

        DOTween.To(
        () => weaponScrollUI.horizontalNormalizedPosition,
        x => weaponScrollUI.horizontalNormalizedPosition = x,
        weaponUIIndex,
        scrollDuration
        );
        
    }
    
}
