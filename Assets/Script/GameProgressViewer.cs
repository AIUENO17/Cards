using TMPro;
using UnityEngine;

public class GameProgressViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_progressText;

    private const string GameStartText = "ゲームが開始されました";
    private const string GameChangeText = "カードを選択してチャンジしてください";
    private const string GameBetText = "ベットしてください、勝負しない場合は０を入力してSpaceキーを押してください";


    // Start is called before the first frame update
    public void SetGameStartText()
    {
        m_progressText.text = GameStartText;
    }

    // Update is called once per frame
    public void SetGameBetText()
    {

        m_progressText.text = GameBetText;
    }
    public void SetGameChangeText()
    {
        m_progressText.text = GameChangeText;
    }
    public void SetGameJudgeText(bool playerWin, PokerHand.Hand playerHand, PokerHand.Hand cpuHand)
    {
        if (playerWin)
        {
            m_progressText.text = $"{playerHand}.{ cpuHand}よってPlayerの勝ちです";

        }
        else
        {
            m_progressText.text = $"{cpuHand}.{playerHand}よってCPUの勝ちです";
        }
    }
}