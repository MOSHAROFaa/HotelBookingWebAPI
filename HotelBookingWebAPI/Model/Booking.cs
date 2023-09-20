using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingWebAPI.Model
{
    [Table("hotelbooking")]
    public class Booking
    {
        [Key]
        [Column("booking_id")]
        public int BookingId { get; set; }
        
        
        [Column("room_no")]
        public string? RoomNo { get; set; }
        
        
        [Column("guest_id")]
        public int GuestId { get; set; }
        
        
        [Column("start_date")]
        public string? StartDate { get; set; }
        
        
        [Column("end_date")]
        public string? EndDate { get; set; }
        

        [Column("guest_name")]
        public string? GuestName { get; set; }
        
        
        [Column("guest_contact")]
        public string? GuestContact { get; set; }
        
        
        [Column("guest_email")]
        public string? GuestEmail { get; set; }

        
        [Column("guest_address")]
        public string? GuestAddress { get; set; }
        
        
        [Column("guest_country")]
        public string? GuestCountry { get; set; }
        
        
        [Column("room_type")]
        public string? RoomType { get; set; }
        
        
        [Column("room_deposit")]
        public int RoomDeposit { get; set; }
        
        
        [Column("room_price")]
        public int RoomPrice { get; set; }
        
        
        [Column("total_paid")]
        public int TotalPaid { get; set; }

        
        [Column("booking_status")]
        public string BookingStatus { get; set; }

    }
}
