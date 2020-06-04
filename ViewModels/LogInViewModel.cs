using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BasicCRUDTool
{
    public class LogInViewModel : BaseViewModel
    {
        #region Private Member


        #endregion

        #region Public Properties
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>

        #endregion

        #region Commands

        public ICommand LogInCommand { get; set; }

        #endregion


        public LogInViewModel()
        {
            LogInCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
           
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> pass in from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await Task.Delay(500);
        }
    }
}
