using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EfratProject
{
    internal class ValidationHebrew : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //string s = value.ToString();
            //if (s.Length < 2) //בודק אם השם פחות משני תווים  
            //    return new ValidationResult(false, "נא הכנס יותר משני תווים");
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if ((s[i] < 'א' || s[i] > 'ת'))  // בודק אם הם אותיות עברית
            //        return new ValidationResult(false, "הכנס אותיות עברית בלבד");
            //}
            //return ValidationResult.ValidResult;
            string pattern = (string)value;
            Regex reg = new Regex(@"\b[א-ת-\s ]+$");
            Match match = reg.Match(pattern);
            if (match.Success)
                return ValidationResult.ValidResult;  // correct
            else
                return new ValidationResult(false,
                          "הכנס טקסט בעברית בלבד");  // is incorrect
        }
    }
    internal class ValidationPhone : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //int i = 0;
            //string p = value.ToString();
            //if (p.Length < 9 || p.Length > 10) // אורך המספר אינו תקין 
            //    return new ValidationResult(false, "אורך המספר אינו תקין");
            //for (i = 0; i < p.Length; i++)
            //{
            //    if (p[i] <   '0' || p[i] > 10 )
            //        return new ValidationResult(false, " מספר שגוי ");
            //}
            //return ValidationResult.ValidResult;
            string pattern = (string)value;
            Regex reg = new Regex(@"\b05[0 1 2 4 5 6 7 8 3][2-9]\d{6}$");
            Match match = reg.Match(pattern);
            if (match.Success)
                return ValidationResult.ValidResult;  // correct
            else
                return new ValidationResult(false,
                          "הכנס פלאפון תקין");  // is incorrect
        }
    }
    internal class ValidationMail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();

            if (string.IsNullOrWhiteSpace(email))
            {
                return new ValidationResult(false, "Email address cannot be empty");
            }

            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex emailRegex = new Regex(emailPattern);

            if (!emailRegex.IsMatch(email))
            {
                return new ValidationResult(false, "כתובת מייל לא חוקית");
            }

            return ValidationResult.ValidResult;
        }
    }
    internal class ValidationNum : ValidationRule  // בודק מספר דירה , קומה ובניין
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i = 0;
            string p = value.ToString();
            if (p.Length < 0 || p.Length > 3) // אורך המספר אינו תקין 
                return new ValidationResult(false, "אורך המספר אינו תקין");
            for (i = 0; i < p.Length; i++)
            {
                if (p[i] < '0' || p[i] > 500)
                    return new ValidationResult(false, " מספר שגוי ");
            }
            return ValidationResult.ValidResult;
        }
    }
   
    internal class ValidationNumDay : ValidationRule  // בודק יום חלוקה
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i = 0;
            string p = value.ToString();
            //if (p.Length < 0 || p.Length > 1) // אורך המספר אינו תקין 
            //    return new ValidationResult(false, "אורך המספר אינו תקין");
            for (i = 0; i < p.Length; i++)
            {
                if (p[i] == 0 )
                    return new ValidationResult(false, " מספר שגוי ");
            }
            return ValidationResult.ValidResult;
        }
    }
    public class IsID : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string s = (string)value;

            int x;
            if (!int.TryParse(s, out x))
                return new ValidationResult(false,
                         "הכנס תז תקינה");  // is incorrect
            if (s.Length < 5 || s.Length > 9)
                return new ValidationResult(false,
                         "הכנס תז תקינה");  // is incorrect
            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;

            }
            return ValidationResult.ValidResult;  // correct

        }
    }
}
