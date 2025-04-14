using Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    public partial class MainForm : Form
    {
        private static MainForm instance = null;
        private static readonly object padlock = new();

        protected readonly ReadOnlyDictionary<Tab, TabChangingControl> Tabs;
        public TabChangingControl CurrentlySelectedTab;
        private bool BoardLoaded = false;
        private MainForm()
        {
            InitializeComponent();
            Tabs = new ReadOnlyDictionary<Tab, TabChangingControl>(new Dictionary<Tab, TabChangingControl>
            {
                { Tab.MAIN_MENU, mainMenu },
                { Tab.ROOM_SELECTOR, roomList },
                { Tab.GAME, gameTab }
            });

            foreach (TabChangingControl tab in Tabs.Values)
            {
                tab.TabChange += new System.EventHandler(ChangeTab);
                DisableTab(tab);
            }
            EnableTab(mainMenu);
            CurrentlySelectedTab = mainMenu;
        }

        public static MainForm Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new MainForm();
                    return instance;
                }
            }
        }

        protected void ChangeTab(object sender, EventArgs e)
        {
            TabSelectEventArgs args = (TabSelectEventArgs)e;
            if (args.SelectedTab == Tab.GAME)
            {
                if (!BoardLoaded)
                {
                    Images.Load();
                    BoardGraphic.DrawBoard(0, 0);
                    BoardLoaded = true;
                }
                Invoke(new Action(() => gameTab.Board = new ChessBoard()));
                Invoke(new Action(() => gameTab.UpdateGraphics()));
                
            }
            if (args.SelectedRoom != null) 
            {
                gameTab.UpdateRoom(args.SelectedRoom);
            }
            DisableTab(CurrentlySelectedTab);
            EnableTab(Tabs[args.SelectedTab]);
            CurrentlySelectedTab = Tabs[args.SelectedTab];
        }

        protected static void EnableTab(TabChangingControl tab)
        {
            tab.Enabled = true;
            tab.Visible = true;
        }

        protected static void DisableTab(TabChangingControl tab)
        {
            tab.Enabled = false;
            tab.Visible = false;
        }
    }
}
