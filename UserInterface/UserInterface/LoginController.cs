using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;
namespace UserInterface
{
    public class LoginController
    {
        private LoginManager _logInManager;
        private UserInterface _UI;

        public LoginController (UserInterface UI, LoginManager mngr)
        {
            _UI = UI;
            _UI.StartGameVSAI += StartGameVSAIEventHndler;
            _UI.CreateNewPlayerEvent += CreateNewPlayerEventHandler;  
            //_UI.PlayAgainEvent += SetUpNewGame;
            //_UI.QuitEvent += QuitEventHandler;
            _UI.LogInPlayerEvent += LogInPlayerEventHandler;
            _logInManager = mngr;
            _logInManager.CreateSuccess += CreateSuccessEventHandler;
        }

        private void CreateSuccessEventHandler()
        {
            _UI.SetActivePage(Pages.tabpg_mainmenu);
        }

        private void StartGameVSAIEventHndler()
        {
            GameManager gm = _logInManager.SetUpNewGame();
            _UI.SetEvents(gm);
            Controller cntrl = new Controller(_UI, gm);
            cntrl.SetUpGame();
        }

        private void LogInPlayerEventHandler(object sender, LogInPlayerEventArgs e)
        {
            if (e.playerLogin.Trim() == "")
            {
                _UI.ShowMessage("You must enter login");
            }
            else
            {
                if (e.playerPassword.Trim() == "")
                {
                    _UI.ShowMessage("You must enter password");
                }
                else
                {
                    if (_logInManager.IsUserValidated(e.playerLogin.Trim(), e.playerPassword.Trim()))
                    {
                        _logInManager.SetPlayer(e.playerLogin.Trim());
                        _UI.SetActivePage(Pages.tabpg_loginmenu);                        
                    }
                    else
                    {
                        _UI.ShowMessage("Log in failed");
                    }
                }
            }
        }
        
        private void CreateNewPlayerEventHandler(object sender, CreateNewPlayerEventArgs e)
        {
            if (e.playerLogin.Trim() == "")
            {
                _UI.ShowMessage("You must enter login");
            }
            else
            {
                if (e.playerEmail.Trim() == "")
                {
                    _UI.ShowMessage("You must enter email");
                }
                else
                {
                    if (e.playerPassword.Trim() == "")
                    {
                        _UI.ShowMessage("You must enter password");
                    }
                    else
                    {
                        if (_logInManager.IsLoginUsed(e.playerLogin.Trim()))
                        {
                            User newUser = new User() { login = e.playerLogin.Trim(), pass = e.playerPassword.Trim(), email = e.playerEmail.Trim() };
                            _logInManager.AddUser(newUser);
                        }
                        else
                        {
                            _UI.ShowMessage("Player with such login exists");
                        }
                    }
                }
            }
        }

    }
}
