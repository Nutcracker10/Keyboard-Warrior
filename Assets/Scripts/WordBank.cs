using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> easyWords = new List<string>() {
        "Pancake", "Are", "Delicious"
    };
    private List<string> mediumWords = new List<string>() {

    };
    private List<string> hardWords = new List<string>() {

    };

    private List<string> workingWords = new List<string>();

   private void Awake() {
       //TODO use difficulty to set words
       workingWords.AddRange(easyWords);
       shuffle(workingWords);
       toLower(workingWords);

   }

    private void shuffle(List<string> list) {
        for (int i=0; i<list.Count; i++){
            int random = Random.Range(i, list.Count);
            string temp = list[i];

            list[i] = list[random];
            list[random] = temp;
        }
    }

    private void toLower(List<string> list) {
        for(int i=0; i < list.Count; i++) {
            list[i] = list[i].ToLower();
        }
    }

    public string getWord() {
        string newWord = string.Empty;

        if (workingWords.Count != 0) {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }

        return newWord;
    }
}
