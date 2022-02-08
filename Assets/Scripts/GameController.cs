using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _panelWithBonus;
    [SerializeField] private TextMeshProUGUI _textBonusAmount;
    [SerializeField] private TextMeshProUGUI _textBalanceAmount;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _getButton;       
     [SerializeField] private Animation AnimationBalance;
     [SerializeField] public Animation AnimationCoins;
     
    private int _bonusAmount;
    private int _balanceAmount;
    private float _time;
    private const float  _timeOfAnimation=3.0f;
    private int _firstBonusAmount;
  
         

    private void Awake(){       
        EventManager.OnEnemyKilled+=BalanceAnimationCall;
         EventManager.OnEnemyKilled+=OnPlayer;
         
    }

    private void Start()
    {               
        _panelWithBonus.SetActive(false);
        _bonusAmount = Random.Range(500, 1000);
        _firstBonusAmount=_bonusAmount;
        _balanceAmount = 0;
                        
    }
    private void Update()
    {           
         _textBonusAmount.text = _bonusAmount.ToString();       
        _textBalanceAmount.text = _balanceAmount.ToString();                        
    }

    public void OnClickBonusButton()
    {
        _panelWithBonus.SetActive(true);
        
    }
    
    public void OnClickGetButton()
    {    
        Destroy(_getButton);                 
        
        StartCoroutine(CoinsFly());                    
    }
  
    
        IEnumerator CoinsFly(){

             _time = Time.time;
            
             for( ;Time.time - _time<_timeOfAnimation;){
                  Instantiate(_coin, Vector3.zero, Quaternion.identity);
                   _bonusAmount-=(int)(_firstBonusAmount / 12f);   
                    yield return new WaitForSeconds(0.25f);
             }

             _bonusAmount=0;
             yield return new WaitForSeconds(0.55f);
             _balanceAmount =_firstBonusAmount;
        }

        private void OnPlayer()
         {          
            _balanceAmount+=(int)(_firstBonusAmount/12f);           
         }  
   

   private void BalanceAnimationCall()
     {
         AnimationBalance.Play("BalanceAnimation");   
         AnimationCoins.Play("MoneyIconAnimation");     
     }
}
