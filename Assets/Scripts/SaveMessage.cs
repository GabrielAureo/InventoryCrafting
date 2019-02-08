using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SaveMessage : MonoBehaviour{
    [SerializeField]
    CanvasGroup group;

    public void onSave(){
        //group.transform.DOScaleX(1, 0.1f).onComplete += () => group.alpha = ;
        group.alpha = 1;
        group.transform.localScale = new Vector3(0,1,1);

        Sequence seq = DOTween.Sequence();

        seq.Append(group.transform.DOScaleX(1, 0.3f)).
        AppendInterval(.5f).
        Append(group.DOFade(0, .3f));


    }
}