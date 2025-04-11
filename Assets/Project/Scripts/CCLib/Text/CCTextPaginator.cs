using System;
using System.Collections.Generic;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.CCLib.Text
{
    public class CCTextPaginator : EEBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI displayText;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button prevButton;
        [SerializeField] private RectTransform textContainer;

        private readonly List<string> pages = new List<string>();
        private int currentPage;

        protected override void EEAwake()
        {
            base.EEAwake();
            nextButton.onClick.AddListener(NextPage);
            prevButton.onClick.AddListener(PrevPage);
            UpdateUI();
        }

        [Button]
        public void SetText(string fullText)
        {
            pages.Clear();
            if (string.IsNullOrEmpty(fullText))
            {
                pages.Add("");
                ShowCurrentPage();
                return;
            }

            var tmpCalculator = Instantiate(displayText, textContainer);
            tmpCalculator.rectTransform.sizeDelta = textContainer.rect.size;
            tmpCalculator.enableWordWrapping = true;
            tmpCalculator.text = "";
            tmpCalculator.ForceMeshUpdate();

            float containerHeight = textContainer.rect.height;
            string[] words = fullText.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> currentLines = new List<string>();
            string currentLine = "";

            foreach (string word in words)
            {
                string testLine = string.IsNullOrEmpty(currentLine) ? word : currentLine + " " + word;
                tmpCalculator.text = testLine;
                tmpCalculator.ForceMeshUpdate();

                if (tmpCalculator.preferredHeight <= containerHeight)
                {
                    currentLine = testLine;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentLine))
                        currentLines.Add(currentLine);

                    tmpCalculator.text = string.Join("\n", currentLines) + "\n" + word;
                    tmpCalculator.ForceMeshUpdate();

                    if (tmpCalculator.preferredHeight > containerHeight)
                    {
                        pages.Add(string.Join("\n", currentLines));
                        currentLines.Clear();
                    }

                    currentLine = word;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
                currentLines.Add(currentLine);

            if (currentLines.Count > 0)
                pages.Add(string.Join("\n", currentLines));

            Destroy(tmpCalculator.gameObject);
            currentPage = 0;
            ShowCurrentPage();
            UpdateUI();
        }

        private void ShowCurrentPage()
        {
            if (pages.Count == 0) return;
            displayText.text = pages[currentPage];
        }

        private void NextPage()
        {
            if (currentPage >= pages.Count - 1) return;
            currentPage++;
            ShowCurrentPage();
            UpdateUI();
        }

        private void PrevPage()
        {
            if (currentPage <= 0) return;
            currentPage--;
            ShowCurrentPage();
            UpdateUI();
        }

        private void UpdateUI()
        {
            prevButton.GetComponent<CanvasGroup>().alpha = currentPage > 0 ? 0 : 1;
            nextButton.GetComponent<CanvasGroup>().alpha = currentPage < pages.Count - 1 ? 0 : 1;
            prevButton.interactable = currentPage > 0;
            nextButton.interactable = currentPage < pages.Count - 1;
        }
    }
}
