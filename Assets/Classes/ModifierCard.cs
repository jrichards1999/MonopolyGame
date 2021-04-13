using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonopolyNamespace
{
    public class ModifierCard : MonoBehaviour
    {
        private string cardType;
        private string description;
        private string modString;

        public ModifierCard(string type, string message, string modifier)
        {
            cardType = type;
            description = message;
            modString = modifier;
        }

        public string getCardType()
        {
            return cardType;
        }

        public string getDescription()
        {
            return description;
        }

        public string getModifier()
        {
            return modString;
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

