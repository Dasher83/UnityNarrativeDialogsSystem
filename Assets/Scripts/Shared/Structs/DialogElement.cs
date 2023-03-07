using NarrativeDialogs.Scripts.Shared.Enums;
using System;
using UnityEngine;


namespace NarrativeDialogs.Scripts.Shared.Structs
{
    [Serializable]
    public class DialogElement
    {
        [SerializeField] private bool _useCustomDelay;
        [SerializeField] private float _delay;
        [SerializeField] private bool _useCustomDuration;
        [SerializeField] private float _duration;
        [SerializeField] private Character _character;
        [SerializeField] [TextArea] private string _text;

        public float Delay => _useCustomDelay ? _delay : Constants.Dialogs.DefaultDelay;

        public float Duration => _useCustomDuration ? _duration : Constants.Dialogs.DefaultDuration;

        public Character Character => _character;

        public string Text => _text;
    }
}
