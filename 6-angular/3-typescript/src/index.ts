import CardService from "./card-service";

export class Program {
    public static main(): void {
        const cardService = new CardService();

        document.addEventListener('DOMContentLoaded', () => {
            const newDeckButton = document.getElementById('newDeckButton') as HTMLButtonElement;
            const newShuffledDeckButton = document.getElementById('newShuffledDeckButton') as HTMLButtonElement;
            const drawCardButton = document.getElementById('drawCardButton') as HTMLButtonElement;
            const cardContainer = document.getElementById('cardContainer') as HTMLDivElement;

            newDeckButton.addEventListener('click', () => {
                cardService.newDeck().then(() => {
                    while (cardContainer.firstChild) {
                        cardContainer.firstChild.remove();
                    }
                });
            });

            newShuffledDeckButton.addEventListener('click', () => {
                cardService.newDeck().then(() => {
                    while (cardContainer.firstChild) {
                        cardContainer.firstChild.remove();
                    }
                });
            });

            drawCardButton.addEventListener('click', () => {
                cardService.drawCard().then(card => {
                    const cardImg = document.createElement('img') as HTMLImageElement;
                    cardImg.src = card.image;
                    cardContainer.appendChild(cardImg);
                });
            });
        });
    }
}

Program.main();
