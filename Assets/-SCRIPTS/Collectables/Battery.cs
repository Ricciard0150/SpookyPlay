using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Outline))]
public class Battery : MonoBehaviour, ICollectable
{
    private Outline _outline;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false; // Desativa o outline inicialmente
    }
   
    public void Collect()
    {
        throw new System.NotImplementedException();
    }

    public void HideOutLine()
    {
        if (_outline != null)
        {
            _outline.enabled = false; // Desativa o outline
        }
    }
    public void ShowOutLine()
    {
        if (_outline != null)
        {
            _outline.enabled = true;// Ativa o outline
        }
    }
}
