using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    private GameObject _holder;

    private void Awake()
    {
        _holder = GetComponentInChildren<GameObject>();
    }

    public void Show()
    {
        _holder.SetActive(true);
    }

    public void Hide()
    {
        _holder.SetActive(false);
    }
}
