import {
  IonButton,
  IonItem,
  IonLabel,
  IonList,
  IonListHeader,
  IonText,
} from "@ionic/react";
import "./DeckList.css";
import DeckListMenuButton from "./DeckListMenuButton";
import DeckListModifersButton from "./DeckListModifersButton";

const games = [
    { name: "Super Mario Bros", bg: "rgb(239, 68, 68)", text: "white" }, // Red 500, White text
    { name: "Legend of Zelda", bg: "rgb(34, 197, 94)", text: "black" }, // Green 500, Black text
    { name: "Final Fantasy", bg: "rgb(250, 204, 21)", text: "black" }, // Yellow 400, Black text
    { name: "Sonic the Hedgehog", bg: "rgb(139, 92, 246)", text: "white" }, // Purple 600, White text
    { name: "Pac-Man", bg: "rgb(20, 184, 166)", text: "black" }, // Teal 500, Black text
    { name: "Metroid Prime", bg: "rgb(79, 70, 229)", text: "white" }, // Indigo 700, White text
    { name: "Mega Man", bg: "rgb(244, 114, 182)", text: "black" }, // Pink 400, Black text
    { name: "Street Fighter", bg: "rgb(251, 146, 60)", text: "black" }, // Orange 500, Black text
    { name: "Donkey Kong", bg: "rgb(55, 65, 81)", text: "white" }, // Gray 700, White text
    { name: "Minecraft", bg: "rgb(22, 163, 74)", text: "white" }, // Lime 600, White text
    { name: "Animal Crossing", bg: "rgb(6, 182, 212)", text: "black" }, // Sky 400, Black text
    { name: "Halo Infinite", bg: "rgb(6, 182, 212)", text: "black" }, // Cyan 500, Black text
    { name: "Dark Souls", bg: "rgb(31, 41, 55)", text: "white" }, // Gray 800, White text
    { name: "Call of Duty", bg: "rgb(37, 99, 235)", text: "white" }, // Blue 500, White text
    { name: "Apex Legends", bg: "rgb(244, 114, 182)", text: "black" }, // Rose 600, Black text
  ];

function DeckList() {
  return (
    <IonList
      lines="none"
      className="flex flex-col w-full rounded-xl bg-transparent gap-2"
    >
      <IonListHeader className="relative p-0 w-full">
        <IonLabel className="font-bold uppercase">Decks</IonLabel>
        <div className="absolute left-0 flex w-full h-full">
            <div className="flex w-1/2">
                <DeckListModifersButton />
            </div>
            <div className="flex w-1/2 justify-end">
                <DeckListMenuButton />
            </div>
        </div>
      </IonListHeader>
      <IonItem>
        <IonButton className="w-full h-full">
          <IonText className="text-white normal-case">Pokémon Yellow</IonText>
        </IonButton>
      </IonItem>
      {games.map((game, index) => (
        <IonItem key={index}>
          <IonButton className={`btnx w-full h-full`} style={{ '--background': `${game.bg}` } as React.CSSProperties}>
            <IonText className={`${game.text} normal-case`}>{game.name}</IonText>
          </IonButton>
        </IonItem>
      ))}
    </IonList>
  );
}

export default DeckList;
