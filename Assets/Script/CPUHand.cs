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

    private GameObject[] m_CPUCardSelectAnimators = new GameObject[5];

    public int CPUHightCardNumber = 0;

    private void Awake()
    {
        for (int i = 0;i <m_cpuCards.Count;i++)
        {
            m_cpuCards[i].GetComponentInChildren<Animator>().gameObject.SetActive(false);

        }
    }

    public void CPUJudgeCard()
    {
        CPUJudgeHand = PokerHand.CardHand(m_cpuHand);
        CPUHightCardNumber = PokerHand.HighCard;
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

