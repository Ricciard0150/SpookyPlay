using System.Collections;
using UnityEngine;
using UnityEngine.AI;
<<<<<<< Updated upstream
=======
using UnityEngine.UIElements.Experimental;
>>>>>>> Stashed changes

public enum EnemyState
{
    Idle,
    Chasing,
    Patrolling
}
public class Enemy : MonoBehaviour
{
<<<<<<< Updated upstream
    private PatrolController _patrolController;
    private GameObject _nape;
    private NavMeshAgent _agent;
    private Transform _player;
    private EnemyState _currentState;
    [SerializeField][Range(0.5f, 5f)]private float _waitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nape = transform.GetChild(0).gameObject;
        _player = GameController.Instance.PlayerTransform;
        _patrolController = GameController.Instance.PatrolController;   
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 3f;

=======
    [SerializeField] private PatrolController _patrolController;// Responsável por fornecer os pontos de patrulha para o inimigo, permitindo que ele se mova entre esses pontos quando estiver no estado de patrulha.
    [SerializeField] private GameObject _nape;
    private NavMeshAgent _agent;//Responsável por calcular rotas e mover o inimigo no ambiente usando a navegação do Unity. 
    [SerializeField] private Transform _player;// Referência ao Transform do jogador, que é o alvo que o inimigo irá perseguir.
    //float _waitTime = 2f;// Tempo de espera para o inimigo mudar de estado, usado para simular um comportamento mais realista, como esperar um pouco antes de começar a perseguir o jogador.
    private EnemyState _currentState = EnemyState.Idle;// Variável para armazenar o estado atual do inimigo, que pode ser Idle, Chasing ou Patrolling.
    [SerializeField][Range(0.5f, 5)] private float _waitTime;
    [SerializeField] private Animator animator;
    
    IEnumerator Start()
    {
        _player = GameController.Instance.PlayerTransform; // Obtém a referência ao Transform do jogador a partir do GameController, que é um singleton responsável por gerenciar o jogo.
        _agent = GetComponent<NavMeshAgent>();
       
        //enemyPosition = _agent.transform.position.y; // Inicializa a posição do inimigo com a posição atual do GameObject.
        animator = GetComponentInChildren<Animator>();
       
        if (animator != null)
        {
            animator.SetBool("Spawn", true); // Define o parâmetro "Spawn" como true para iniciar a animação de spawn
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsPatroling", false);
            animator.SetBool("IsIdle", false);
        }
        print(animator.name);
        yield return new WaitForSeconds(2f); // Espera 2 segundos para simular o tempo de spawn do inimigo, permitindo que a animação de spawn seja exibida antes de iniciar o comportamento do inimigo.
        animator.SetBool("Spawn", false); // Define o parâmetro "Spawn" como false para finalizar a animação de spawn
        print("chegou");
>>>>>>> Stashed changes
        SetState(EnemyState.Patrolling);
    }

    // Update is called once per frame
    void Update()
<<<<<<< Updated upstream
    {
        Vision();
        
    }
    public void Vision()
    {
        bool playerInSight = Physics.Linecast(transform.position, _player.position, out RaycastHit hit);
        if (playerInSight)
        {
            //aqui o enemy para
            if (!_currentState.Equals(EnemyState.Chasing))
                return;
            SetState(EnemyState.Idle);
        }
        else
        {
            if (_currentState.Equals(EnemyState.Chasing))
                return;
            StopAllCoroutines();
            SetState(EnemyState.Chasing);
        }
    }
    public void SetState(EnemyState newState)
    {
        Vector3 lastPlayerPos = _player.position;   
        switch (_currentState)
        {
            case EnemyState.Idle:
                StartCoroutine(Wait());
                break;
            case EnemyState.Chasing:
                _agent.SetDestination(lastPlayerPos);
                _nape.SetActive(false);
                break;
            case EnemyState.Patrolling:
                // Implement patrolling logic here
                break;
        }
        _currentState = newState;
        switch(_currentState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Chasing:
                _nape.SetActive(false);
                _agent.SetDestination(_player.position);
                break;
            case EnemyState.Patrolling:
                // Implement patrolling logic here  
                print("inimigo começou a caça");
                _agent.SetDestination(_patrolController.MoveToNextPoint()); 
                StartCoroutine(Patrolling());
=======
    {      
        //Vision();
        /*
        if(!_currentState.Equals(EnemyState.Patrolling))
            return;
        //só chega aqui se estiver patrulhando
        //o if abaixo verifica se ainda falta caminho para mamar o destino, ou seja, se o inimigo ainda não chegou ao ponto de patrulha, ele continua indo para lá, caso contrário, ele chama o método para ir para o próximo ponto de patrulha.
        if(_agent.remainingDistance > _agent.stoppingDistance)
            return;
        //se o inimigo chegou no ponto da mamada, ele chama o método para ir para o próximo ponto de patrulha.
        SetState(EnemyState.Idle);
        //_agent.SetDestination(_player.position);
        */

    }
    public void Vision()
    {
        // Se houver um obstáculo, o inimigo não persegue o jogador, caso contrário, ele entra no estado de perseguição.
        //Vector3 offSet = new Vector3(0, 1.5f, 0);// O offset é para ajustar a posição do inimigo para que o raycast seja lançado a partir de uma altura mais realista, geralmente na altura dos olhos do inimigo.
        bool playerInSight = Physics.Linecast(transform.position, _player.position , out RaycastHit hit);
        if (playerInSight)
        { //no veo nadica de pyoer
            if(_currentState.Equals(EnemyState.Chasing))
                SetState(EnemyState.Idle);
            /* if (!_currentState.Equals(EnemyState.Chasing))
                 return;
             SetState(EnemyState.Idle);*/
            //Aqui o enemy para
            //_agent.SetDestination(transform.position);//Uma maneira de parar o agente, definir como destino a própria posição

            /*
            print(_currentState);
            if (!_currentState.Equals(EnemyState.Chasing))// Se já estiver no estado de perseguição, passa a ficar idle.
                return;
            print(_currentState);
            SetState(EnemyState.Idle);//Se estiver perseguindo, vai para o estado Idle.
            return;//Aqui é dentro do if de ter um obstaculo, então não quero que avançe no método, por isso o return.*/
        }
        else
        {//Aqui o enemy persegue o jogador
            if(_currentState.Equals(EnemyState.Chasing))// Se já estiver no estado de perseguição, passa a ficar idle.
                return;
            StopAllCoroutines();// Para todas as coroutines em execução, como a de espera para mudar para o estado de patrulha, para garantir que o inimigo comece a perseguir imediatamente.
            SetState(EnemyState.Chasing);
        }
        /*if (!Physics.Linecast(transform.position, _player.position/*, out RaycastHit hit))
        {
            if(!_currentState.Equals(EnemyState.Chasing))// Se já estiver no estado de perseguição, passa a ficar idle.
                return;
            SetState(EnemyState.Idle);//Se estiver perseguindo, vai para o estado Idle.
            return;//Aqui é dentro do if de ter um obstaculo, então não quero que avançe no método, por isso o return.
        }*/
        //Se chegar aqui, é porque não tem obstáculo entre o inimigo e o jogador, então o inimigo deve perseguir o jogador.   
       /* if (!_currentState.Equals(EnemyState.Chasing))// Se não estiver no estado de perseguição, o inimigo não faz nada.
            return;
        SetState(EnemyState.Chasing);*/
    }
    public void SetState(EnemyState newState)
    {
        //O primeiro swwitch é para simular um OnTriggerExit, onde o inimigo para de fazer algo relacionado ao estado anterior, e o segundo switch é para simular um OnTriggerEnter, onde o inimigo começa a fazer algo relacionado ao novo estado.
        Vector3 lastPlayerPosition = _player.position;// Armazena a última posição conhecida do jogador, que pode ser usada para o inimigo continuar perseguindo mesmo se perder a visão do jogador.
        switch (_currentState)
        {
            case EnemyState.Idle:
                // Lógica para sair do estado Idle (a ser implementada)
                animator.SetBool("IsIdle", false);
                break;
            case EnemyState.Chasing:
                // Lógica para sair do estado Chasing (a ser implementada)
                _nape.SetActive(false);
                _agent.SetDestination(_player.position);
                animator.SetBool("IsChasing", false);
                break;
            case EnemyState.Patrolling:
                animator.SetBool("IsPatroling", false);
                // Lógica para sair do estado Patrolling (a ser implementada)
                break;
        }
        _currentState = newState;// Atualiza o estado atual para o novo estado
        // O segundo switch é para simular um OnTriggerEnter, onde o inimigo começa a fazer algo relacionado ao novo estado.
        switch (_currentState)
        {
            case EnemyState.Idle:
                StartCoroutine(Wait());// Inicia a coroutine de espera para mudar para o estado de patrulha após um tempo.
                animator.SetBool("IsIdle", true); // Define o parâmetro "IsIdle" como false para finalizar a animação de idle
                animator.SetBool("IsPatroling", false);
                animator.SetBool("IsChasing", false);
                break;
            case EnemyState.Chasing:
                // _agent.isStopped = false; // Permite que o inimigo se mova
                _nape.SetActive(false);
                _agent.SetDestination(_player.position);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsChasing", true);
                animator.SetBool("IsPatroling", false);
               
                break;
            case EnemyState.Patrolling:
                // Lógica para patrulhar (a ser implementada)
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsChasing", false);
                animator.SetBool("IsPatroling", true);
               _agent.SetDestination(_patrolController.MoveToNextPoint()); // Define o próximo ponto de patrulha para o inimigo.
                StartCoroutine(Patrolling());// Inicia a coroutine de patrulha para o inimigo começar a se mover entre os pontos de patrulha.
>>>>>>> Stashed changes
                break;
        }
    }
    IEnumerator Wait()
    {
<<<<<<< Updated upstream
        Debug.LogError("Temporario");
        yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
        yield return new WaitForSeconds(_waitTime + 3);
        SetState(EnemyState.Patrolling);
    }    
    IEnumerator Patrolling()
    {
        yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
        SetState(EnemyState.Idle);
    }
} 
=======
        //Ainda falta implementar a lógica para o inimigo patrulhar, mas a ideia é que quando o inimigo entrar no estado de idle, ele espere um tempo antes de passar para o estado de patrulha, para simular um comportamento mais realista.
        Debug.LogError("Temporário");
        yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance); // Espera até que o inimigo chegue ao ponto de patrulha antes de definir o próximo ponto.
        yield return new WaitForSeconds(_waitTime); // 
        SetState(EnemyState.Patrolling);
    }
    IEnumerator Patrolling()
    {
        while (_currentState == EnemyState.Patrolling)
        {
           // _agent.SetDestination(_patrolController.MoveToNextPoint()); // Define o próximo ponto de patrulha para o inimigo.
            yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance); // Espera até que o inimigo chegue ao ponto de patrulha antes de definir o próximo ponto.
            //Quando chegar aqui, ela terá chego ao ponto de patrulha.
            SetState(EnemyState.Idle);
        }
    }
}
>>>>>>> Stashed changes
