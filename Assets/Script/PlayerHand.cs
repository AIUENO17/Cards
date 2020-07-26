using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private CardDealer m_cardDealer = null;
    [SerializeField] private List<RectTransform> m_playerCards = new List<RectTransform>();
    [SerializeField] private SpriteAtlas m_cardAtlas = null;
    private List<Card> m_playerHand = new List<Card>();

    private bool[] m_changeChoice = new bool[5] { false, false, false, false, false };
    public PokerHand.Hand PlayerJudgeHand = PokerHand.Hand.None;


    private void Start()
    {
     
        //playercardのi番目
        for (int i = 0; i < m_playerCards.Count; i++)
        {
            var count = i;//onClickAddListenerはクリックしたときに何をするか
            m_playerCards[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                CardChangeChoice(count);
            });
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < m_changeChoice.Length; i++)
            {
                if (m_changeChoice[i] == true)
                {
                    m_cardDealer.CardChange(m_playerHand, i);
                }
            }
            CardUpDate();

            var selectAllFalse = m_changeChoice.Select(s => s = false).ToArray();
            m_changeChoice = selectAllFalse;
            PlayerJudgeHand = PokerHand.CardHand(m_playerHand);

            PokerFacilitator.ChangeCount--;
        }
    }

    private void CardUpDate()
    {
        for (int i = 0; i < m_playerHand.Count; i++)
        {
            var card = m_playerHand[i];
            m_playerCards[i].GetComponentInChildren<Image>().sprite = m_cardAtlas.GetSprite($"Card_{card.Num}");
            m_playerCards[i].GetComponentInChildren<TextMeshProUGUI>().text = $"{card.CardSuit}:{card.Number}";
        }
    }
    private void CardChangeChoice(int _choice)
    {
        m_changeChoice[_choice] = true;
    }


        public void PlayerCardDeal()
        {
            m_cardDealer.CardDeal(m_playerHand);
            CardUpDate();
        }
    }

