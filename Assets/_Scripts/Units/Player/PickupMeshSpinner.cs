using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickupMeshSpinner : MonoBehaviour
{
    [SerializeField] private float cycleLength = 2f;

    void Start()
    {
        transform.DOMoveY(1.5f, cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), cycleLength * 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    void OnDestroy() 
    {
        transform.DOKill();
    }


}
