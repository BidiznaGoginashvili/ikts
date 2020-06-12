using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTicketService.Domains;
using WCFTicketService.Infrastructure;

namespace WCFTicketService
{
    public class TicketService : ITicketService
    {
        private readonly TicketDbContext _context;

        public TicketService()
        {
            _context = new TicketDbContext();
        }

        public string GetDbValidations(DbEntityValidationException exception)
        {
            var entityValidationErrors = exception.EntityValidationErrors
                       .SelectMany(validation => validation.ValidationErrors
                           .Select(error => error.ErrorMessage));

            return string.Join(";", entityValidationErrors.ToArray());
        }

        public IEnumerable<Ticket> AllTickets()
        {
            var tickets = _context.Set<Ticket>().AsNoTracking().ToList();
            return tickets;
        }

        public string DeleteTicket(int Id)
        {
            try
            {
                if (Id == 0)
                    return "Deletation not succeded";
                var ticket = _context.Set<Ticket>().Find(Id);

                _context.Set<Ticket>().Remove(ticket);
                _context.SaveChanges();
                return "Deletation succeded";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public Ticket GetTicketById(int Id)
        {
            if (Id > 0)
                return _context.Set<Ticket>().Find(Id);

            return new Ticket();
        }

        public string InsertTicket(Ticket ticket)
        {
            try
            {
                _context.Set<Ticket>().Add(ticket);
                _context.SaveChanges();

                return "Insertation succesed";
            }
            catch (DbEntityValidationException exception)
            {
                return GetDbValidations(exception);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string UpdateTicket(Ticket ticket)
        {
            try
            {
                var tckt = _context.Set<Ticket>().Find(ticket.Id);
                if (tckt == null)
                    return "Updation not succesed";
                var newTicket = new Ticket()
                {
                    Name = ticket.Name,
                    ShortDescription = ticket.ShortDescription,
                    FullDescription = ticket.FullDescription,
                    ImagePath = ticket.ImagePath,
                    StartDate = ticket.StartDate,
                    EndDate = ticket.EndDate
                };

                _context.Ticket.Add(newTicket);
                _context.SaveChanges();
                return "Updation succesed";
            }
            catch (DbEntityValidationException exception)
            {
                return GetDbValidations(exception);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
