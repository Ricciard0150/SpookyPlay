using UnityEngine;
using UnityEngine.InputSystem;
<<<<<<< Updated upstream
using UnityEngine.Rendering;
public class Inventory : MonoBehaviour
{
    [SerializeField] float _interactionRange = 3f;
    private Camera _mainCam;
    private ICollectable _hit;
    [SerializeField]private int _batteries;

=======

public class Inventory : MonoBehaviour
{

    private int _batteries;
    [SerializeField] private float interactionRange = 3f;
    private Camera _mainCam;
    private RaycastHit _hit; // objeto alvo do raycast
    private ICollectable _target; // objeto alvo do raycast que implementa a interface ICollectable
    // Start is called once before the first execution of Update after the MonoBehaviour is created
>>>>>>> Stashed changes
    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (!Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out RaycastHit hit, _interactionRange))
            return;
        if (hit.collider.TryGetComponent(out ICollectable collecta))
        {
            if (_hit == collecta)// SE FOR O MESMO OBJETO NAO FAÇA NADA 
                return;

            _hit?.HideOutline();
            _hit = collecta;
            _hit.ShowOutline();
        }

        else
        { // caso o raycast acerte algo que nai seja interagivel ou nao acerte nada, esconde o outline do objeto anterior   
            _hit?.HideOutline();
            _hit = null;
        }
    }

    public void OnInteract(InputValue value)
    {

        if (_hit == null)
            return;

        _hit.Collect();
        _batteries++;   
    }
    public void OnRechange(InputValue value)
    {
        if (_batteries <= 0)
            return;

        _batteries--;
        GameController.Instance.OnUseBattery.Invoke();
    }

=======
        if (Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out RaycastHit hit, interactionRange/*, 3f*/))
        {
            if (hit.collider.TryGetComponent(out ICollectable collectable))
            {
                if (_target == collectable)
                    return;
                _target?.HideOutLine();
                _target = collectable;
                _target.ShowOutLine();
            }
            else
            {
                _target?.HideOutLine();
                _target = null;
            }
        }
        else
        {
            _target?.HideOutLine();
            _target = null;
        }
       
    }
    public void OnInteract(InputValue value)
    {
        if (_target == null)
            return;
        _target.Collect();
        _batteries++;
    }   
    public void OnRecharge(InputValue value)
    {
        if (_batteries <= 0)
             return;
        _batteries--;
        GameController.Instance.OnUseBattery.Invoke();
    }
>>>>>>> Stashed changes
    public void OnUseFlashlight(InputValue value)
    {
        GameController.Instance.OnUseFlashlight.Invoke();
    }
<<<<<<< Updated upstream
}

=======

}
>>>>>>> Stashed changes
