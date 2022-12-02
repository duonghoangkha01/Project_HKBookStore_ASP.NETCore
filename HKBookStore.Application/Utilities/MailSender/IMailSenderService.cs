using HKBookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Utilities.MailSender
{
    public interface IMailSenderService
    {
        void SendMailComfirmOrder(Order order);
        void SendMailInvoice(Order order);
    }
}
