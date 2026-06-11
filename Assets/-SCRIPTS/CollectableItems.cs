using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class CollectableItems : MonoBehaviour, ICollectable
{
    private Outline _outline;
    [SerializeField] private GameObject _hand;
    public void Collect()
    {
        Destroy(gameObject);
    }
    public void HideOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = false;
        }
    }

    public void ShowOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = true;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _outline = GetComponentInChildren<Outline>();
        _outline.enabled = false;
    }
}
