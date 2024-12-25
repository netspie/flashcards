import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import DeckList from '../components/DeckList';

const Tab1: React.FC = () => {
  return (
    <IonPage>
      <IonContent fullscreen>
        <div className="flex flex-col text-center justify-center items-center p-4 gap-4">
          <div className="p-8 bg-slate-600 w-full
           text-white">
            <h1 className="text-2xl font-bold uppercase">Ultimate Flashcards</h1>
            <p className="mt-4 text-sm">The easiest flashcards in the world! Add your decks, learn and rehearse. Never forget!</p>
        </div>
        <div className='w-full md:px-24 lg:px-48 xl:px-72 2xl:px-96'>
          <DeckList>
          </DeckList>
        </div>
        </div>
      </IonContent>
    </IonPage>
  );
};

export default Tab1;
