namespace Auditor.Common
{
    public class DataAnnotationConstants
    {
        public static readonly int CodeLength = 4;
        public static readonly int PostcodeLength = 5;
        public static readonly int VatLength = 9;
        public static readonly int TelephoneLength = 15;
        public static readonly int TitleLength = 300;
        public static readonly int DescriptionLength = 512;
        public static readonly int SmallComments = 256;
        public static readonly int MediumComments = 1024; 
        public static readonly int LargeComments = 2048;
        // if it is over 4000, it is stored like nvarchar(max)
        //public static readonly int VeryLargeComments = 6000;
        //public static readonly int TooLargeComments = 15000;
        public static readonly int Year = 4;
        public static readonly int IdentityCardNumber = 60;
        public static readonly int TaxCode = 12;
        public static readonly int PhoneNumberLength = 20;
        public static readonly int TotalPagesLength = 100;

        #region Numerical 
        public static readonly int Twentyfive = 25;
        public static readonly int Fifty = 50;
        public static readonly int Hundrent = 100;
        public static readonly int HundrentFifty = 150;
        public static readonly int TwoHundrents = 200;
        public static readonly int ThreeHundrents = 300;
        public static readonly int FourHundrents = 400;
        public static readonly int FiveHundrents = 500;
        #endregion
    }
}