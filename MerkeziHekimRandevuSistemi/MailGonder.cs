using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MerkeziHekimRandevuSistemi
{
    public class Responsee
    {
        public bool Hatalimi { get; set; }
        public string HataMesaji { get; set; }
    }
    class MailGonder
    {
        public static string kod;
        public static void kodOlustur()
        {
            kod = "";
            int harf, bykharf, hangisi;
            Random Rharf = new Random();
            Random Rsayi = new Random();
            Random Rbykharf = new Random();
            Random Rhangisi = new Random();

            for (int b = 0; b < 8; b++)
            {
                int a = 0;
                hangisi = Rhangisi.Next(1, 3);
                if (hangisi == 1)
                {
                    kod += Rsayi.Next(0, 10).ToString();
                }
                if (hangisi == 2)
                {
                    harf = Rharf.Next(1, 27);
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        a++;
                        if (a == harf)
                        {
                            bykharf = Rbykharf.Next(1, 3);
                            if (bykharf == 1)
                            {
                                kod += i;
                            }
                            if (bykharf == 2)
                            {
                                kod += i.ToString().ToUpper();
                            }
                        }
                    }
                }

            }
        }//public static void kodOlustur()
         //{
         //          Random rnd = new Random();
         //	for (int i = 0; i < 6; i++)
         //		kod += rnd.Next('a', 'z');
         //}
        public static void Gonder(string kime)
        {
            kodOlustur();
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("beyzaonlinee@gmail.com", "B1G2secur3");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            Responsee response = new Responsee();
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("beyzaonlinee@gmail.com");
            ePosta.To.Add(kime);
            ePosta.Subject = "Güvenlik Kodu";
            ePosta.Body = string.Format("<html><b>Güvenlik Kodunuz:</b> {0} </html>", kod);
            ePosta.IsBodyHtml = true;
            smtp.Send(ePosta);
        }
    }
}
