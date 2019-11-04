import Card from "./card";

export default interface DrawCardResponse {
    success: boolean;
    cards: Card[];
    deck_id: string;
    remaining: number;
}
