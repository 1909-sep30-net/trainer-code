import NewDeckResponse from "./new-deck-response";
import Card from "./card";
import DrawCardResponse from "./draw-card-response";

export default class CardService {
    deckId: string | null = null;
    urlPrefix = 'https://deckofcardsapi.com/api'

    newDeck(): Promise<string> {
        return fetch(`${this.urlPrefix}/deck/new/`)
            .then(res => res.json())
            .then((res: NewDeckResponse) => {
                this.deckId = res.deck_id;
                return this.deckId;
            });
    }

    drawCard(): Promise<Card> {
        return fetch(`${this.urlPrefix}/deck/${this.deckId}/draw/`)
            .then(res => res.json())
            .then((res: DrawCardResponse) => res.cards[0]);
    }
}
