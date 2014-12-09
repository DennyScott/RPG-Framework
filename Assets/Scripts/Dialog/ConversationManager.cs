using UnityEngine;
using System.Collections;

public class ConversationManager : Singleton<ConversationManager>{
	//Is there a conversation going on
	bool talking = false;

	//The current line of text being displayed
	ConversationEntry currentConversationLine;

	//Estimated width of characters in the font
	int fontSpacing = 7;

	//How wide does the dialog window need to be
	int conversationTextWidth;

	//How high does the dialog window need to be
	int dialogHeight = 70;

	//Guarntee this will always be a singleton only -
	//Cant use the constructor!
	protected ConversationManager (){

	}

	public void StartConversation(Conversation conversation){}

	IEnumerator DisplayConversation(Conversation conversation) {
		talking = true;
		foreach (var conversationLine in conversation.ConversationLines){
			currentConversationLine = conversationLine;
			conversationTextWidth = currentConversationLine.ConversationText.Length * fontSpacing;
			yield return new WaitForSeconds(3);
		}
		talking = false;
	}

	void OnGUI() {
		if(talking){
			//Layout start
			GUI.BeginGroup(new Rect(Screen.width / 2 - conversationTextWidth / 2, 50, conversationTextWidth + 10, dialogHeight));

			//The background box
			GUI.Box (new Rect(0, 0, conversationTextWidth + 10, dialogHeight), "");

			//The character Name
			GUI.Label (new Rect(10, 10, conversationTextWidth + 30, 20), currentConversationLine.SpeakingCharacterName);

			//The conversation text
			GUI.Label (new Rect(10, 30, conversationTextWidth + 30, 20), currentConversationLine.ConversationText);

			//Layout end
			GUI.EndGroup();
		}
	}


}
