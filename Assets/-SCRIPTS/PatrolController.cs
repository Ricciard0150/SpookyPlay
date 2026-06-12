using UnityEngine;

public class PatrolController : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private Transform[] _patrolPoints; //array pq tem valor fixo
    private int _currentPointIndex;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 GetRandomPoint()
    {
          int randomIndex = Random.Range(0, _patrolPoints.Length);
        return _patrolPoints[randomIndex].position;
        //criar metodo para retornar o ponro de patrulha mais proximo do inimigo
        //criar metodo para retornar o ponto de patrulha mais proximo do player
    }
    public Vector3 MoveToNextPoint()
    {
               if (_patrolPoints.Length == 0)
            return Vector3.zero;
        Vector3 nextPoint = _patrolPoints[_currentPointIndex].localPosition;
        _currentPointIndex++;
        if(_currentPointIndex >= _patrolPoints.Length)
            _currentPointIndex = 0; 
        print ("next patrol point: " + nextPoint);
        return nextPoint;
=======
   [SerializeField] private Transform[] _patrolPoints; // Array de pontos de patrulha que o inimigo irá seguir.
    private int _currentPoinIndex = 0; // Índice para rastrear o ponto de patrulha atual.                                     
    public Vector3 GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _patrolPoints.Length); // Gera um índice aleatório para selecionar um ponto de patrulha do array.       
        return _patrolPoints[randomIndex].position;
    }

    public Vector3 MoveToNextPoint()
    {
        if (_patrolPoints.Length == 0)
            return Vector3.zero;
        Vector3 nextPoint = _patrolPoints[0].localPosition; // Obtém o próximo ponto de patrulha do array.
       _currentPoinIndex ++;
        if(_currentPoinIndex >= _patrolPoints.Length)//Volta para o primeiro ponto de patrulha
            _currentPoinIndex = 0;
        /*
         * para montar un esquema de "carrosel", teria que adicionar uma verificação do valor minimo 
         * if(_currentPointIndex < 0) 
         * _currentPointIndex = _patrolPoints.Length - 1; 
         * Isso para ficar no estilo do pokemon tcg buxa.
         */
        print("Next patrol point" + nextPoint);
        return nextPoint;   
>>>>>>> Stashed changes
    }
}
