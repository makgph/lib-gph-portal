using System;

namespace sa.gov.libgph.Services.Response
{
    public class GiftedBookResponse
    {
        public int id { get; set; }
        public int giftRequestId { get; set; }
        public string standardBookNumber { get; set; }
        public string bookTitle { get; set; }
        public string authorName { get; set; }
        public string publisherName { get; set; }
        public DateTime publicationDate { get; set; }
        public int numberOfCopies { get; set; }
        public int numberOfCopiesRemaining { get; set; }
        public int bookStatusId { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public object updatedBy { get; set; }
        public object updatedDate { get; set; }
    }
}
