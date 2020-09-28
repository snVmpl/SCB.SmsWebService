namespace SCB.Core
{
    public static class GlobalConstants
    {
        public static class SuccessMessage
        {
            public const string MessagesSent = "SUCCESS: All messages have been sent.";
        }
        public static class ExceptionMessages
        {
            public static class Common
            {
                public const string InternalError = "SMS_SERVICE:";
            }
            public static class PhoneNumbers
            {
                public const string NotInternationalFormat = "PHONE_NUMBERS_INVALID: One or several phone numbers do not match with international format.";
                public const string PhoneNumbersIsEmpty = "PHONE_NUMBERS_EMPTY: Phone_numbers is missing.";

                public const string PhoneNumbers16Limit =
                    "PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 16 per";

                public const string PhoneNumbers128PerDayLimit =
                    "PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 128 per day.";

                public const string DuplicateNumbers = "PHONE_NUMBERS_INVALID: Duplicate numbers detected.";
            }

            public static class Message
            {
                public const string MessageIsEmpty = "MESSAGE_EMPTY: Invite message is missing.";

                public const string IncorrectGSMFormat =
                    "MESSAGE_INVALID: Invite message should contain only characters in 7-bit GSM encoding or Cyrillic letters as well.";

                public const string TooLong =
                    "MESSAGE_INVALID: Invite message too long, should be less or equal to 128 characters of 7-bit GSM charset.";
            }
        }

        public static class RegexRules
        {
            public const string IsOnlyLatin = @"^[A-Za-z]+$";
            public const string HasCyrillic = @"[а-яА-Я]";
            public const string IsInternationalPhoneNumber = @"\d{11}";
            public const string IsGSMAndCyrillicFormat = "^[\\w@?£!1$\"¥#è?¤é%ù&ì\\\\ò(Ç)*:Ø+;ÄäøÆ,<LÖlöæ\\-=ÑñÅß.>ÜüåÉ\\/§à¡¿\\'а-яА-Я]+$";
        }
    }
}
