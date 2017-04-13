using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;

namespace UserInterface
{
    public interface IViewable
    {

        void CardPlayedEventHandler(object sender, CardPlayedEventArgs args);
        void StartNewTurnEventHandler(object sender, EventArgs args);
        void EndTurnEventHandler(object sender, EventArgs args);
        void VictoryEventHandler(object sender, VictoryEventArgs e);
        void GameSetUpEventHandler(object sender, EventArgs e);
        void FieldChangedEventHandler(object sender, EventArgs e);
        void UserCreatedEventHandler();


    }
}
