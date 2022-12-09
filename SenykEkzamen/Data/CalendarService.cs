using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenykEkzamen.Data
{
    public class CalendarService
    {
        private CalendarDbContext _context;

        public CalendarService(CalendarDbContext context)
        {
            _context = context;
        }

        public void AddEvent(CalendarVM _event)
        {
            Calendar e = new Calendar
            {
                Name = _event.Name,
                Description = _event.Description,
                Time = _event.Time,
                Frequency = _event.Frequency
            };
            _context.Calendar.Add(e);
            _context.SaveChanges();
        }

        public List<Calendar> GetAllEvents()
        {
            return _context.Calendar.ToList();
        }

        public Calendar GetEvent(int eventId)
        {
            return _context.Calendar.FirstOrDefault(c => c.Id == eventId);
        }

        public List<Calendar> FindEvent(string word)
        {
            return _context.Calendar.Where(c => c.Name.Contains(word)).ToList();
        }

        public Calendar UpdateEvent(int eventId, CalendarVM _event)
        {
            Calendar e = _context.Calendar.FirstOrDefault(c => c.Id == eventId);
            if (e != null)
            {
                e.Name = _event.Name;
                e.Description = _event.Description;
                e.Time = _event.Time;
                e.Frequency = _event.Frequency;
                _context.SaveChanges();
            }
            return e;
        }

        public void DeleteEvent(int eventId)
        {
            try
            {
                Calendar e = _context.Calendar.FirstOrDefault(c => c.Id == eventId);
                if (e != null)
                {
                    _context.Remove(e);
                    _context.SaveChanges();
                }
            }
            catch { }
        }
    }
}
