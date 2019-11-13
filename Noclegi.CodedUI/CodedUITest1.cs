using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace Noclegi.CodedUI
{/*
    
    [CodedUITest]
    public class CodedUITest1
    {
       
        private static Process _proc;
        private const string _address = "http://localhost:51324";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Playback.Initialize();
            var bw = BrowserWindow.Launch(new Uri(_address));
            _proc = bw.Process;
            bw.CloseOnPlaybackCleanup = false;
        }

        

        [TestMethod]
        public void CodedUITesCRUD()
        {

            this.UIMap.login();
            this.UIMap.CreateCategoryTest();
            this.UIMap.EditCategoryTest();
            this.UIMap.CreateDistrictTest();
            this.UIMap.EditDistrictTest();
            this.UIMap.DeleteDistrictTest();
            this.UIMap.DeleteCategoryTest();
            this.UIMap.logoutTest();

        }

        [ClassCleanup]
        public static void CleanUp()
        {
            var bw = BrowserWindow.FromProcess(_proc);
            bw.Close();
        }

        #region Dodatkowe atrybuty testu

        // Można użyć następujących dodatkowych atrybutów w trakcie pisania testów:

        ////Użyj TestInitialize do uruchomienia kodu przed uruchomieniem każdego testu 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Aby wygenerować kod dla tego testu, wybierz opcję „Generuj kod dla kodowanego testu interfejsu użytkownika” z menu skrótów i wybierz jeden z elementów menu.
        //}

        ////Użyj TestCleanup do uruchomienia kodu po wykonaniu każdego testu
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Aby wygenerować kod dla tego testu, wybierz opcję „Generuj kod dla kodowanego testu interfejsu użytkownika” z menu skrótów i wybierz jeden z elementów menu.
        //}

        #endregion

        /// <summary>
        ///Pobiera lub ustawia kontekst testu, który udostępnia
        ///funkcjonalność i informację o bieżącym uruchomieniu testu.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
    */
}
