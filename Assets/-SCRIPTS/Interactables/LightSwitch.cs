using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isOn;
    [SerializeField] private UnityEvent OnTurnOn;
    [SerializeField] private UnityEvent OnTurnOff;
    private Outline _outline;
    void Start()
    {
      _outline = GetComponent<Outline>();      
        _outline.enabled = false; // Desativa o contorno inicialmente
    }
    public void Interact()
    {
        if (_isOn)
        {
            OnTurnOff.Invoke();
        }
        else
        {
            print("ligou");
            OnTurnOn.Invoke();
        }
        _isOn = !_isOn;
        //Animação de ligar/desligar a luz pode ser feita aqui, ou através dos eventos OnTurnOn e OnTurnOff, dependendo da implementação desejada.
    }

    public void HideOutLine()
    {
        if (_outline != null)
        {
            _outline.enabled = false;
        }
    }
    public void ShowOutLine()
    {
        if (_outline != null)
        {
            _outline.enabled = true;
        }
    }
}
