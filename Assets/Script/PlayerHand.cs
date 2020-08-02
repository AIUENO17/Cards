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
    private GameObject[] m_playerCardSelectAnimators = new GameObject[5];
    public int PlayerHightCardNumber = 0;
    private void Start()
    {
     
        //playercardのi番目
        for (int i = 0; i < m_playerCards.Count; i++)
        {
            var count = i;
            //onClickAddListenerはクリックしたときに何をするか
            m_playerCardSelectAnimators[i] = m_playerCards[i].GetComponentInChildren<Animator>().gameObject;
            m_playerCards[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                CardChangeChoice(count);
            });
        }
    }
    public void ChangeCard()
    {
        for (int i = 0; i < m_changeChoice.Length; i++)
        {
            Debug.Log(m_changeChoice[i]);

            if (m_changeChoice[i] == true)
            {
                m_cardDealer.CardChange(m_playerHand, i);
            }
        }
        CardUpDate();

        var selectAllFalse = m_changeChoice.Select(s => s = false).ToArray();
        m_changeChoice = selectAllFalse;
        PlayerJudgeHand = PokerHand.CardHand(m_playerHand);
        PlayerHightCardNumber = PokerHand.HighCard;
        PokerFacilitator.ChangeCount--;
        }
      
    


  

    private void CardUpDate()
    {
        for (int i = 0; i < m_playerHand.Count; i++)
        {
            var card = m_playerHand[i];

            foreach (var image in m_playerCards[i].GetComponentsInChildren<Image>())
            {
                if (image.name.Equals("Image"))
                {
                    image.sprite = m_cardAtlas.GetSprite($"Card_{card.Num}");
                }
            }
            m_playerCards[i].GetComponentInChildren<TextMeshProUGUI>().text = $"{card.CardSuit}:{card.Number}";
        }
        foreach (var effectobj in m_playerCardSelectAnimators)
        {
            effectobj.SetActive(false);
        }
    }


 
    private void CardChangeChoice(int _choice)
    {
        m_changeChoice[_choice] = !m_changeChoice[_choice];
        m_playerCardSelectAnimators[_choice].SetActive(m_changeChoice[_choice]);
    }


        public void PlayerCardDeal()
        {
            m_cardDealer.CardDeal(m_playerHand);
            CardUpDate();
        }
    }

