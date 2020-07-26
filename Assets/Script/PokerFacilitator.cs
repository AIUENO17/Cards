using UnityEngine;
using UnityEngine.UI;

public class PokerFacilitator : MonoBehaviour
{
    [SerializeField] private PlayerHand m_playerHand;
    [SerializeField] private CPUHand m_cpuHand;
    [SerializeField] private InputField m_betField;
    public static int ChangeCount = 1;

    private enum GameState
    {
        Invalid = -1,
        Init,
        Deal,
        Change,
        Bet,
        Judge,
        Result
    }

    public int PlayerCoin = 100;
    public int CPUCoin = 100;
    public int BetCoin = 0;
    public bool PlayerWin = false;
    private float m_resultViewTime = 1.0f;


    private GameState m_gameState = GameState.Invalid;

    void Update()
    {
        switch (m_gameState)
        {
            case GameState.Invalid:
                m_gameState = GameState.Init;
                break;
            case GameState.Init:

                m_resultViewTime = 1.0f;

                m_betField.enabled = false;

                m_gameState = GameState.Deal;
                break;
            case GameState.Deal:

                PlayerCoin -= 5;
                CPUCoin -= 5;

                m_playerHand.PlayerCardDeal();
                m_cpuHand.CPUCardDeal();

                m_gameState = GameState.Change;
                break;

            case GameState.Change:

                if (ChangeCount < 1)
                {
                    m_gameState = GameState.Bet;
                }
                break;
            case GameState.Bet:

                m_betField.enabled = true;

                break;

            case GameState.Judge:
                Debug.Log("Judge");
                m_cpuHand.CPUCardDown();
                if (m_playerHand.PlayerJudgeHand > m_cpuHand.CPUJudgeHand)
                {
                    PlayerWin = true;
                    PlayerCoin += BetCoin;
                    CPUCoin -= BetCoin;

                }
                else if (m_cpuHand.CPUJudgeHand > m_playerHand.PlayerJudgeHand)
                {

                    PlayerWin = false;
                    PlayerCoin -= BetCoin;
                    CPUCoin += BetCoin;


                }
                ChangeCount++;
                BetCoin = 0;

                m_betField.text = string.Empty;

                m_gameState = GameState.Result;

                break;

            case GameState.Result:

                m_resultViewTime -= Time.deltaTime;

                if (PlayerWin)
                {
                    Debug.Log("Playerの勝ち");
                }
                else
                {
                    Debug.Log("CPUの勝ち");
                }

                if (m_resultViewTime < 0)
                {
                    m_gameState = GameState.Init;
                }
                break;

        }
    }
    public void BetInput()
    {
        BetCoin = int.Parse(m_betField.text);
        if (BetCoin > 0)
        {
            m_gameState = GameState.Judge;
        }
        else
        {
            m_gameState = GameState.Init;
        }
    }

}