using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ActiveState
{
    OFF, ON
}
public class Flashlight : MonoBehaviour
{
    private ActiveState _activeState = ActiveState.ON;
    private Light _light;
    private float _originalIntensity;
    [SerializeField] private float _intensityDecreaseRate = 0.5f;
    [SerializeField] private float _batteryDuration = 10f;
    private bool _lostingPower; // booleanaqque habilita a perda de intensidade da luz quando a bateria atual da lanterna estiver fraca
    private bool _isFullBattery = true;
    private float _batteryTimer;
    void Start()
    {
        _light = GetComponent<Light>();
        _originalIntensity = _light.intensity;
        GameController.Instance.OnUseBattery.AddListener(Recharge);
        GameController.Instance.OnUseFlashlight.AddListener(TurnFlashlight);      
        _batteryTimer = _batteryDuration;
    }
    private void Recharge()
    {
        _light.intensity = _originalIntensity;
        _batteryTimer = _batteryDuration;
        _lostingPower = false;
       /* StopAllCoroutines();//Se o jogador usar uma bateria nova antes da atual acabar, a lanterna recarrega e o tempo para perder intensidade de luz é resetado
        StartCoroutine(FullBattery());//Inicia a contagem de tempo para a bateria acabar e a lanterna começar a perder intensidade de luz */
    }

    /*IEnumerator FullBattery()// Corroutine que controla o tempo para a bateria acabar e a lanterna começar a perder intensidade de luz. Sendo um metodo que executa gradativamente com o uso de recursos determunados pelo yield return, nesse caso, o tempo de duração da bateria. O método é chamado toda vez que o jogador usa uma bateria nova para recarregar a lanterna, garantindo que a contagem de tempo seja resetada e a lanterna recarregue completamente antes de começar a perder intensidade de luz novamente.
    {
        _light.intensity = _originalIntensity;
        yield return new WaitForSeconds(_batteryDuration); // Tempo que a lanterna não perde intensidade de luz
        _lostingPower = true;
    }*/
    void Update()
    {
        //Esse swicth é para assimilar algo como o OnCollisionStay, pois executa lógica a cada frame dependendo do estado atual da lanterna
        switch(_activeState)
        {
            case ActiveState.OFF:
                //Se a lanterna estiver desligada, não precisa executar nada
                //os sistemas relacionados a bateria ficam "suspensos"
                break;
            case ActiveState.ON:
                //Enquanto não estiver perdendo poder, diminui o poder
                if (_lostingPower)
                {
                    if (_light.intensity <= 0)//Nullcheck para evitar que a intensidade da luz fique negativa, o que poderia causar comportamentos indesejados no jogo. Se a intensidade da luz for menor ou igual a zero, o método retorna imediatamente, evitando que a linha de código que diminui a intensidade seja executada.
                        return;
                    _light.intensity -= _intensityDecreaseRate * Time.deltaTime;                    
                }
                else//se não estiver perdendo energia, não faça nada
                {
                    _batteryTimer -= Time.deltaTime;//Diminui o timer da bateria a cada frame, fazendo com que a bateria acabe gradativamente com o tempo
                    if (_batteryTimer <= 0)//Quando o timer da bateria chegar a zero, a lanterna começa a perder intensidade de luz
                    {
                        _lostingPower = true;//Começa a perder intensidade de luz
                        _isFullBattery = false;
                    }
                }              
                    break;            
            default:
                break;
        }
       
    }
    public void TurnFlashlight()
    { 
        if(_activeState.Equals(ActiveState.ON))
        {
            SetState(ActiveState.OFF);         
        }
        else 
        {
            SetState(ActiveState.ON);
        }
    }
    public void SetState(ActiveState newState)
    {
        switch(newState)
        {
            case ActiveState.ON://if(newState.Equals(ActiveState.ON))
                _light.enabled = true;//Execussão do código para ligar a lanterna, ativando o componente de luz associado a ela. Isso faz com que a lanterna emita luz no ambiente do jogo, permitindo que o jogador veja melhor em áreas escuras ou durante a noite.
                break;//Encerra a execução do swicth
            case ActiveState.OFF://if(newState.Equals(ActiveState.OFF))
                _light.enabled = false;//Execussão do código para desligar a lanterna, desativando o componente de luz associado a ela. Isso faz com que a lanterna pare de emitir luz no ambiente do jogo, tornando mais difícil para o jogador ver em áreas escuras ou durante a noite.
                break;//Encerra a execução do swicth
        }
        _activeState = newState;
    }
}
