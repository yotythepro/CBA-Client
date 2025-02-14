using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    internal class Response
    {
        public RequestType Type { get; set; }
        public bool Success { get; set; }
        public List<Room> Body { get; set; }
        public string ErrorMessage { get; set; }

        public Response(RequestType type, bool success, List<Room> body, string errorMessage)
        {
            Type = type;
            Success = success;
            Body = body;
            ErrorMessage = errorMessage;
        }

        public void Handle()
        {
            if (!Success)
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            switch (Type)
            {
                case RequestType.CREATE_ROOM:
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.gameTab.color = PieceColor.Black));
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.CurrentlySelectedTab.ChangeTab(Tab.GAME, Body[0])));
                    break;
                case RequestType.JOIN_ROOM:
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.CurrentlySelectedTab.ChangeTab(Tab.GAME, Body[0])));
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.gameTab.UpdateOpponentName(Body[0].CreatorUserName)));
                    break;
                case RequestType.GET_ROOM_LIST:
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.roomList.UpdateList(Body)));
                    break;
                case RequestType.CLOSE_ROOM:
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.CurrentlySelectedTab.ChangeTab(Tab.ROOM_SELECTOR)));
                    break;
            }
        }
    }
}
