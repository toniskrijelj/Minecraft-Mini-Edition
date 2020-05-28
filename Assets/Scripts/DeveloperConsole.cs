using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

namespace Console
{
    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }

        public void AddCommandToConsole()
        {
            string addMessage = " command has been added to the console.";

            DeveloperConsole.AddCommandsToConsole(Command, this);
            DeveloperConsole.AddStaticMessageToConsole(Name + addMessage);
        }

        public abstract void RunCommand();
    }
    public class DeveloperConsole : MonoBehaviour
    {
        public static DeveloperConsole Instance { get; private set; }
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

        [Header("UI Components")]
        public Canvas consoleCanvas;
        public ScrollRect scrollRect;
        public TextMeshProUGUI consoleText;
        public TextMeshProUGUI inputText;
        public TMP_InputField consoleInput;
        private void Awake()
        {
            if(Instance != null)
            {
                return;
            }

            Instance = this;
            Commands = new Dictionary<string, ConsoleCommand>();
        }

        private void Start()
        {
            consoleCanvas.transform.Find("InputField (TMP)").gameObject.SetActive(false);
            CreateCommands();
        }

        private void CreateCommands()
        {
            CommandAdd commandAdd = CommandAdd.CreateCommand();
        }

        public static void AddCommandsToConsole(string name, ConsoleCommand command)
        {
            if(!Commands.ContainsKey(name))
            {
                Commands.Add(name, command);
            }
        }

        private void Update()
        {
            if(!consoleCanvas.transform.Find("InputField (TMP)").gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Return))
            {
                consoleCanvas.transform.Find("InputField (TMP)").gameObject.SetActive(true);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    consoleCanvas.transform.Find("InputField (TMP)").gameObject.SetActive(false);
                    if (inputText.text != "")
                    {
                        AddMessageToConsole(inputText.text);
                        ParseInput(inputText.text);
                    }
                }
            }
        }

        private void AddMessageToConsole(string msg)
        {
            consoleText.text += msg + "\n";
            scrollRect.verticalNormalizedPosition = 0f;
        }

        public static void AddStaticMessageToConsole(string msg)
        {
            DeveloperConsole.Instance.consoleText.text += msg + "\n";
            DeveloperConsole.Instance.scrollRect.verticalNormalizedPosition = 0f;
        }

        private void ParseInput(string input)
        {
            string[] inputTemp = input.Split(null);

            if(inputTemp.Length == 0 || inputTemp == null)
            {
                AddMessageToConsole("Command not recognized.");
                return;
            }
            if(!Commands.ContainsKey(inputTemp[0]))
            {
                AddMessageToConsole("Command not recognized.");
            }
            else
            {
                Commands[inputTemp[0]].RunCommand();
            }
        }
    }
}
