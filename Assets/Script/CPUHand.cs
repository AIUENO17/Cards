using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CPUHand : MonoBehaviour
{
    [SerializeField] private CardDealer m_cardDealer = null;
    [SerializeField] private List<RectTransform> m_cpuCards = new List<RectTransform>();

    [SerializeField] private SpriteAtlas m_cardAtlas = null;
    private List<Card> m_cpuHand = new List<Card>();
    public PokerHand.Hand CPUJudgeHand = PokerHand.Hand.None;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CPUJudgeHand = PokerHand.CardHand(m_cpuHand);
        }
    }

    private void CardUpDate(bool judge = false)
    {
        for (int i = 0; i < m_cpuHand.Count; i++)
        {
            var card = m_cpuHand[i];
            if (judge)
            {
                m_cpuCards[i].GetComponentInChildren<Image>().sprite = m_cardAtlas.GetSprite($"Card_{card.Num}");
            }
            else
            {
                m_cpuCards[i].GetComponentInChildren<Image>().sprite = m_cardAtlas.GetSprite($"Card_54");
            }

        }
    }
    public void CPUCardDeal()
    {
        m_cardDealer.CardDeal(m_cpuHand);
        CardUpDate();
    }
    public void CPUCardDown()
    {
        CardUpDate(true);
    }
}

