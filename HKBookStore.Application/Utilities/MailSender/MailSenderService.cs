using HKBookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Utilities.MailSender
{
    public class MailSenderService : IMailSenderService
    {

        public void SendMailComfirmOrder(Order order)
        {
            try
            {
                // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
                MailMessage mail = new MailMessage("info.hkbookstore@gmail.com", order.AppUser.Email, "Xác nhận đơn hàng", "Cảm ơn bạn đã đặt hàng!"); //
                mail.IsBodyHtml = true;
                //gửi tin nhắn
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Host = "smtp.gmail.com";
                //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
                client.UseDefaultCredentials = false;
                client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                                   // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
                client.Credentials = new NetworkCredential("info.hkbookstore@gmail.com", "dpqualqbnrjpruwc");
                client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
                client.Send(mail);
            }
            catch (Exception ex)
            {
                
            }
            

        }
        void SendMailInvoice(Order order)
        {
            
        }

        void IMailSenderService.SendMailInvoice(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
