using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinViewer : MonoBehaviour
{
    [SerializeField] private PokerFacilitator m_pokerFacilitator = null;

    [SerializeField] private TextMeshProUGUI m_playerCoinView = null;

    [SerializeField] private TextMeshProUGUI m_CPUCoinView = null;



   void Update()
    {
        //m_playerCoinViewのtextにm_pokerFacilitatorのplayerCoinをひょうじする
        m_playerCoinView.text = m_pokerFacilitator.PlayerCoin.ToString();
        //m_CPUCoinViewのtextにm_pokerFacilitatorのCPUCoinを表示する
        m_CPUCoinView.text = m_pokerFacilitator.CPUCoin.ToString();
    }
}
