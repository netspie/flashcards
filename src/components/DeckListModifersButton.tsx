import {
  IonButton,
  IonContent,
  IonIcon,
  IonItem,
  IonList,
  IonPopover,
} from "@ionic/react";
import { filter, funnel, grid } from "ionicons/icons";

function DeckListModifersButton() {
  return (
    <>
      <IonButton
        id="popover-button-x"
        className="self-end w-12 h-12 md:block m-0 rounded-none"
      >
        <IonIcon
          slot="icon-only"
          icon={funnel}
          className="text-gray-50 w-8 h-8 pointer-events-none"
        />
      </IonButton>
      <IonPopover trigger="popover-button-x" dismissOnSelect={true}>
        <IonContent>
          <IonList>
            <IonItem button={true} detail={false} className="px-2">
              Add Deck
            </IonItem>
            <IonItem button={true} detail={false} className="px-2">
              Option 2
            </IonItem>
            <IonItem button={true} id="nested-trigger" className="px-2">
              More options...
            </IonItem>

            <IonPopover
              trigger="nested-trigger"
              dismissOnSelect={true}
              side="end"
            >
              <IonContent>
                <IonList>
                  <IonItem button={true} detail={false}>
                    Nested option
                  </IonItem>
                </IonList>
              </IonContent>
            </IonPopover>
          </IonList>
        </IonContent>
      </IonPopover>
    </>
  );
}

export default DeckListModifersButton;