using UnityEngine;
using System.Collections;

public class TutorialFlow : MonoBehaviour {
    private TutorialStep[] tutorialSteps;
    private int selectedStepIndex = 0;

    private void Awake() {
        tutorialSteps = transform.GetComponentsInChildren<TutorialStep>(true);
        TutorialButton.OnVRButtonClicked += TutorialButtonClicked;
    }

    private void TutorialButtonClicked(object sender, ButtonClickEvent buttonClickEvent) {
        switch (buttonClickEvent.ButtonType) {
            case ButtonTypes.NEXT:
                tutorialSteps[selectedStepIndex].gameObject.SetActive(false);
                if (selectedStepIndex < tutorialSteps.Length - 1) {
                    selectedStepIndex++;
                } else {
                    selectedStepIndex = 0;
                }
                tutorialSteps[selectedStepIndex].gameObject.SetActive(true);
                break;
            case ButtonTypes.BACK:
                tutorialSteps[selectedStepIndex].gameObject.SetActive(false);
                if (selectedStepIndex > 0) {
                    selectedStepIndex--;
                } else {
                    selectedStepIndex = tutorialSteps.Length - 1;
                }
                tutorialSteps[selectedStepIndex].gameObject.SetActive(true);
                break;
            case ButtonTypes.CLOSE:
                gameObject.SetActive(false);
                break;
            default:
                Debug.LogError("Unknown Button Type");
                break;
        }
    }
}
