using UnityEngine;
using UnityEngine.InputSystem;
<<<<<<< Updated upstream
using UnityEngine.Rendering;
public class Interaction : MonoBehaviour
{
    private int batteries;
    [SerializeField] float _interactionRange = 3f;  
    private Camera _mainCam;
    private IInteractable _hit;
    
    void Start()
    {
        _mainCam = Camera.main;
=======

public class Interaction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f;
    private Camera _mainCam;
    private RaycastHit _hit; // objeto alvo do raycast
    private IInteractable _target; // objeto alvo do raycast que implementa a interface IInteractable
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCam = Camera.main;

        /* NÃO USE OS 5 SEGUINTES
         * FindAnyObjectOfType<>() - Procura por um objeto do tipo especificado na cena, o que pode ser lento se houver muitos objetos.
         * FindObjectOfType<>() - Procura por um objeto do tipo especificado na cena, o que pode ser lento se houver muitos objetos.
         * GameObject.Find() - Procura por um objeto na cena pelo nome, o que pode ser lento e propenso a erros se houver múltiplos objetos com o mesmo nome.
         * GameObject.FindWithTag() - Procura por um objeto na cena com uma tag específica, o que pode ser lento se houver muitos objetos com a mesma tag.
         * _mainCam.gameObject.SendMessage("BeginCamera", SendMessageOptions.DontRequireReceiver); // envia uma mensagem para o objeto da câmera, caso ele tenha um método chamado "BeginCamera"
         */
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (!Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out RaycastHit hit, _interactionRange))
            return;

      
        if (hit.collider.TryGetComponent(out IInteractable interactable))
        {
            if (_hit == interactable)// SE FOR O MESMO OBJETO NAO FAÇA NADA 
                return;
            
            _hit?.HideOutline();
            _hit = interactable;
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
        
        _hit.Interact();
    }
=======
        if(Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out RaycastHit hit, interactionRange/*, 3f*/))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if(_target == interactable)
                    return;
                _target?.HideOutLine();
                _target = interactable;
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

        /* if(_target.collider.TryGetComponent<IInteractable>(out var interactable))
         {
             interactable.Interact(transform);
         }*/
    }
    public void OnInteract(InputValue value)
    {
      if(_target == null)
          return;
        _target.Interact();
    }
   /* public void OnDrawGizmosSelected()
    {
        if(_mainCam == null)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_mainCam.transform.position, _mainCam.transform.forward * 3f);
    }
    public void OnDrawGizmos()
    {
        if(_mainCam == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_mainCam.transform.position, _mainCam.transform.forward * 3f);
    }*/
>>>>>>> Stashed changes
}
