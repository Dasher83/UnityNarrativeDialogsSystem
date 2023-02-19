using SetSailBoi.Scripts.Shared;
using SetSailBoi.Scripts.Shared.Enums;
using SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions;
using SetSailBoi.Scripts.Shared.Structs;
using SetSailBoi.Scripts.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


namespace SetSailBoi.Scripts.Installers
{
    public class DialogInstaller
    {
        public void LoadDialogs(
            GameObject oldMan, GameObject youngBoy, 
            DialogScriptable dialogData)
        {
            Debug.Log(dialogData);

            var fileContents = Resources.Load<TextAsset>("Dialogs").text;
            var chapterCollection = JsonUtility.FromJson<ChaptersCollection>(fileContents);
            var chapters = new List<DialogJsonItem[]> {
                chapterCollection.chapters.tutorial1,
                chapterCollection.chapters.tutorial2,
                chapterCollection.chapters.tutorial3,
                chapterCollection.chapters.tutorial4,
                chapterCollection.chapters.tutorial5,
                chapterCollection.chapters.chapter1,
                chapterCollection.chapters.chapter2,
                chapterCollection.chapters.chapter3,
                chapterCollection.chapters.chapter4,
                chapterCollection.chapters.chapter5,
                chapterCollection.chapters.placeholder
            };
            List<List<DialogParams>> result = new List<List<DialogParams>>();
            foreach(DialogJsonItem[] chapter in chapters)
            {
                DialogParams[] dialogParamsArray = new DialogParams[chapter.Length];
                for(int i = 0; i < chapter.Length; i++)
                {
                    DialogParams dialogParamsObj = new DialogParams();
                    if ((Characters)chapter[i].character == Characters.OldMan)
                    {
                        dialogParamsObj.setDialogText = oldMan.GetComponent<SetDialogText>();
                        dialogParamsObj.canvasGroup = oldMan.GetComponent<CanvasGroup>();
                    }
                    else
                    {
                        dialogParamsObj.setDialogText = youngBoy.GetComponent<SetDialogText>();
                        dialogParamsObj.canvasGroup = youngBoy.GetComponent<CanvasGroup>();
                    }
                    dialogParamsObj.text = chapter[i].text;
                    dialogParamsObj.delay = Constants.Fader.DialogueDuration;
                    dialogParamsObj.duration = Constants.Fader.FadeDuration;
                    dialogParamsArray[i] = dialogParamsObj;
                }
                result.Add(dialogParamsArray.ToList());
            }
            dialogData.ChaptersCollection = result;
        }
    }
}
