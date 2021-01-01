using ConsoleFluentValidationListParameter.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleFluentValidationListParameter.Validator
{
    public class StudentValidator : AbstractValidator<StudentInformationModel>
    {
        public StudentValidator()
        {
            RuleFor(x => TurkishCharacterReplace(x.Name)).Must(IsLetter).WithMessage("Ad alanı sadece harf içermek zorundadır");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez").MinimumLength(3).WithMessage("Ad alanı 3 karakterden kısa olamaz");
            RuleFor(x => TurkishCharacterReplace(x.Surname)).Must(IsLetter).WithMessage("Soyad alanı sadece harf içermek zorundadır");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez").MinimumLength(2).WithMessage("Soyad alanı 2 karakterden kısa olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail adresini doğru formatta giriniz.");
            RuleFor(x => x.Age).LessThan(42).WithMessage("Öğrenci yaşı  42' den küçük olmak zorundadır").GreaterThan(39).WithMessage("Öğrenci yaşı 39'dan büyük olmak zorundadır");
            RuleFor(x => x.Gender).Must(x => x.Equals("Kadın") || x.Equals("Erkek")).WithMessage("Cinsiyet Erkek veya Kadın olmak zorundadır");
            RuleFor(x => x.PhoneNumber).Must(IsPhoneNumber).WithMessage("Telefon numarası formatı yanlış girildi.");
        }

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(arg);
        }
        private bool IsPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(arg);
        }

        private string TurkishCharacterReplace(string metin)
        {
            metin = metin.Replace("ı", "i");
            metin = metin.Replace("ö", "o");
            metin = metin.Replace("ü", "u");
            metin = metin.Replace("ğ", "g");
            metin = metin.Replace("ç", "c");
            metin = metin.Replace("ş", "s");
            metin = metin.Replace("Ü", "U");
            metin = metin.Replace("İ", "I");
            metin = metin.Replace("Ö", "O");
            metin = metin.Replace("Ğ", "G");
            metin = metin.Replace("Ç", "C");
            metin = metin.Replace("Ş", "S");
            metin = metin.Replace(" ", "");
            return metin;
        }
    }
}
