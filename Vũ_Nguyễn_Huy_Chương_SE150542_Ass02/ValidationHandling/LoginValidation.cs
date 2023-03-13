using System.Text.RegularExpressions;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.ValidationHandling
{
    public class LoginValidation
    {

        public string CheckLoginValidation(string email, string password)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return "Please enter email or password please";
            if (!regex.IsMatch(email))
                return "Please enter the email with formatly";
            return "ok";
        }
    }
}
