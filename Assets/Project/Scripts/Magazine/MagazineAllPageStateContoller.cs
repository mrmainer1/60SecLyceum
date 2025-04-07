using System.Collections.Generic;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using UnityEngine;

namespace Project.Scripts.Magazine
{
    public class MagazineAllPageStateContoller : EEBehaviour
    {
        [SerializeField] private List<MagazinePage> magazinePageList;

        private MagazinePage lastPage;

        public void ActiveLastPage()
        {
            if (lastPage == null) lastPage = magazinePageList[0];

            lastPage.Active();

        }
        public void DisableOtherMenu(MagazinePage magazinePage)
        {
            lastPage = magazinePage;
            foreach (var pageList in magazinePageList)
            {
                if (pageList == magazinePage) continue;
                pageList.Desable();
            }
        }
    }
}
