using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _scaleDuration = 1f;

    public void Initialize(UnityAction subscribeAction)
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        _button.enabled = false;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(()=>
        {
            subscribeAction?.Invoke();
            Hide();
        });
    }

    public void Show()
    {
        transform.DOScale(1f, _scaleDuration).SetEase(Ease.OutBounce)
            .OnComplete(()=>
            {
                _button.enabled = true;
            });
    }

    public void Hide()
    {
        _button.enabled = false;
        transform.DOScale(0f, 0f);
    }
}
