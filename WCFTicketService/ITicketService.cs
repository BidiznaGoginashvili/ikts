using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTicketService.Domains;

namespace WCFTicketService
{
    [ServiceContract]
    public interface ITicketService
    {
        [OperationContract]
        Ticket GetTicketById(int Id);

        [OperationContract]
        string InsertTicket(Ticket ticket);

        [OperationContract]
        string UpdateTicket(Ticket ticket);

        [OperationContract]
        IEnumerable<Ticket> AllTickets();

        [OperationContract]
        string DeleteTicket(int Id);
    }
}
