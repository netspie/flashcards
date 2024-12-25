import React from 'react';
import { IonButton, IonItem, IonLabel, IonList, IonListHeader, IonText } from '@ionic/react';
import "./DeckList.css"

function DeckList() {
  return (
    <IonList lines="none" className='flex flex-col w-full rounded-xl bg-transparent gap-2'>
      <IonListHeader>
        <IonLabel>Decks</IonLabel>
      </IonListHeader>
      <IonItem>
        <IonButton className='w-full h-full'>
            <IonText className='text-white'>Pokémon Yellow</IonText>
        </IonButton>
      </IonItem>
      <IonItem>
        <IonButton className='w-full h-full'>
            <IonText>Pokémon Yellow</IonText>
        </IonButton>
      </IonItem>
      <IonItem>
        <IonButton className='w-full h-full'>
            <IonText>Pokémon Yellow</IonText>
        </IonButton>
      </IonItem>
      <IonItem>
        <IonButton className='w-full h-full'>
            <IonText>Pokémon Yellow</IonText>
        </IonButton>
      </IonItem>
      <IonItem>
        <IonButton className='w-full h-full'>
            <IonText>Pokémon Yellow</IonText>
        </IonButton>
      </IonItem>
    </IonList>
  );
}

export default DeckList;