using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CPUHand : MonoBehaviour
{
    [SerializeField] private CardDealer m_cardDealer = null;
    [SerializeField] private List<RectTransform> m_cpuCards = new List<RectTransform>();
    private List<Card> m_cpuHand = new List<Card>();
    public PokerHand.Hand CPUJudgeHand = PokerHand.Hand.None;

    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CPUJudgeHand = PokerHand.CardHand(m_cpuHand);
        }
    }

    private void CardUpDate()
    {
        for (int i = 0; i < m_cpuHand.Count; i++)
        {
            var card = m_cpuHand[i];
            m_cpuCards[i].GetComponentInChildren<TextMeshProUGUI>().text = $"{card.CardSuit}:{card.Number}";
        }
    }
    public void CPUCardDeal()
    {
        m_cardDealer.CardDeal(m_cpuHand);
        CardUpDate();
    }
}
