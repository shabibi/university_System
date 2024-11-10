using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class HostelRepository
    {
        private readonly ApplicationDbContext _context;

        public HostelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Retrieve all hostel information, including the list of students associated with each hostel.
        public IEnumerable<Hostel> GetAllHostels()
        {
            return _context.Hostels.Include(h => h.Students).ToList();
        }

        // Fetch details of a specific hostel, including navigational properties for associated students. 
        public Hostel GetHostelById(int HID)
        {
            return _context.Hostels.Include(h => h.Students).FirstOrDefault(h => h.HostelID == HID);
        }

        //AddHostel: Add a new hostel.
        public void AddHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            _context.SaveChanges();
        }

        //UpdateHostel: Modify an existing hostel's details. 
        public void UpdateHostel(Hostel hostel)
        {
            _context.Hostels.Update(hostel);
            _context.SaveChanges();
        }

        //DeleteHostel: Remove a hostel by ID and ensure no orphaned student data.
        public void DeleteHostel(int hid)
        {
            var hostel = GetHostelById(hid);
            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
                _context.SaveChanges();
            }
        }

        //GetHostelsByCity: List hostels in a specific city using LINQ. 

        public IEnumerable<Hostel> GetHostelsByCity(string City)
        {
            return _context.Hostels.Where(s => s.City == City).ToList();
        }

        //CountHostelsWithAvailableSeats: Provide a count of hostels that have available seats using Count. 
        public int CountHostelsWithAvailableSeats()
        {
            return _context.Hostels.Where(h => h.No_of_seats != 0).Count();
        } 

       
    }
}
    
