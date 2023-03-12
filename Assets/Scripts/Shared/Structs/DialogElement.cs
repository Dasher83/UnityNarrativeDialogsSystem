using NarrativeDialogs.Scripts.Shared.Enums;
using System;
using UnityEngine;


namespace NarrativeDialogs.Scripts.Shared.Structs
{
    [Serializable]
    public class DialogElement
    {
        [SerializeField] private bool _useCustomTimeToRead;
        [SerializeField] private float _timeToRead;
        [SerializeField] private bool _useCustomFadeDuration;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private Character _character;
        [SerializeField] [TextArea] private string _text;

        public float TimeToRead => _useCustomTimeToRead ? _timeToRead : Constants.Dialogs.DefaultTimeToRead;

        public float FadeDuration => _useCustomFadeDuration ? _fadeDuration : Constants.Dialogs.DefaultFadeDuration;

        public Character Character => _character;

        public string Text => _text;
    }
}
