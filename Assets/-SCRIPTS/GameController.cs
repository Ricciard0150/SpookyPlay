using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
<<<<<<< Updated upstream
    public static GameController Instance { get; private set; } //static pertence a classe, não a instância, ou seja, é compartilhada por todas as instâncias da classe. Já o get; private set; é uma propriedade que permite ler o valor de Instance de fora da classe, mas só permite atribuir um valor a Instance de dentro da classe. Isso é útil para garantir que apenas uma instância de GameController seja criada e acessível globalmente.
=======
    public static GameController Instance { get; private set; } // Singleton   
>>>>>>> Stashed changes
    public Transform PlayerTransform { get => _playerTransform; }
    public PatrolController PatrolController { get => _patrolController;}

    [Header("Scene References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PatrolController _patrolController;
<<<<<<< Updated upstream
    [Space]
    [Header("Events")]
    public UnityEvent OnUseBattery;
    public UnityEvent OnUseFlashlight;
    //public GameObject Player { get; private set; }
    //[SerializeField] private GameObject player  ;
    void Awake()
    {
        Instance = this;    
    }
=======
    [Space(10)]
    [Header("Events")]
    public UnityEvent OnUseBattery;
    public UnityEvent OnUseFlashlight;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        Instance = this;
        /* if (Instance == null)
         {
             Instance = this;
            // DontDestroyOnLoad(gameObject);
         }
         else
         {
             Destroy(gameObject);
         }*/
    } 
>>>>>>> Stashed changes
}
