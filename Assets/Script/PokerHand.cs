using System.Collections.Generic;
using System.Linq;

public class PokerHand
{
    public enum Hand
    {
        None = -1,
        OnePair,
        TwoPair,
        ThreeOfKind,
        Straight,
        Flush,
        FullHouse,
        FourOfKind,
        StraightFlush,
        RoyalFlush
    }
    public static int HighCard = 0;
    public static Hand CardHand(List<Card> cards)
    {

        cards.Sort((a, b) => a.Number - b.Number);

        var kinds = 0;
        var cardsElement = 0;

        foreach (var card in cards.ToLookup(s => s.Number))//同じ値を探す
        {
            if (card.Count() > 1)
            {
                cardsElement++;

                kinds += card.Count();
                HighCard = card.FirstOrDefault().Number;
                kinds += card.Count();
            }
        }

        var clubRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Club);//ラムダ式
        var diaRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Dia);
        var heartRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Heart);
        var spedeRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Spade);

        var firstCardNo = cards[0].Number;

        #region ロイヤルストレートフラッシュ(1,10,11,12,13) Suitがすべて一緒　　//iに数字を当てはめる
        if (firstCardNo.Equals(1))
        {
            if (cards[1].Number.Equals(10))
            {
                var count = 0;
                for (int i = 2; i < cards.Count; i++)
                {
                    if (cards[i].Number.Equals(9 + i))
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count.Equals(3))
                {
                    if (clubRoyal || diaRoyal || heartRoyal || spedeRoyal)
                    {
                        return Hand.RoyalFlush;
                    }
                    else
                    {
                        return Hand.Straight;
                    }
                }
            }
        }
        #endregion

        #region　　　
        var straightCount = 0;
        for (int i = 1; i < cards.Count; i++)　　　　　　　//iに当てはめる
        {
            var straightCardNo = firstCardNo;
            if (cards[i].Number.Equals(straightCardNo + i))
            {
                straightCount++;
                continue;
            }
            else
            {
                break;
            }
        }
        if (straightCount.Equals(4))
        {
           //trueだった場合はストレートフラッシュ
            if (clubRoyal || diaRoyal || heartRoyal || spedeRoyal)
            {


                return Hand.StraightFlush;
            }
            else
            {
                return Hand.Straight;
            }
        }
        #endregion　
        #region
        if (cardsElement.Equals(1) && kinds.Equals(4))
         {
            return Hand.FourOfKind;
        }
        #endregion
        #region
        if (cardsElement.Equals(2) && kinds.Equals(5))
        {
            return Hand.FullHouse;
        }
        #endregion
        #region
        if (clubRoyal || diaRoyal || heartRoyal || spedeRoyal)
        {
            return Hand.Flush;
        }


        if (kinds.Equals(3))
        {
            return Hand.ThreeOfKind;
        }
        
        if (clubRoyal || diaRoyal || heartRoyal || spedeRoyal)
        {
            return Hand.Flush;
        }
        #endregion

        #region  ワンペアかツーペアかスリーカード
        if (kinds.Equals(3))
        {
            return Hand.ThreeOfKind;
        }
        if (cardsElement.Equals(2) && kinds.Equals(4))
        {
            return Hand.TwoPair;
        }
        if (kinds.Equals(2))
        {
            return Hand.OnePair;
        }
        HighCard = cards[4].Number;
        return Hand.None;
        #endregion
    }

}                
      