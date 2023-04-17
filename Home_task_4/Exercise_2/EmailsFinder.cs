using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise_2
{
    internal class EmailsFinder
    {
        const int MAX_PARENTHESIS_AMOUNT = 1;
        const int LOCAL_LENGTH = 64;
        const int DOMAIN_LENGTH = 255;
        private string _text;

        private List<string> _emails;
        private List<string> _nonEmails;

        public EmailsFinder(string text)
        {
            _text = text;
            _emails = new List<string>();
            _nonEmails = new List<string>();
        }

        public EmailsFinder()
        {
            _text = "";
            _emails = new List<string>();
            _nonEmails = new List<string>();
        }
        public List<string> GetEmails()
        {
            return _emails;
        }

        public List<string> GetNonEmails()
        {
            return _nonEmails;
        }

        public void DivideEmails()
        {
            string[] words = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Contains("@"))
                {
                    int atIndex = word.IndexOf("@");
                    if (atIndex > 0 && atIndex < word.Length - 1)
                    {
                        string localPart = word.Substring(0, atIndex);
                        string domainPart = word.Substring(atIndex + 1);
                        if (IsValidLocalPart(localPart) && IsValidDomainPart(domainPart))
                        {
                            _emails.Add(word);
                        }
                        else
                        {
                            _nonEmails.Add(word);
                        }
                    }
                    else
                    {
                        _nonEmails.Add(word);
                    }
                }
            }
        }

        private bool IsValidLocalPart(string localPart)
        {
            // Перевірка частини локальної частини електронної адреси
            if (string.IsNullOrEmpty(localPart))
            {
                return false;
            }

            // Перевірка на допустимі символи
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.!#$%&’*+/=?^_`{|}~-()";
            foreach (char c in localPart)
            {
                if (!allowedCharacters.Contains(c))
                {
                    return false;
                }
            }

            // Перевірка на довжину
            if (localPart.Length > LOCAL_LENGTH)
            {
                return false;
            }

            // Перевірка на крайні крапки
            if (localPart.StartsWith(".") || localPart.EndsWith("."))
            {
                return false;
            }

            // Перевірка на послідовні крапки
            if (localPart.Contains(".."))
            {
                return false;
            }

            // Перевірка на коментарі у дужках
            if (!AreCommentsValid(localPart))
            {
                return false;
            }

            return true;
        }

        private bool IsValidDomainPart(string domainPart)
        {
            // Перевірка частини домену електронної адреси
            if (string.IsNullOrEmpty(domainPart))
            {
                return false;
            }

            // Перевірка на допустимі символи
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-()";
            foreach (char c in domainPart)
            {
                if (!allowedCharacters.Contains(c) && c != '.')
                {
                    return false;
                }
            }

            // Перевірка на довжину
            if (domainPart.Length > DOMAIN_LENGTH)
            {
                return false;
            }

            // Перевірка на крайні крапки та дефіси
            if (domainPart.StartsWith(".") || domainPart.EndsWith(".") || domainPart.StartsWith("-") || domainPart.EndsWith("-"))
            {
                return false;
            }

            // Перевірка на послідовні крапки
            if (domainPart.Contains(".."))
            {
                return false;
            }

            // Перевірка на наявність TLD
            string[] parts = domainPart.Split('.');
            if (parts.Length < 2)
            {
                return false;
            }

            // Перевірка на довжину TLD
            string tld = parts[parts.Length - 1];
            if (tld.Length < 2)
            {
                return false;
            }

            // Перевірка на коментарі у дужках
            if (!AreCommentsValid(domainPart))
            {
                return false;
            }

            return true;
        }

        private bool AreCommentsValid(string input)
        {
            //bool result = input.Contains('(') == input.Contains(')');
            int LeftParenthesisAmount = input.Count(f => (f == '('));
            int RightParenthesisAmount = input.Count(f => (f == ')'));

            if ((LeftParenthesisAmount != RightParenthesisAmount) || (LeftParenthesisAmount > MAX_PARENTHESIS_AMOUNT))
            {
                return false;
            }

            int startIndex = input.IndexOf('(');
            while (startIndex != -1)
            {
                int endIndex = input.IndexOf(')', startIndex);
                if (endIndex == -1)
                {
                    return false;
                }
                if (endIndex == startIndex + 1)
                {
                    return false;
                }
                startIndex = input.IndexOf('(', endIndex);
            }
            return true;
        }
    }
}
