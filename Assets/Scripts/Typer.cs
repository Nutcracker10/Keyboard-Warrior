using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{

    public WordBank wordBank = null;
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private AudioSource typing;
    private AudioSource returnSound;

    private void Start() {
        setCurrentWord();
        AudioSource[] sound;
        sound = GetComponents<AudioSource>();
        typing = sound[0];
        returnSound = sound[1];
    }

    private void setCurrentWord() {
        currentWord = wordBank.getWord();
        setRemainingWord(currentWord);
    }

    private void setRemainingWord(string word) {
        remainingWord = word;
        wordOutput.text = remainingWord;
    }

    private void Update() {
        checkInput();
    }

    private void checkInput() {
        if (Input.anyKeyDown && ( ! PauseMenu.gameIsPaused )) {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1) {
                enterLetter(keysPressed);
            }
            
        }
    }

    private void enterLetter(string typedLetter) {
        if (isCorrectLetter(typedLetter)) {
            removeLetter();
            typing.Play();

            if(isWordComplete() ) {
                returnSound.Play();
                setCurrentWord();
            }
        }
    }

    private bool isCorrectLetter(string letter) {
        
        return remainingWord.IndexOf(letter) == 0;
    }

    private void removeLetter() {
        string newString = remainingWord.Remove(0,1);
        setRemainingWord(newString);
    }

    private bool isWordComplete() {
        return remainingWord.Length == 0;
    }
}
